using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.DBUtility.CodeFirstConfig.UniWebDbConfig
{
    
    public class UniWebDbInitialize : SqliteCreateDatabaseIfNotExists<UniWebDBContext>//SqliteDropCreateDatabaseWhenModelChanges<ProUIDBContext>
    {
        public UniWebDbInitialize(DbModelBuilder dbModelBuilder) : base(dbModelBuilder)
        {

        }
    }
}
