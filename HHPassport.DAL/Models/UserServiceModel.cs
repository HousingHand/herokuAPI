using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.DAL.Models
{
    public class UserServiceModel
    {      
        public int? serviceId { get; set; }
        public string service_name { get; set; }
        public decimal? serviceCost { get; set; }
        public string serviceImage { get; set; }
        public string slug { get; set; }

        public string servicedescription { get; set; }
    }

    public class UserAllServiceModel
    {
        public int? serviceId { get; set; }
        public string service_name { get; set; }
        public decimal? serviceCost { get; set; }
        public string serviceImage { get; set; }
        public string slug { get; set; }

        public string user_id { get; set; }

        public bool isServiceSelected { get; set; }

        public string serviceDescription { get; set; }

        public string policy_number { get; set; }

        public string coverUpto { get; set; }

        public string lastUpdated { get; set; }

         
    }
}
