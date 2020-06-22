
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CommonLayer
{
    public static class StringExtensionMethods
    {
        public static String MyDateFormat(this String str)
        {          

            if(str.Trim() != string.Empty)
            {
                return Convert.ToDateTime(str).ToString("yyyy‐MM‐dd"); 
            }
            else
            {
                return str;
            }
        }
             


    }
    
}
