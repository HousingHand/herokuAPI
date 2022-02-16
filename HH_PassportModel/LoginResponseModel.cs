using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH_PassportModel
{
    //class LoginResponseModel
    //{
    //}

    public class AccountInfo
    {
        [DefaultValue("")]
        public string ref_no { get; set; }
        public bool is_ap_missing { get; set; }
        public bool is_fast_tracked { get; set; }
        [DefaultValue("")]
        public string country_code { get; set; }
        [DefaultValue("")]
        public string email { get; set; }
        [DefaultValue("")]
        public string password { get; set; }
        public int type { get; set; }
        public int status { get; set; }
        public object affiliate { get; set; }
        [DefaultValue("")]
        public string agent_id { get; set; }
        public bool phone_verified { get; set; }
        public object webform { get; set; }
        [DefaultValue("")]
        public string integrator { get; set; }
        public int source { get; set; }
        [DefaultValue("")]
        public string sponsorship { get; set; }
        [DefaultValue("")]
        public string algolia_obj_id_new { get; set; }
        public int ac_id { get; set; }
    }

    public class PaymentInfo
    {
        public int total_amount_paid { get; set; }
        public int status { get; set; }
        public int no_of_times_paid { get; set; }
        public int remaining_balance { get; set; }
        public int last_paid_amount { get; set; }
        public bool discounted { get; set; }
        public int is_subscription { get; set; }
        public int payment_incrementor { get; set; }
        public int failed_incrementor { get; set; }
    }

    public class QuoteInfo
    {
        public int quote { get; set; }
        public double quote_monthly { get; set; }
        public double quote_monthly_subscription { get; set; }
        public int lump_sum_amount { get; set; }
        public double recurring_first_payment_amount { get; set; }
        public double recurring_payments_amount { get; set; }
        public int rebate { get; set; }
        public int status { get; set; }
        public int is_special_pricing { get; set; }
        [DefaultValue("")]
        public string ref_no { get; set; }
    }

    public class TenancyDetailsConfirmedBy
    {
        public DateTime date_confirmed { get; set; }
    }

    public class Application
    {
        public TenancyDetailsConfirmedBy tenancy_details_confirmed_by { get; set; }
        [DefaultValue("")]
        public string stage { get; set; }
        [DefaultValue("")]
        public string step { get; set; }
        public int @enum { get; set; }
        public DateTime last_status_update { get; set; }
        public bool is_defaulted { get; set; }
        public bool is_fee_arrear { get; set; }
    }

    public class Tenant
    {
        public int status { get; set; }
        public List<object> comments { get; set; }
        public bool tenancy_only { get; set; }
        public int fully_managed_option { get; set; }
        public int deposit_type { get; set; }
        public List<object> documents { get; set; }
    }

    public class Ap
    {
        public int? status { get; set; }
        public List<object> comments { get; set; }
        public List<object> documents { get; set; }
    
        public int _id { get; set; }
        [DefaultValue("")]
        public string accomType { get; set; }
        [DefaultValue("")]
        public string name { get; set; }
        [DefaultValue("")]
        public string agent_name { get; set; }
        [DefaultValue("")]
        public string telephone { get; set; }
    }

    public class Cosigner
    {
        public int status { get; set; }
        public List<object> comments { get; set; }
        public List<object> documents { get; set; }
    }

    public class Payment
    {
        public int status { get; set; }
        public List<object> comments { get; set; }
        public List<object> documents { get; set; }
    }

    public class Contract
    {
        public int status { get; set; }
        public List<object> comments { get; set; }
        public List<object> documents { get; set; }
    }

    public class Gd
    {
        public int status { get; set; }
        public List<object> comments { get; set; }
        public List<object> documents { get; set; }
    }

    public class Ast
    {
        public int status { get; set; }
        public List<object> comments { get; set; }
        public List<object> documents { get; set; }
    }

    public class Verification
    {
        public Tenant tenant { get; set; }
        public Ap ap { get; set; }
        public Cosigner cosigner { get; set; }
        public Payment payment { get; set; }
        public Contract contract { get; set; }
        public Gd gd { get; set; }
        public Ast ast { get; set; }
    }

    public class PrePaymentReminderEmails
    {
        public bool three_days { get; set; }
        public bool seven_days { get; set; }
        public bool one_hour { get; set; }
    }

    public class PreQuoteReminderEmails
    {
        public bool three_days { get; set; }
        public bool seven_days { get; set; }
        public bool one_hour { get; set; }
    }

    public class TimeStamps
    {
        public DateTime last_logged_in_date { get; set; }
        public DateTime last_update_date { get; set; }
        public DateTime last_update_date_dashboard { get; set; }
    }

    public class PriorityInfo
    {
        [DefaultValue("")]
        public string status { get; set; }
        public int points { get; set; }
        public int delay { get; set; }
    }

    public class FutureQuoteInfo
    {
        public int quote { get; set; }
        public int quote_monthly_subscription { get; set; }
        public int quote_monthly { get; set; }
        public int lump_sum_amount { get; set; }
        public int recurring_first_payment_amount { get; set; }
        public int recurring_payments_amount { get; set; }
        public int rebate { get; set; }
        public int status { get; set; }
        public int is_special_pricing { get; set; }
        public int rent { get; set; }
    }

    public class Nationality
    {
        [DefaultValue("")]
        public string text { get; set; }
        public int type { get; set; }
    }

    public class PlaceOfStudy
    {
        [DefaultValue("")]
        public string _id { get; set; }
        [DefaultValue("")]
        public string text { get; set; }
    }

    public class TypeOfStudy
    {
        [DefaultValue("")]
        public string _id { get; set; }
        [DefaultValue("")]
        public string text { get; set; }
    }

    public class YearOfStudy
    {
        public int type { get; set; }
        [DefaultValue("")]
        public string text { get; set; }
    }

    public class PersonalInfo
    {
        [DefaultValue("")]
        public string first_name { get; set; }
        [DefaultValue("")]
        public string last_name { get; set; }
        [DefaultValue("")]
        public string dialing_code { get; set; }
        [DefaultValue("")]
        public string phone_number { get; set; }
        public Nationality nationality { get; set; }
       // [DefaultValue("")]
        public DateTime date_of_birth { get; set; }
        [DefaultValue("")]
        public string ccj { get; set; }
        public PlaceOfStudy place_of_study { get; set; }
        public TypeOfStudy type_of_study { get; set; }
        [DefaultValue("")]
        public string type_of_course { get; set; }
        public YearOfStudy year_of_study { get; set; }
        [DefaultValue("")]
        public string employment_status { get; set; }
        [DefaultValue("")]
        public string income { get; set; }
        [DefaultValue("")]
        public string _id { get; set; }
    }



    public class CosignerInfo
    {
        [DefaultValue("")]
        public string relation { get; set; }
        [DefaultValue("")]
        public string address { get; set; }
        [DefaultValue("")]
        public string nationality { get; set; }
        [DefaultValue("")]
        public string first_name { get; set; }
        [DefaultValue("")]
        public string last_name { get; set; }
        [DefaultValue("")]
        public string email { get; set; }
        [DefaultValue("")]
        public string phone { get; set; }
        [DefaultValue("")]
        public string password { get; set; }
    }
    public class County
    {
        [DefaultValue("")]
        public string text { get; set; }
        [DefaultValue("")]
        public string _id { get; set; }
    }

    public class Property
    {
        [DefaultValue("")]
        public string address { get; set; }
        public County county { get; set; }
        [DefaultValue("")]
        public string postcode { get; set; }
    }

    public class Renewal
    {
        public bool with_in_93_days { get; set; }
        public bool _3_months { get; set; }
        public bool _6_months { get; set; }
        public bool _9_months { get; set; }
    }

    public class Rent
    {
        public int? fee { get; set; }
        [DefaultValue("")]
        public string duration { get; set; }
        //[DefaultValue("")]
        public DateTime start_date { get; set; }
       // [DefaultValue("")]
        public DateTime end_date { get; set; }
        [DefaultValue("")]
        public string guarantor_end_date { get; set; }
        public Renewal renewal { get; set; }
    }

    public class ApDetails
    {
        public Ap ap { get; set; }
        public Property property { get; set; }
        public Rent rent { get; set; }
    }

    public class ApplicationInfo
    {
        public CosignerInfo cosigner_info { get; set; }
        public ApDetails ap_details { get; set; }
    }

    public class Data
    {
        public AccountInfo account_info { get; set; }
        public PaymentInfo payment_info { get; set; }
        public QuoteInfo quote_info { get; set; }
        public Application application { get; set; }
        public Verification verification { get; set; }
        public PrePaymentReminderEmails pre_payment_reminder_emails { get; set; }
        public PreQuoteReminderEmails pre_quote_reminder_emails { get; set; }
        public TimeStamps time_stamps { get; set; }
        public PriorityInfo priority_info { get; set; }
        public FutureQuoteInfo future_quote_info { get; set; }
        public List<object> documents { get; set; }
        public DateTime datetime_joined { get; set; }
        public string _id { get; set; }
        public PersonalInfo personal_info { get; set; }
        public ApplicationInfo application_info { get; set; }
        public List<object> quotes { get; set; }
        public List<docs> docs { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int __v { get; set; }
    }

    public class LoginResponseModel
    {
        [DefaultValue("")]
        public string code { get; set; }
        [DefaultValue("")]
        public string message { get; set; }
        public Data data { get; set; }
        [DefaultValue("")]
        public string token { get; set; }
    }

    public class docs
    {
        public int? status { get; set; }
        public int? uploaded_by { get; set; }
        public int? type { get; set; }
        [DefaultValue("")]
        public string url { get; set; }
        public DateTime date_uploaded { get; set; }

        [DefaultValue("")]
        public string _id { get; set; }
    }

    public class PedDetails : PersonalInfo
    {
        [DefaultValue("")]
        public string StartDate { get; set; }
        [DefaultValue("")]
        public string EndDate { get; set; }
        [DefaultValue("")]
        public string email { get; set; }
        [DefaultValue("")]
        public string agent_id { get; set; }
        [DefaultValue("")]
        public string agent_Name { get; set; }
        [DefaultValue("")]
        public string position { get; set; }
    }
}
