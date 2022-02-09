using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.DAL.Models
{
    public class RewardsModel
    {
        public int reward_id { get; set; }
        public string title { get; set; }
        public string reward_picture { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string code { get; set; }
        public bool? is_active { get; set; }
        public string created_by { get; set; }
        public DateTime? created_date { get; set; }
        public string updated_by { get; set; }
        public DateTime? updated_date { get; set; }
    }
}
