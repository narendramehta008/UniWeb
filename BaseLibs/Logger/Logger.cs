using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;
using log4net.Repository;

namespace BaseLibs.Logger
{
    public  class Logger 
    {
        public static readonly ILog Log;
      static  Logger()
        {
            Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
         
    }
}
