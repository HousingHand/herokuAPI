using System;
using System.Collections.Generic;

namespace HHPassport.ClassicAPI.Models
{
    // Models returned by AccountController actions.

    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }

    public enum DocType
    {
        TenantPhotoID = 1,
        TenantProofOfStudy = 2,
        CosignerPhotoID = 3,
        CosignerProofOfAddress = 4,
        CosignerProofOfNI = 9,
        TenantProofOfNi = 10,
        AST = 5,
        GD = 6,
        Contract = 7,
        Others = 8

    }

    public enum DocUploadBy
    {
        UplaodedintheCRM = 1,
        Uploadedbythetenant = 2
    }
}
