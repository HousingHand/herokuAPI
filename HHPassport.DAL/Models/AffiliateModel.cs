using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.DAL.Models
{
    public class AffiliateModel
    {
        public int affiliate_id { get; set; }
        public string affiliate_name { get; set; }
        public string affiliate_code { get; set; }
        public string email { get; set; }
        public string logo { get; set; }
        public string Affiliate_link { get; set; }
        public string country { get; set; }
        public bool IsActive { get; set; }
        public string description { get; set; }
        public string AP_Partners { get; set; }
        public string Uni_Partners { get; set; }
        public bool IsAPPayingFee { get; set; }
        public bool? IsAffiliateImpactPricing { get; set; }
        public string PricingType { get; set; }
        public decimal? FixedMonthlyPrice { get; set; }
        public decimal? FixedOneTimePrice { get; set; }
        public decimal? PercentMonthlyPrice { get; set; }
        public decimal? PercentOneTimePrice { get; set; }
        public bool IsDoc { get; set; }
        public bool ProofOfAddress { get; set; }
        public bool PhotoId { get; set; }
        public bool RegistrationForm { get; set; }
        public bool ProofOfStudy { get; set; }
        public bool ProofOfIncome { get; set; }
        public bool ProofOfNI { get; set; }
        public bool? IsMoreField { get; set; }
        public string AnyProofId { get; set; }
        public string OtherProofId { get; set; }
        public bool IsCosigner { get; set; }
        public bool IsAffiliateRebate { get; set; }
        public bool IsLimitedUse { get; set; }
        public int No_Of_Max_Uses { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public List<APPartners> APPPartnerList { get; set; }
        public List<UNIPartners> UniPartnerList { get; set; }
        public int NoOfCodeUsed { get; set; }

    }
    public class APPartners
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UNIPartners
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

