using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH_PassportModel
{
  public class KeyValidatorModel
    {
        public string user_id { get; set; }
        public string Sandbox_key { get; set; }
        public string Prod_key { get; set; }

        public string email { get; set; }

        public bool IsProduction { get; set; }
    }
}
