namespace Summary.IdealCrm.Services
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using Core.Data;
    using Core.Mvc.Utilities;
    using Core.Workflows;
    using Summary.IdealCrm;
    using Summary.IdealCrm.Settings;

    public interface IProductService
    {
        Task<ProductInfo> GetDetailsByAsync(string userName, string password, ProductSearchKind searchKind, string filter);
    }

    public class ProductService : IProductService
    {
        private readonly HttpRequestClient _client;
        private readonly IdealCrmSettings _options;
        private readonly IDbConnectionAccessor _db;

        public ProductService(
            HttpRequestClient client,
            IOptions<IdealCrmSettings> options,
            IDbConnectionAccessor db)
        {
            _client = client;
            _options = options.Value;
            _db = db;
        }

        public async Task<ProductInfo> GetDetailsByAsync(
            string userName,
            string password,
            ProductSearchKind searchKind,
            string filter)
        {
            var data = new Dictionary<string, string>
            {
                { "UserName", userName },
                { "Password", password }
            };

            switch (searchKind)
            {
                case ProductSearchKind.Id : data.Add("ApiProductId", filter); break;
                case ProductSearchKind.Code : data.Add("ApiPrdCode", filter); break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchKind));
            }

            var product_response = await _client.SendPostRequestAsync<BaseInformationResultModel<ProductInfo>>(
                $"{_options.ApiAddress}/Api/ApiProduct/Select",
                data,
                null,
                "application/x-www-form-urlencoded");

            if (product_response.Status == Status.Success)
            {
                if (product_response.Data.Any()) return product_response.Data.First();
                else
                {
                    using var connection = _db.CreateConnection();
                    connection.ConnectionString = _options.ConnectionString;

                    await connection.OpenAsync();

                    using var transaction = connection.BeginTransaction();

                    var query = $@"select
                    p.PrdCode as ApiPrdCode,
                    p.PrdGroupID as ApiPrdGroupID, p.ProductID as ApiProductID,
                    p.PrdName as ApiPrdName
                    from
                    dbo.WSProducts as p
                    where p.PrdLinkAccPrdCode like N'%{filter}%';";

                    var product = await connection.QueryFirstOrDefaultAsync<ProductInfo>(query, null, transaction);

                    return product ?? throw new WorkflowException(
                        $"محصول «{filter}» در CRM ایده ال پیدا نشد",
                        null,
                        query,
                        $"در CRM ایده ال محصول «{filter}» تعریف نشده است یا کد محصول حاوی کاراکتر نامعتبر است. برای مرتفع شدن خطاء کافیست کد محصول یکی شوند سپس درخواست مجدداً برای همگام سازی ارسال شود."
                    );
                }
            }
            else
                throw new NotImplementedException(product_response.Message);
        }
    }
}