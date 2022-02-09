using HHPassport.DAL.Models;
using System.Collections.Generic;

namespace HHPassport.BAL.Interface
{
    public interface IAffiliateBusiness
    {
        List<AffiliateModel> GetAffiliatesList(int AffiliateId);

        AffiliateModel GetAffiliateSettings(string AffiliateCode);

        int AddUpdateAffiliate(AffiliateModel model);

        int ActivateDeactivateAffiliate(int AffiliateId);

    }
}
