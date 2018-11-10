using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.DBUtility.CodeFirstConfig.UniWebDbConfig
{
   
    public class UniWebDBContext : DbContext
    {
        public UniWebDBContext(string DbConnectionstring) :
            base(DbConnectionstring)
        {
            configure();
        }

        public UniWebDBContext(DbConnection dbConnection, bool IsContextOwnsConnection) :
           base(dbConnection, IsContextOwnsConnection)
        {
            configure();
        }

        private void configure()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                //modelBuilder.Entity<TwtAccountModel>();
                //modelBuilder.Entity<FbAccountModel>();
                //modelBuilder.Entity<WebHeaderModel>();
                //modelBuilder.Entity<WebAccounts>();
                var Initializer = new UniWebDbInitialize(modelBuilder);
                Database.SetInitializer(Initializer);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
