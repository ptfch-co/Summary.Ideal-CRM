namespace Summary.IdealCrm.Services
{
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using Core.Data;
    using Core.Mvc.Utilities;
    using Core.Workflows;
    using Summary.IdealCrm;
    using Summary.IdealCrm.Settings;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IQuoteService
    {
        Task<QuoteCreateInfo> CreateAsync(
            string userName,
            string password,
            string company,
            string personnel,
            string project,
            string title,
            string number,
            DateTime? date,
            string subject,
            string discountTitle,
            bool isVerified,
            string status,
            string group,
            bool isFixed,
            string payCondition,
            string description,
            string description2,
            string printFormat,
            string accountNumber,
            string shabaNumber,
            string address,
            string telephone,
            string website,
            string email,
            string transportation,
            string referUser,
            string creatorUser,
            long total_discount
        );

        Task InsertItemAsync(
            string userName,
            string password,
            int quote,
            string code,
            int count,
            float basePrice,
            float finalPrice,
            string inventoryCode,
            float baseDiscount,
            float baseTax,
            string creatorUser,
            string description
        );

        Task<string> CreatePaymentAsync(
            string userName,
            string password,
            int quote,
            string payType,
            int? payAmount,
            string payNumber,
            string payDescription,
            string payDate,
            string documentAmount,
            string creatorUser
        );
    }

    public class QuoteService : IQuoteService
    {
        private readonly HttpRequestClient _client;
        private readonly IdealCrmSettings _options;
        private readonly IProductService _product;
        private readonly IUserService _user;

        public QuoteService(HttpRequestClient client,
            IOptions<IdealCrmSettings> options,
            IProductService product,
            IUserService user)
        {
            _client = client;
            _options = options.Value;
            _product = product;
            _user = user;
        }

        public async Task<QuoteCreateInfo> CreateAsync(
            string userName,
            string password,
            string company,
            string personnel,
            string project,
            string title,
            string number,
            DateTime? date,
            string subject,
            string discountTitle,
            bool isVerified,
            string status,
            string group,
            bool isFixed,
            string payCondition,
            string description,
            string description2,
            string printFormat,
            string accountNumber,
            string shabaNumber,
            string address,
            string telephone,
            string website,
            string email,
            string transportation,
            string referUser,
            string creatorUser,
            long total_discount)
        {
            userName = String.IsNullOrWhiteSpace(userName) ? _options.UserName : userName;
            password = String.IsNullOrWhiteSpace(password) ? _options.Password : password;
            creatorUser = String.IsNullOrWhiteSpace(creatorUser) ? _options.DefaultCreatorUser : creatorUser;

            int? status_id = null;
            int? printFormatId = null;
            int? creator_user_id = null;

            if (date.HasValue == false) date = DateTime.Now;

            if (String.IsNullOrWhiteSpace(status) == false) status_id =
                status.ConvertTo<int>() ?? await GetStatusIdAsync(userName, password, status);

            if (String.IsNullOrWhiteSpace(printFormat) == false) printFormatId =
                printFormat.ConvertTo<int>() ?? await GetPrintFormatIdAsync(userName, password, printFormat);

            if (String.IsNullOrWhiteSpace(creatorUser) == false) creator_user_id =
                creatorUser.ConvertTo<int>() ?? await _user.GetUserIdAsync(creatorUser);

            var data = new
            {
                UserName = userName,
                Password = password,
                ApiPordTitle = title,
                ApiPordNumber = number,
                ApiPordDate = date.Value.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("en-US")),
                ApiCompanyId = company,
                ApiCompanyPersonId = personnel,
                ApiProjectId = project,
                ApiPordDiscount = total_discount,
                ApiPordSubject = subject,
                ApiPordCalculateTax = false,
                ApiPordRound = 0,
                ApiPordStatusId = status_id,
                ApiPordDescriptionI = description,
                ApiPordDescriptionII = description2,
                ApiPordPrintFormatId = printFormatId,
                ApiPordAccountNumberI = accountNumber,
                ApiPordAccountShabaNumberI = shabaNumber,
                ApiPordAddress = address,
                ApiPordTelephone = telephone,
                ApiPordWebSite = website,
                ApiPordEmail = email,
                ApiPordTransportation = transportation,
                ApiPordReferUserId = creator_user_id,
                UserId = creator_user_id
            };

            var quote_response = await _client.SendPostRequestAsync<CreateQuoteResponseModel>(
                $"{_options.ApiAddress}/Api/ApiPreOrders/Insert",
                data,
                null,
                "application/x-www-form-urlencoded"
            );

            if (quote_response.Status == Status.Success) return quote_response.Data;

            else throw new WorkflowException(
                quote_response.Message,
                null,
                JsonConvert.SerializeObject(data)
            );
        }

        public async Task InsertItemAsync(
            string userName,
            string password,
            int quote,
            string code,
            int count,
            float base_unit_price,
            float total_price,
            string inventoryCode,
            float discount,
            float baseTax,
            string creatorUser,
            string description)
        {
            userName = String.IsNullOrWhiteSpace(userName) ? _options.UserName : userName;
            password = String.IsNullOrWhiteSpace(password) ? _options.Password : password;
            creatorUser = String.IsNullOrWhiteSpace(creatorUser) ? _options.DefaultCreatorUser : creatorUser;

            int? creatorUserId = null;

            if (String.IsNullOrWhiteSpace(creatorUser) == false)
            {
                creatorUserId = creatorUser.ConvertTo<int>() ?? await _user.GetUserIdAsync(creatorUser);
            }

            if (String.IsNullOrWhiteSpace(code)) throw new WorkflowException(
                "مقدار فیلد کد محصول یکی از اقلام پیش فاکتور خالی است.",
                null,
                null,
                $"کاربر گرامی؛ یکی از اقلام پیش‌فاکتور فاقد کد محصول است. توجه داشته باشید درج کد محصول برای ایجاد پیش‌فاکتور الزامی می‌باشد. لطفاً برای قلم کالای مربوطه کد محصول را ثبت کرده و سپس درخواست را مجدداً به صف همگام‌سازی ارسال نمایید.",
                Level.Information
            );

            var product = await _product.GetDetailsByAsync(
                userName,
                password,
                ProductSearchKind.Code,
                code
            );

            var data = new
            {
                UserName = userName,
                Password = password,
                ApiPreOrderId = quote,
                ApiPordIPrdId = product.ApiProductID,
                ApiPordIQuantity = count,
                ApiPordIPrice = base_unit_price,
                ApiPordITotalPrice = total_price,
                ApiPordIDiscount = discount,
                ApiPordIDiscountPercent = ((decimal)discount / (decimal)base_unit_price) * 100,
                ApiPordIPrdUnitId = 1,
                ApiPordICurrencyUnitId = 1,
                ApiPordIWHId = inventoryCode,
                UserId = creatorUserId,
                ApiPordIPriceSum = total_price,
                ApiPordIDiscountSum = discount * count
            };

            var item_response = await _client.SendPostRequestAsync<BaseResultModel>(
                $"{_options.ApiAddress}/Api/ApiPreOrders/InsertPreOrderItem",
                data,
                null,
                "application/x-www-form-urlencoded"
            );

            if (item_response.Status == Status.Error) throw new WorkflowException(
                item_response.Message,
                null,
                JsonConvert.SerializeObject(data)
            );
        }

        public async Task<string> CreatePaymentAsync(
            string userName,
            string password,
            int quote,
            string payType,
            int? payAmount,
            string payNumber,
            string payDescription,
            string payDate,
            string documentAmount,
            string creatorUser)
        {
            userName = String.IsNullOrWhiteSpace(userName) ? _options.UserName : userName;
            password = String.IsNullOrWhiteSpace(password) ? _options.Password : password;
            creatorUser = String.IsNullOrWhiteSpace(creatorUser) ? _options.DefaultCreatorUser : creatorUser;

            int? creatorUserId = null;

            if (String.IsNullOrWhiteSpace(creatorUser) == false)
            {
                creatorUserId = creatorUser.ConvertTo<int>() ?? await _user.GetUserIdAsync(creatorUser);
            }

            var payment_response = await _client.SendPostRequestAsync<BaseResultModel>(
                $"{_options.ApiAddress}/Api/ApiPreOrders/InsertPreOrderPayment",
                new
                {
                    UserName = userName,
                    Password = password,
                    ApiPreOrderId = quote,
                    ApiPordPayTypeId = payType,
                    ApiPordPayAmount = payAmount,
                    ApiPordPayDocNumber = payNumber,
                    ApiPordPayDescription = payDescription,
                    ApiPordPayDocDateTime = payDate,
                    ApiPordPayDocAmount = documentAmount,
                    UserId = creatorUserId
                },
                null,
                "application/x-www-form-urlencoded"
            );

            if (payment_response.Status == Status.Error)
                throw new NotImplementedException(payment_response.Message);
            else
                return payment_response.Data;
        }

        private async Task<int> GetPrintFormatIdAsync(
            string userName,
            string password,
            string name)
        {
            var printFormats = await _client.SendPostRequestAsync<BaseInformationResultModel<PrintFormatInfo>>(
                $"{_options.ApiAddress}/Api/ApiBaseInfo/SelectPrintFormat",
                new
                {
                    UserName = userName,
                    Password = password,
                    // Fetch quote's printFormats
                    ApiPrintFormatTypeId = 1
                },
                null,
                "application/x-www-form-urlencoded"
            );

            return printFormats.Data.First(x => x.ApiTitle.Equals(name)).ApiPrintFormatID;
        }

        private async Task<int> GetStatusIdAsync(
            string userName,
            string password,
            string name)
        {
            var statuses = await _client.SendPostRequestAsync<BaseInformationResultModel<QuoteStatusInfo>>(
                $"{_options.ApiAddress}/Api/ApiBaseInfo/SelectPreOrderStatus",
                new
                {
                    UserName = userName,
                    Password = password
                },
                null,
                "application/x-www-form-urlencoded"
            );

            return statuses.Data.First(x => x.ApiPreOrderStatus.Equals(name)).ApiPreOrderStatusId;
        }

        private async Task<int> GetGroupIdAsync(
            string userName,
            string password,
            string name)
        {
            var groups = await _client.SendPostRequestAsync<BaseInformationResultModel<QuoteGroupInfo>>(
                $"{_options.ApiAddress}/Api/ApiBaseInfo/SelectPreOrderOpr",
                new
                {
                    UserName = userName,
                    Password = password
                },
                null,
                "application/x-www-form-urlencoded"
            );

            return groups.Data.First(x => x.ApiPreOrderOpr.Equals(name)).ApiPreOrderOprId;
        }

        private async Task<int> GetPayConditionIdAsync(
            string userName,
            string password,
            string name)
        {
            var payConditions = await _client.SendPostRequestAsync<BaseInformationResultModel<PayConditionInfo>>(
                $"{_options.ApiAddress}/Api/ApiBaseInfo/SelectPayCondition",
                new
                {
                    UserName = userName,
                    Password = password
                },
                null,
                "application/x-www-form-urlencoded"
            );

            return payConditions.Data.First(x => x.ApiPayCondition.Equals(name)).ApiPayConditionId;
        }

        private async Task<int> GetWarrantyIdAsync(
            string userName,
            string password,
            string name)
        {
            var warranties = await _client.SendPostRequestAsync<BaseInformationResultModel<WarrantyInfo>>(
                $"{_options.ApiAddress}/Api/ApiBaseInfo/SelectGuaranty",
                new
                {
                    UserName = userName,
                    Password = password
                },
                null,
                "application/x-www-form-urlencoded"
            );

            return warranties.Data.First(x => x.ApiGuaranty.Equals(name)).ApiGuarantyId;
        }

        private async Task<int> GetDeliveryTimeKindIdAsync(
            string userName,
            string password,
            string name)
        {
            var deliveryTimes = await _client.SendPostRequestAsync<BaseInformationResultModel<DeliveryTimeKindInfo>>(
                $"{_options.ApiAddress}/Api/ApiBaseInfo/SelectDeliveryTime",
                new
                {
                    UserName = userName,
                    Password = password
                },
                null,
                "application/x-www-form-urlencoded"
            );

            return deliveryTimes.Data.First(x => x.ApiDeliveryTime.Equals(name)).ApiDeliveryTimeId;
        }

        private async Task<int> GetCreditDurationIdAsync(
            string userName,
            string password,
            string name)
        {
            var creditDurations = await _client.SendPostRequestAsync<BaseInformationResultModel<CreditDurationInfo>>(
                $"{_options.ApiAddress}/Api/ApiBaseInfo/SelectCreditDuration",
                new
                {
                    UserName = userName,
                    Password = password
                },
                null,
                "application/x-www-form-urlencoded"
            );

            return creditDurations.Data.First(x => x.ApiCreditDuration.Equals(name)).ApiCreditDurationId;
        }
    }

}