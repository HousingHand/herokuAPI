using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.DAL.Models
{
    public class AgentPropertiesSerachResponseVM
    {
        public string AgentId { get; set; }
        public string AgentTitle { get; set; }
        public string AgentLogoPath { get; set; }
        public string AgentCoverImagePath { get; set; }
        public string AgentName { get; set; }
        public string AgentPhone { get; set; }
        public string AgentJoinedDate { get; set; }
        public string AgentEmail { get; set; }
        public string AgentAddress { get; set; }
        public decimal AgentLatitude { get; set; }
        public decimal AgentLongitude { get; set; }
        public string AgentWebsiteUrl { get; set; }
        public string AgentDescription { get; set; }
        public int PropertyId { get; set; }
        public string PropertyTitle { get; set; }
        public string PropertyAddress { get; set; }
        public decimal PropertyLatitude { get; set; }
        public decimal PropertyLongitude { get; set; }
        public decimal PropertyPrice { get; set; }
        public string PriceInterval { get; set; }
        public int Rooms { get; set; }
        public decimal DepositAmt { get; set; }
        public string MoveIn { get; set; }
        public int BedRoom { get; set; }
        public int BathRoom { get; set; }
        public string ContractLength { get; set; }
        public string Furnished { get; set; }
        public string Description { get; set; }
        public decimal DistanceInMeter { get; set; }
        public decimal DistanceInKm { get; set; }
        public decimal DistanceInMiles { get; set; }
        public string AmenityIds { get; set; }
        public List<string> AmenityNamesList { get; set; }
        public List<string> PropertyImagesPath { get; set; }
        public string DefaultPropertyImage { get; set; }
    }

    public class AgentPropertiesSearchModel
    {
        public string destinationLatitude { get; set; }
        public string destinationLongitude { get; set; }
        public string locationFar { get; set; }
        public string interval { get; set; }
        public decimal budgetFrom { get; set; }
        public decimal budgetTo { get; set; }
        public int noOfRooms { get; set; }
        public string furnishedType { get; set; }
        public string amentyIds { get; set; }
        public string agentId { get; set; }

        public string userId { get; set; }
    }

    public class HFSSearchModel
    {
        public List<AgentInfoModel> AgentInfo { get; set; }
        public List<AgentPropertiesSerachResponseVM> PropertyModel { get; set; }
    }

   

}
