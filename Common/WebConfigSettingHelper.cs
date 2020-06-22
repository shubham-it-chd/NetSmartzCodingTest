using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CommonLayer
{
    public class WebConfigSettingHelper
    {

        public static class UtilityPath
        {

            public static String HostingPrefix
            {
                get
                {
                    return Convert.ToString(WebConfigurationManager.AppSettings.Get("hostingPrefix"));
                    
                }
            }
            
            public static String LogoPath
            {
                get
                {
                    return Convert.ToString(WebConfigurationManager.AppSettings.Get("LogoPath"));
                }
            }
            


        }

        public static class EmailSettings
        {
            public static string SmtpHost
            {
                get
                {
                    return Convert.ToString(WebConfigurationManager.AppSettings.Get("smtpHost"));
                }
            }
            public static string SmtpUser
            {
                get
                {
                    return Convert.ToString(WebConfigurationManager.AppSettings.Get("smtpUser"));
                }
            }
            public static string SmtpPassword
            {
                get
                {
                    return Convert.ToString(WebConfigurationManager.AppSettings.Get("smtpPassword"));
                }
            }
            public static string MailServerPort
            {
                get
                {
                    return Convert.ToString(WebConfigurationManager.AppSettings.Get("MailServerPort"));
                }
            }
            public static string SystemEmailFrom
            {
                get
                {
                    return Convert.ToString(WebConfigurationManager.AppSettings.Get("SystemEmailFrom"));
                }
            }
            public static string SystemEmailDisplayName
            {
                get
                {
                    return Convert.ToString(WebConfigurationManager.AppSettings.Get("SystemEmailDisplayName"));
                }
            }
			
        }


        public static class fileVersioning
        {
         public static String CurrentFileVersion
            {
                get
                {
                    return Convert.ToString(WebConfigurationManager.AppSettings.Get("FileVersion"));
                }
            }
            public static String CurrentCSSFileVersion
            {
                get
                {
                    return Convert.ToString(WebConfigurationManager.AppSettings.Get("CSSFileVersion"));
                }
            }
        }

     
        
    }
}