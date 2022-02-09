using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH_PassportModel
{  
    public class TenantResponseModel
    {
        public PersonalInfo personal_info { get; set; }
        public AccountInfo account_info { get; set; }
        public ApplicationInfo application_info { get; set; }
    }

    public class VerficationModel
    {
        public bool status { get; set; }
        public string text { get; set; }
    }


}
