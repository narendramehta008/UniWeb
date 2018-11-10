using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.DBUtility
{
    public class DBCreation
    {
        string DBDestinationPath = @"C:\UniWeb\Data\UniWeb.db";
        public DBCreation()
        {
            checkDbExists();
        }

        private void checkDbExists()
        {
            try
            {
                if (Directory.Exists(@"C:\UniWeb"))
                {
                    #region  main folder exists
                    if (Directory.Exists(@"C:\UniWeb\Data"))
                    {
                        if (!File.Exists(DBDestinationPath))
                        {
                            string currentExecutingPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                            string dbPath = $"{currentExecutingPath}\\UniWeb.db";
                            File.Copy(dbPath, DBDestinationPath);
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(@"C:\UniWeb\Data");
                        string currentExecutingPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                        string dbPath = $"{currentExecutingPath}\\UniWeb.db";
                        File.Copy(dbPath, DBDestinationPath);
                    }
                    #endregion
                }
                else
                {
                    #region main folder not exists
                    Directory.CreateDirectory(@"C:\UniWeb");
                    Directory.CreateDirectory(@"C:\UniWeb\Data");
                    string currentExecutingPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string dbPath = $"{currentExecutingPath}\\UniWeb.db";
                    File.Copy(dbPath, DBDestinationPath);
                    #endregion
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.Log.Error(ex.ToString());
            }
        }

    }
}
