using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH_PassportModel
{
    public class tenantLoginModel
    {
        public string email { get; set; }
        public string password { get; set; }

    }

    public class FindByEmailModel
    {
        public string tenantId { get; set; }
        public string token { get; set; }
    }

    public class tenantUpdateModel
    {
        public PersonalInfo personal_info { get; set; }
    }
}
