using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net.Core;
using log4net.Repository;
using log4net.Config;

namespace BaseLibs.Logger
{
   public delegate void AddToLogger(string message);

    public class Logger 
    {
        private static readonly ILog Logs = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static AddToLogger AddToLogger;

        private static readonly object LockInfo = new object();
        private static readonly object LockError = new object();

       
        public class Log
        {
            public static void Info(string message)
            {
                try
                {
                    lock (LockInfo)
                    {
                        AddToLogger(message);
                    }
                }
                catch (Exception ex)
                {
                }
            }

            public static void Error(string message)
            {
                try
                {
                    lock (LockError)
                    {
                        Logs.Error(message);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
