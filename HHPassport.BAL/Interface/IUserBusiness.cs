using HH_PassportModel;
using HHPassport.DAL.Models;
using System;
using System.Collections.Generic;

namespace HHPassport.BAL.Interface
{
    public interface IUserBusiness
    {
        int AddUpdateUser(UserModel model, string ServiceIds);
        List<UserModel> GetAllUsers(int id, string userId, string roleName, int pageIndex,
    int pageSize, string searchStr);
        List<UserModel> GetAgentByTitle(string searchStr);
        int AddUpdateUserService(UserServiceNewModel obj);
        int AddUpdateAgentInfo(AgentInfoModel model);
        // int UpdateUserProfilePic(UserProfilePicModel obj);
        AgentInfoModel GetAgentInfo(string agentId);

        /// <summary>
        ///  this method returns all the applicant's by passing agent id (nvarchar(128))
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<CustomApplicantVM> GetApplicantList(string userId, bool isDashboard, string status);
        List<CustomApplicantVM> GetTenantApplicantList(string userId, DateTime? startDate, DateTime? endDate, string searchStr = "", int pagesize = 20, int currentPage = 1, char status = 'A');

        AgentDashboardVM GetAgentDashboardData(string userId);

        List<RejectionModel> GetRejectionList();
        List<CosignerRejectionModel> GetCosignerRejectionList();
        int UpdateProfileInfo(UserProfileVM model);

        int ArchieveTanent(int ApplicantID, Char status, Char TanentType);

        List<UserModel> GetAffiliateAP(string affiliateCode, string searchStr);

        int UpdateAgentTermsAndCondition(bool isTermsChecked, bool isPEDChecked, string user_id);

        GurantorCosignerVM GetCosignerDetailByEmail(String Email_Id);
        
        //this method for deleting existing cosigner (active && tendency date <=date.now)
        int DeleteUserByEmail(string email);
       
    }
}
