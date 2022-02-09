using System;
using System.Collections.Generic;

namespace HHPassport.DAL.Models
{
    public class MessageModel
    {
        public string FromId { get; set; }
        public string ToId { get; set; }
        public int MessageType { get; set; }
        public string MessageText { get; set; }
        public DateTime DateSent { get; set; }
        public bool IsRead { get; set; }
        public string SendDateStr { get; set; }
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }

    }

    public class SaveMessageModel
    {
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string MessageText { get; set; }
        public string MessageType { get; set; }
    }

    public class ApplicantUserModel
    {
        public string UserId { get; set; }
        public string UserType { get; set; }
        public string AgentName { get; set; }
        public string Photo { get; set; }
        public int MessageCount { get; set; }
        public int TotalmessageCount { get; set; }
    }

    public class ChatModel
    {
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string MessageType { get; set; }
        public string MessageText { get; set; }
        public string IsRead { get; set; }
        public string SendDateStr { get; set; }
    }

    public class UserChatHistoryVM
    {
        public string FromId { get; set; }
        public string Name { get; set; }
        public int UnreadCount { get; set; }
        public List<ChatModel> ChatHistory { get; set; }
    }

    public class EmailModel
    {
        public string userId{ get; set; }
        public string name{ get; set; }
        public string email{ get; set; }
        public string userType{ get; set; }
        public string count{ get; set; }
    }
}
