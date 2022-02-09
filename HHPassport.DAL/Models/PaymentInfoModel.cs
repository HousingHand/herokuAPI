using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHPassport.DAL.Models
{
    public class PaymentInfoModel
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public decimal Amount { get; set; }
        public bool IsRecurring { get; set; }
        public string Interval { get; set; }
        public string PaymentFor { get; set; }
        public string Stripe_ProductId { get; set; }
        public string Stripe_SubscriptionId { get; set; }
        public DateTime? Stripe_SubscriptionStartDate { get; set; }
        public DateTime? Stripe_SubscriptionEndDate { get; set; }
        public string Stripe_ChargeId { get; set; }        
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
    }

    public class PaymentRequestModel
    {
        public string UserId { get; set; }
        public int ApplicantId { get; set; }
        public string StripeToken { get; set; }
        public decimal Amount { get; set; }
        public bool IsRecurring { get; set; }
        public string PaymentFor { get; set; }
        public string Interval { get; set; }
        public string Email { get; set; }
    }
}
