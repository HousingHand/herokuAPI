using HHPassport.DAL.Models;
using System.Collections.Generic;

namespace HHPassport.BAL.Interface
{
    public interface INotificationsBusiness
    {
        int AddUpdateNotification(NotificationModel model);
        List<NotificationModel> GetAllNotifications();

        List<MessageModel> GetChat(string fromUserId, string toUserId);
        int ChangeStatus(int notificationId, bool status);
        int SaveChatMessage(SaveMessageModel model);
       // SaveMessageModel GetuserInfo(string userid);
        List<ApplicantUserModel> GetApplicantUsers(string userId);
        //List<ApplicantUserModel> GetUsers(string userId);
        int UpdateMessageAsRead(string userId);
        List<UserChatHistoryVM> GetUnReadMsg(string toUserId, bool IsMarkAsRead);
    }
}
