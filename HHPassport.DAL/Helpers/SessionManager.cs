using HHPassport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HHPassport.DAL.Helpers
{
    public class SessionManager
    {
        public static LoginResponse LoginResponse
        {
            get
            {
                if (HttpContext.Current.Session["LoginResponse"] != null)
                {
                    return (DAL.Models.LoginResponse)HttpContext.Current.Session["LoginResponse"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Session["LoginResponse"] = value;
            }
        }

        public static bool IsSecurePanelLogedIn
        {
            get
            {
                if (Convert.ToBoolean(HttpContext.Current.Session["IsSecurePanelLogedIn"]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                HttpContext.Current.Session["IsSecurePanelLogedIn"] = value;
            }
        }
    }
}
