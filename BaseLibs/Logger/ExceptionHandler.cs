using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.Logger
{
   public static class ExceptionHandler 
    {
        public static void ErrorLog(this Exception ex, string message = null)
        {
            try
            {
                Logger.Log.Error(message == null ? "" : message + " " + ex.ToString());
            }
            catch (Exception exc)
            {
                Logger.Log.Error(exc.ToString());
            }
        }

    }
}
