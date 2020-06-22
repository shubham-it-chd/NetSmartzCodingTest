
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Configuration;

namespace CommonLayer
{
    public class LoggedUserDetail
    {
        public long UserId { get; set; }
        public string Password { get; set; }          
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class SessionManagement
    {
        public static LoggedUserDetail LoggedInUser
        {
            get
            {
                return (LoggedUserDetail)HttpContext.Current.Session["LoggedInUser"];
            }
            set
            {
                HttpContext.Current.Session["LoggedInUser"] = value;
            }
        }
    }  

   
}
