using HHPassport.DAL.Models;
using System.Collections.Generic;

namespace HHPassport.BAL.Interface
{
    public interface IRewardsBusiness
    {
        int AddUpdateRewards(RewardsModel model);
        List<RewardsModel> GetAllRewardList();
        int ChangeStatus(int rewardId, bool status);
    }
}
