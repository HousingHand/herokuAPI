using System;
using System.Collections.Generic;
using System.Data.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.DAL.Models
{
    public class PropertyModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public decimal Price { get; set; }
        public string PriceInterval { get; set; }
        public decimal DepositAmt { get; set; }
        public int Rooms { get; set; }
        public string Furnished { get; set; }
        public DateTime? MoveIn { get; set; }
        public int BedRoom { get; set; }
        public int BathRoom { get; set; }
        public string ContractLength { get; set; }
        public string AgentId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public bool IsBusy { get; set; }
        public DateTime? BusyTill { get; set; }

        public string AmentiesStr { get; set; }
        public string ImagesPath { get; set; }
    }

    public class PropertySearchModel
    {
        public string UserId { get; set; }
        public string LocationName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string FarFrom { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public string PriceInterval { get; set; }
        public int Rooms { get; set; }
        public string Furnished { get; set; }
        public string RequiredTags { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

    }

    public class AgentLeadModel
    {
        public string LeadStatus { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string UserId { get; set; }
        public string LocationName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string FarFrom { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public string PriceInterval { get; set; }
        public int Rooms { get; set; }
        public string Furnished { get; set; }
        public string RequiredTags { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public string ApprovedLevel { get; set; }
        public string Beds { get; set; }


    }

    public class AgentResponseLeadModel
    {
        public string LeadStatus { get; set; }

        public string name { get; set; }

        public string email { get; set; }
        public string Gender { get; set; }
        public string address { get; set; }

        public string nationality { get; set; }
        public string dateofBirth { get; set; }
        public string Age { get; set; }
        public string ProfilePic { get; set; }
        public string description { get; set; }
        public string createdOn { get; set; }
        public string policyNumber { get; set; }
        public string CustomerType { get; set; }

        public string UserId { get; set; }
        public string LocationName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string FarFrom { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public string PriceInterval { get; set; }
        public int Rooms { get; set; }
        public string Furnished { get; set; }
        public string RequiredTags { get; set; }
        public string Notes { get; set; }
        public DateTime LeadDate { get; set; }
        public DateTime SearchedDate { get; set; }

        public string Amenities { get; set; }

        public string ApprovedLevel { get; set; }
        public string Beds { get; set; }

        public string TenenancyStartDate { get; set; }
        public string TenenancyEndDate { get; set; }
        public string Duration { get; set; }
        public string PhoneNumber { get; set; }
        public decimal RentAmount { get; set; }

        public string RentType { get; set; }
        public string TenenancyStartDateStr { get; set; }
        public string TenenancyEndDateStr { get; set; }

        public string CustomerTypeStr { get; set; }

        public string iStatus { get; set; }

    }

    public class AgentPreferencesModel
    {
        public string AgentID { get; set; }

        public bool IsStudent { get; set; }

        public bool IsWorkingProfessional { get; set; }
        public string NoofRoom { get; set; }
        public string LocationName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string FarFrom { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public string PriceInterval { get; set; }
        public string Furnished { get; set; }
        public string RequiredTags { get; set; }

        public string CreatedBy { get; set; }

    }

    public class ConvertedCustomerModel
    {

        public string AgentID { get; set; }
        public string ApplicantId { get; set; }
        public string LeadStatus { get; set; }
        public string CustomerType { get; set; }
        public string RentAmount { get; set; }
        public string RentType { get; set; }
        public string TenenancyStartDate { get; set; }
        public string TenenancyEndDate { get; set; }

    }

    public class AgentHfsPrefernceModel
    {
        public int ID { get; set; }
        public string AgentId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string WebsiteUrl { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string LogoPath { get; set; }
        public string CoverImagePath { get; set; }
        public bool? IsStudent { get; set; }
        public bool? IsWorkingProfessional { get; set; }
        public string NoOfRoom { get; set; }
        public string LocationName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string FarFrom { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
        public string PriceIterval { get; set; }
        public string AmenityIds { get; set; }
        public string Furnished { get; set; }
        public string AmenityNames { get; set; }
    }
    public class AgentStatsModel
    {
        public string AgentId { get; set; }
        public int TotalLeads { get; set; }
        public int NewLeads { get; set; }
        public int MissedLeads { get; set; }
        public int ConvertedLeads { get; set; }
        public int SearchHits { get; set; }
        public int AgencyClicks { get; set; }
        public int PropertyViews { get; set; }
        public int Properties { get; set; }

    }
}
