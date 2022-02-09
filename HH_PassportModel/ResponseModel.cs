using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH_PassportModel
{
    public class ResponseModel<T>
    {
        public string code { get; set; }
        public string message { get; set; }
        public T data { get; set; }
        public string token { get; set; }
    }

    public class loginTenantResponse
    {
        public List<docs> documents { set; get; }
        public DateTime datetime_joined { get; set; }
        public string  _id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int? __v { get; set; }

        public account_info account_info { get; set; }
        public payment_info payment_info { get; set; }
        public quote_info quote_info { get; set; }
        public application application { get; set; }


    }

    public class account_info
    {
        public string ref_no { get; set; }
        public bool? is_ap_missing { get; set; }
        public bool? is_fast_tracked { get; set; }
        public string country_code { get; set; }
        public string email { get; set; }
        public int? type { get; set; }
        public int? status { get; set; }
        public string affiliate { get; set; }
        public string agent_id { get; set; }
        public bool phone_verified { get; set; }
        public string webform { get; set; }
        public string integrator { get; set; }
        public int source { get; set; }
        public string sponsorship { get; set; }
        public int algolia_obj_id_new { get; set; }
        public int ac_id { get; set; }
    }

    public class payment_info
    {
        public int? total_amount_paid { get; set; }
        public int? status { get; set; }
        public int? no_of_times_paid { get; set; }
        public int? remaining_balance { get; set; }
        public int? last_paid_amount { get; set; }
        public bool discounted { get; set; }
        public int? is_subscription { get; set; }
        public int? payment_incrementor { get; set; }
        public int? failed_incrementor { get; set; }
    }

    public class quote_info
    {
        public int? quote { get; set; }
        public decimal quote_monthly { get; set; }
        public decimal quote_monthly_subscription { get; set; }
        public int? lump_sum_amount { get; set; }
        public decimal recurring_first_payment_amount { get; set; }
        public decimal recurring_payments_amount { get; set; }
        public int? rebate { get; set; }
        public int? status { get; set; }
        public int? is_special_pricing { get; set; }
        public string ref_no { get; set; }
    }

    public class application
    {


        public string stage { get; set; }
        public string step { get; set; }
        //public int? enum { get; set; }
        public DateTime last_status_update { get; set; } //datetime
        public bool is_defaulted { get; set; }
        public bool is_fee_arrear { get; set; }
    }

    public class tenancy_details_confirmed_by
    {
        public DateTime date_confirmed { get; set; }
    }

    public class verification {
    
        public List<tenant> tenants { get; set; }
    }
    public class tenant
    {
        public int? status { get; set; }
        public Array comments { get; set; }     //   [],
        public bool tenancy_only { get; set; }
        public int? fully_managed_option { get; set; }
        public int? deposit_type { get; set; }
        public Array documents { get; set; } //"documents": []
    }
    public class pre_payment_reminder_emails
    {
        public bool three_days { get; set; }
        public bool seven_days { get; set; }
        public bool one_hour { get; set; }
    }
    public class pre_quote_reminder_emails : pre_payment_reminder_emails
    {
        //    "three_days": false,
        //      "seven_days": false,
        //      "one_hour": false
    }
    public class time_stamps
    {
        public DateTime last_logged_in_date { get; set; }
        public DateTime last_update_date { get; set; }
        public DateTime last_update_date_dashboard { get; set; }
    }
    public class priority_info
    {
        public string status { get; set; }
        public int? points { get; set; }
        public int? delay { get; set; }
    }
    public class future_quote_info
    {
        public int? quote { get; set; }
        public int? quote_monthly_subscription { get; set; }
        public int? quote_monthly { get; set; }
        public int? lump_sum_amount { get; set; }
        public int? recurring_first_payment_amount { get; set; }
        public int? recurring_payments_amount { get; set; }
        public int? rebate { get; set; }
        public int? status { get; set; }
        public int? is_special_pricing { get; set; }
        public int? rent { get; set; }
    }

    public class personal_info
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string dialing_code { get; set; }
        public string phone_number { get; set; }        
        public DateTime date_of_birth { get; set; } //2011-12-14",
        public string ccj { get; set; }
        public nationality nationality { get; set; }
        public place_of_study place_of_study { get; set; }
        public type_of_study type_of_study { get; set; }
        public year_of_study year_of_study { get; set; }    
    }
    public class nationality
    {
        public string text { get; set; }
        public int? type { get; set; }
    }
    public class place_of_study
    {
        public string _id { get; set; }
        public string text { get; set; }
    }
    public class type_of_study
    {
        public string _id { get; set; }
        public string text { get; set; }
    }

    public class year_of_study
    {
        public string type { get; set; }
        public string text { get; set; }
    }
    public class application_info
    {
        
        public ap_details ap_details { get; set; }

    }

    public class ap_details
    {
        public ap ap { get; set; }
        public property property { get; set; }
        public rent rent { get; set; }

        public Array quotes { get; set; } //[],
        public Array docs { get; set; }


    }

    public class ap
    {
        public string _id { get; set; }
        public string accomType { get; set; }
        public string name { get; set; }
        public string agent_name { get; set; }
        public string telephone { get; set; }
    }
    public class property
    {
        public string address { get; set; }
        public county county { get; set; }
        public string postcode { get; set; }
    }
    public class county
    {
        public string text { get; set; }
        public string _id { get; set; }
    }
    public class rent
    {
        public int fee { get; set; }
        public string duration { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public DateTime guarantor_end_date { get; set; }
        public renewal renewal { get; set; }

    }
    public class renewal
    {
        public bool with_in_93_days { get; set; }
        //public bool 3_months { get; set; }
        //public bool 6_months { get; set; }
        //public bool 9_months { get; set; }
    }

    //public class docs
    //{
    //    public int? status {get; set;}
    //  public int? uploaded_by { get;set;}
    //  public int? type { get;set;}
    //  public string url { get; set; }
    //}
    
}
