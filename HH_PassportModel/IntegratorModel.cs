using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH_PassportModel
{
    public class IntegratorModel
    {
        public int Integrator_Id { get; set; }
        public string User_Id { get; set; }
        public string Name { get; set; }
        public string Contact_no { get; set; }
        public string Email { get; set; }
        public string Prod_key { get; set; }
        public string Sandbox_key { get; set; }
        public bool? is_active { get; set; }
        public DateTime? createdAt { get; set; }
        public string createdBy { get; set; }
        public DateTime? updatedAt { get; set; }
        public string updatedBy { get; set; }
    }
}
