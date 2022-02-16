using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.DAL.Enums
{
    public static class EnumHelper
    {
        public enum RolesEnum
        {
            Admin,
            Applicant,
            Agent,
            PBSA,
            Cosigner,
            Integrator
        }
        public enum DirectoryPathEnum
        {
            Upload,
            ServiceImage,
            RewardImage,
            GurantorApplicantDocument,
            IdentityImage,
            Agent,
            Logo,
            Cover,
            Properties,
            ProfilePic,
            Documents,
            ChatDocument, 
            HubSpotLog,
            Affiliate,
            ErrorLogs
        }
        public enum APIPath
        {
            #region "account path"
            [Description("/api/Account/Register")]
            Register,
            [Description("/token")]
            Login,
            [Description("/api/Account/Logout")]
            Logout,
            [Description("/api/Account/ChangePassword")]
            ChangePassword,
            [Description("/api/Account/ForgetPassword")]
            ForgetPassword,
            [Description("/api/Account/ResetPassword")]
            ResetPassword,
            [Description("/api/Account/UpdateUserName")]
            UpdateUserName,
            #endregion

            #region "service path"
            [Description("/api/Service/AddUpdateService")]
            AddUpdateService,
            [Description("/api/Service/GetAllServices")]
            GetAllServices,
            [Description("/api/Service/ChangeStatus")]
            ChangeServiceStatus,
            #endregion

            #region "amenities path"
            [Description("/api/Amenities/AddUpdateAmenties")]
            AddUpdateAmenties,
            [Description("/api/Amenities/GetAllAmenties")]
            GetAllAmenties,
            [Description("/api/Amenities/ChangeStatus")]
            ChangeAmenitiesStatus,
            #endregion

            #region "rewards path"
            [Description("/api/Reward/AddUpdateReward")]
            AddUpdateReward,
            [Description("/api/Reward/GetAllRewardList")]
            GetAllRewardList,
            [Description("/api/Reward/ChangeStatus")]
            ChangeRewardStatus,
            #endregion

            #region "notifications path"
            [Description("/api/Notifications/AddUpdateNotification")]
            AddUpdateNotification,
            [Description("/api/Notifications/GetAllNotificationList")]
            GetAllNotificationList,
            [Description("/api/Notifications/ChangeStatus")]
            ChangeNotificationStatus,
            #endregion

            #region "user path"
            [Description("/api/User/GetUsersByRoleName")]
            GetUsersByRoleName,
            [Description("/api/User/UpdateUserInfo")]
            UpdateUserInfo,

            [Description("/api/User/GetAgentByTitle")]
            GetAgentByTitle,
            
            #endregion

            #region "university path"
            [Description("/api/University/AddUpdateUniversity")]
            AddUpdateUniversity,
            [Description("/api/University/GetAllUniversities")]
            GetAllUniversities,
            [Description("/api/University/ChangeStatus")]
            ChangeUniversityStatus,
            #endregion

            #region "student of studying path"
            [Description("/api/StudentStudying/AddUpdateStudentStudying")]
            AddUpdateStudentStudying,
            [Description("/api/StudentStudying/GetAllStudentStudyingList")]
            GetAllStudentStudyingList,
            [Description("/api/StudentStudying/ChangeStatus")]
            ChangeStudentStudyingStatus,
            #endregion

            #region "course path"
            [Description("/api/Course/AddUpdateCourse")]
            AddUpdateCourse,
            [Description("/api/Course/GetAllCourseList")]
            GetAllCourseList,
            [Description("/api/Course/ChangeStatus")]
            ChangeCourseStatus,
            #endregion

            #region "agent properties api path"
            [Description("/api/User/AddUpdateAgentProperty")]
            AddUpdateAgentProperty,
            [Description("/api/User/GetAgentProperties")]
            GetAgentProperties,
            [Description("/api/User/ChangeStatus")]
            ChangePropertyStatus,
            #endregion

            #region "Gurantor"
            [Description("/api/Gurantor/GetGurantorFees")]
            GetGurantorFees,
            [Description("/api/Gurantor/UpdateGurantortFees")]
            UpdateGurantortFees,
            #endregion

            #region "Integrator path"
            [Description("/tenant/AddUpdate")]
            AddUpdateIntegrator           ,
            [Description("/tenant/GetIntegrators")]
            GetIntegrators,
            [Description("/api/Account/Register")]
            IntegratorRegister,
            #endregion

            #region "Affiliate path"
            [Description("/api/Affiliate/GetAffiliatesList")]
            GetAffiliatesList,
            [Description("/api/Affiliate/AddUpdateAffiliate")]
            AddUpdateAffiliate,
            [Description("/api/Affiliate/ActivateDeactivateAffiliate")]
            ActivateDeactivateAffiliate,
            #endregion

            [Description("/api/Account/GetHashPassword")]
            GetHashPassword,
        }
        public static string GetDescription<T>(this T enumValue)
           where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return description;
        }
    }
}
