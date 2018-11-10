using BaseLibs.EnumPack;
using BaseLibs.GlobalsPack;
using System.Data.Entity;
using System.Data.SQLite;

namespace BaseLibs.DBUtility.CodeFirstConfig.GeneralCodeFirstConfig
{
    public class DbContextMapper
    {
        public string DbConnectionString = ConstantVariables.DBPath;
        DbContext dbContext;
        public DbContext GetDBContext(string dbconnectionString = null, DbName dbName= DbName.UniWeb)
        {
            if (dbconnectionString == null)
                dbconnectionString = DbConnectionString;

            var sqlConnection = new SQLiteConnection("data source=" + dbconnectionString);
            if(dbName.Equals(DbName.UniWeb))
                dbContext = new UniWebDbConfig.UniWebDBContext(sqlConnection, true);
            return dbContext;
        }
    }
}
