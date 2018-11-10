using BaseLibs.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaseLibs.DataUtility
{
   public static  class StringHandler
    {
        public static string InnerHtml(this string HtmlString)
        {
            string output = HtmlString;
            try
            {
                output = Regex.Replace(HtmlString, "<.*?>", " ", RegexOptions.Multiline);
            }
            catch(Exception ex)
            {
                ex.ErrorLog();
            }
            return output;
        }
    }
}
