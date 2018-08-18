using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUIUtility.ResourceStyle
{
   public static class ResourceHandler
    {
     
        public static string GetResourceString(this string Resource)
        {
            return App.Current.FindResource(Resource).ToString();
        }
    }
}
