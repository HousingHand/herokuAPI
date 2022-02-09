using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.DAL.Models
{
    public class ServiceModel
    {
        public int serviceid { get; set; }
        public string service_name { get; set; }
        public string service_image { get; set; }

        public string service_description { get; set; }
        public decimal? cost { get; set; }
        public bool? is_active { get; set; }
        public string service_for { get; set; }
        public string free_with { get; set; }
        public DateTime? created_on { get; set; }
        public string created_by { get; set; }
        public DateTime? last_modified_on { get; set; }
        public string last_modified_by { get; set; }
    }
}
