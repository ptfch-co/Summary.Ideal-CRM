namespace Summary.IdealCrm
{
    using System;
    using System.Collections.Generic;

    public class BaseResultModel
    {
        public string Data { get; set; }
        public Status Status { get; set; }
        public string Message { get; set; }
    }

    public enum Status
    {
        Success,
        Error
    }

    public class CreateIdentityResponseInfo
    {
        public object OrganizationId { get; set; }
        public object PersonId { get; set; }
    }

    public enum IdentityType
    {
        Person,
        Organization
    }

    public class BaseModelToRequestInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class BaseInformationResultModel<T>
    {
        public IList<T> Data { get; set; }
        public Status Status { get; set; }
        public string Message { get; set; }
    }

    public class CreateOrganizationRequestInfo : BaseModelToRequestInfo
    {
        public string Subject { get; set; }
        public string Type { get; internal set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string IdentityType { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Presentation { get; set; }
        public string Group_1 { get; internal set; }
        public string NationalId { get; set; }
        public string EconomicCode { get; set; }
        public string RegisterNumber { get; set; }
        public string PostalCode { get; set; }
        public string PostalBox { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AssignTo { get; set; }
        public string CreatorUser { get; set; }
        public string Campaign { get; set; }
    }

    public class CreatePersonRequestInfo : BaseModelToRequestInfo
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Mobile { get; set; }
        public string Job { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string NationalCode { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string CreatorUser { get; set; }
        public string CompanyId { get; set; }
    }

    public class GetConversationStatusReponseModel
    {
        public IList<ConversationStatusInfo> Data { get; set; }
    }

    public class ConversationStatusInfo
    {
        public int ApiConversationStatusID { get; set; }
        public int ApiStatusOrder { get; set; }
        public string ApiStatus { get; set; }
        public int ApiProgressPercent { get; set; }
        public int ApiGroupId { get; set; }
        public string ApiConversationStatusGroup { get; set; }
    }

    public class GetProjectDetailsReponseModel
    {
        public IList<ProjectInfo> Data { get; set; }
    }

    public class ProjectInfo
    {
        public int ApiProjectID { get; set; }
        public int ApiPrjCompanyId { get; set; }
        public string ApiPrjCompany { get; set; }
        public string ApiPrjTitle { get; set; }
        public string ApiPrjPostFix { get; set; }
        public string ApiPrjDesc { get; set; }
        public string ApiPrjStartDateTime { get; set; }
        public int? ApiPrjGradeId { get; set; }
        public string ApiPrjGrade { get; set; }
        public int? ApiPrjPriorityId { get; set; }
        public string ApiPrjPriority { get; set; }
        public int? ApiPrjGroupId { get; set; }
        public string ApiPrjGroup { get; set; }
        public int ApiPrjcnvsStatusGroupId { get; set; }
        public string ApiPrjcnvsStatusGroup { get; set; }
        public int? ApiPrjCmpPresentationId { get; set; }
        public string ApiPrjCmpPresentation { get; set; }
        public bool? ApiPrjIsFinished { get; set; }
        public DateTime? ApiPrjFinishedDateTime { get; set; }
    }

    public class GetProjectGradeResponseModel
    {
        public IList<ProjectGradeInfo> Data { get; set; }
    }

    public class ProjectGradeInfo
    {
        public int ApiProjectGradeID { get; set; }
        public string ApiProjectGrade { get; set; }
    }

    public class GetProjectGroupResponseModel
    {
        public IList<ProjectGroupInfo> Data { get; set; }
    }

    public class ProjectGroupInfo
    {
        public int ApiProjectGroupID { get; set; }
        public string ApiProjectGroup { get; set; }
    }

    public class GetPriorityResponseModel<T> where T : BasePriorityInfo
    {
        public IList<T> Data { get; set; }
    }

    public abstract class BasePriorityInfo
    {
        public string ApiPriority { get; set; }
        public string ApiPriorityDesc { get; set; }
    }

    public class ProjectPriorityInfo : BasePriorityInfo
    {
        public int ApiProjectPriorityID { get; set; }
    }

    public class ConversationPriorityInfo : BasePriorityInfo
    {
        public int ApiConversationPriorityID { get; set; }
    }

    public class GetConversationTypesResponseModel
    {
        public IList<ConversationTypeInfo> Data { get; set; }
    }

    public class ConversationTypeInfo
    {
        public int ApiConversationTopicsID { get; set; }
        public string ApiTopic { get; set; }
    }

    public class GetUsersResponseModel
    {
        public IList<UserInfo> Data { get; set; }
    }

    public class UserInfo
    {
        public int ApiUserId { get; set; }
        public string ApiFName { get; set; }
        public string ApiLName { get; set; }
        public string ApiFullName { get; set; }
        public string ApiUserName { get; set; }
        public string Address { get; set; }
        public int ApiUserRollId { get; set; }
        public string ApiMobile { get; set; }
        public string ApiUserRollName { get; set; }
    }

    public class GetPersonIdResponseModel
    {
        public GetPersonIdInfo Data { get; set; }
    }

    public class GetPersonIdInfo
    {
        public string CompanyPersonID { get; set; }
        public string PrsCompanyId { get; set; }
    }

    public class GetPersonDetilsResponseModel
    {
        public IList<PersonInfo> Data { get; set; }
    }

    public class PersonInfo
    {
        public string ApiCompanyPersonID { get; set; }
        public string ApiPrsCompanyId { get; set; }
        public string ApiPrsCompany { get; set; }
        public string ApiPrsLName { get; set; }
        public string ApiPrsFName { get; set; }
        public string ApiPrsTitleId { get; set; }
        public string ApiPrsTitle { get; set; }
        public string ApiPersonName { get; set; }
        public string ApiPrsJobId { get; set; }
        public string ApiPrsJob { get; set; }
        public string ApiPrsTypeId { get; set; }
        public string ApiPrsType { get; set; }
        public string ApiPrsGroupId { get; set; }
        public string ApiPrsGroup { get; set; }
        public string ApiPrsSexId { get; set; }
        public string ApiPrsSex { get; set; }
        public string ApiPrsEducationId { get; set; }
        public string ApiPrsEducation { get; set; }
        public string ApiPrsPreTel { get; set; }
        public string ApiPrsTel { get; set; }
        public string ApiPrsTelUpTo { get; set; }
        public string ApiPrsTelDesc { get; set; }
        public string ApiPrsTelII { get; set; }
        public string ApiPrsFax { get; set; }
        public string ApiPrsFaxDesc { get; set; }
        public string ApiPrsMobile { get; set; }
        public string ApiPrsWebSite { get; set; }
        public string ApiPrsEmail { get; set; }
        public string ApiPrsEmailII { get; set; }
        public string ApiPrsCountryId { get; set; }
        public string ApiPrsCountry { get; set; }
        public string ApiPrsProvinceId { get; set; }
        public string ApiPrsProvince { get; set; }
        public string ApiPrsCityId { get; set; }
        public string ApiPrsCity { get; set; }
        public string ApiPrsAddress { get; set; }
        public string ApiPrsAddressDesc { get; set; }
        public string ApiPrsZipCode { get; set; }
        public string ApiPrsPostBox { get; set; }
        public string ApiPrsNationalCode { get; set; }
        public string ApiPrsIdentityNumber { get; set; }
        public string ApiPrsFatherName { get; set; }
        public string ApiPrsBirthDate { get; set; }
        public string ApiPrsBirthPlace { get; set; }
        public string ApiPrsIsMarried { get; set; }
        public string ApiPrsMarriageDate { get; set; }
        public string ApiPrsSkill { get; set; }
        public string ApiPrsStudyField { get; set; }
        public string ApiPrsInteresting { get; set; }
        public string ApiPrsSpecialPoint { get; set; }
        public string ApiPrsDescription { get; set; }
        public string ApiPrsDepartmentId { get; set; }
        public string ApiPrsDepartment { get; set; }
        public string ApiPrsWorkingOut { get; set; }
        public string ApiPrsBirthDateTime { get; set; }
        public string ApiPrsMarriageDateTime { get; set; }
        public int ApiUserId { get; set; }
    }

    public class GetProjectIdResponseModel
    {
        public GetProjectIdInfo Data { get; set; }
    }

    public class GetProjectIdInfo
    {
        public string ProjectID { get; set; }
        public string PrjCompanyId { get; set; }
    }

    public class PrintFormatInfo
    {
        public int ApiPrintFormatID { get; set; }
        public string ApiTitle { get; set; }
    }

    public class QuoteStatusInfo
    {
        public int ApiPreOrderStatusId { get; set; }
        public string ApiPreOrderStatus { get; set; }
    }

    public class QuoteGroupInfo
    {
        public int ApiPreOrderOprId { get; set; }
        public string ApiPreOrderOpr { get; set; }
    }

    public class PayConditionInfo
    {
        public int ApiPayConditionId { get; set; }
        public string ApiPayCondition { get; set; }
    }

    public class WarrantyInfo
    {
        public int ApiGuarantyId { get; set; }
        public string ApiGuaranty { get; set; }
    }

    public class DeliveryTimeKindInfo
    {
        public int ApiDeliveryTimeId { get; set; }
        public string ApiDeliveryTime { get; set; }
    }

    public class CreditDurationInfo
    {
        public int ApiCreditDurationId { get; set; }
        public string ApiCreditDuration { get; set; }
    }

    public class CreateQuoteResponseModel
    {
        public QuoteCreateInfo Data { get; set; }
        public Status Status { get; set; }
        public string Message { get; set; }
    }

    public class QuoteCreateInfo
    {
        public int PreOrderId { get; set; }
        public int PreOrderNumber { get; set; }
    }

    public class ProductInfo
    {
        public int ApiProductID { get; set; }
        public int ApiPrdGroupID { get; set; }
        public string ApiPrdGroup { get; set; }
        public string ApiPrdCode { get; set; }
        public string ApiPrdName { get; set; }
    }

    public enum ProductSearchKind
    {
        Id,
        Code
    }

    public class IdentityInfo
    {
        public string ApiCmpCampaignNames { get; set; }
        public string ApiCmpCampaignIds { get; set; }
    }

    public class IdentityResponseInfo
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Number { get; set; }
        public string IdentityType { get; set; }
        public string Mobile { get; set; }
        public DateTime LastModify { get; set; }
    }
}