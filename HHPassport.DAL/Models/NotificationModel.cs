using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.DAL.Models
{
    public class NotificationModel
    {
        public int notification_id { get; set; }
        public string event_name { get; set; }
        public string notification_text { get; set; }
        public bool? is_active { get; set; }
        public string mode { get; set; }
        public string created_by { get; set; }
        public DateTime? created_date { get; set; }
        public string updated_by { get; set; }
        public DateTime? updated_date { get; set; }
    }
}
