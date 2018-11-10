using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.DBUtility.CodeFirstConfig.GeneralCodeFirstConfig
{
    public class DbHandler
    {
        private DbContext dbContext;
        public DbHandler(DbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public bool AddData<T>(T data) where T : class
        {
            try
            {
                dbContext.Set<T>().Add(data);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateData<T>(T data) where T : class
        {
            try
            {
                dbContext.Entry(data).State = EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
