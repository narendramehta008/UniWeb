using BaseLibs.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.DBUtility
{
   

    public class DBConnector
    {

        public static bool AddData<T>(List<T> listData) where T : class
        {
            bool IsSuccess = false;
            try
            {
                using (UniWebEntities uniWebEntities = new UniWebEntities())
                {
                    uniWebEntities.Set<T>().AddRange(listData);
                    uniWebEntities.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return IsSuccess;
        }

        public static bool AddData<T>(T Data) where T : class
        {
            bool IsSuccess = false;
            try
            {
                using (UniWebEntities uniWebEntities = new UniWebEntities())
                {
                    uniWebEntities.Set<T>().Add(Data);
                    uniWebEntities.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return IsSuccess;
        }

        public static List<T> GetList<T>(Expression<Func<T, bool>> expression) where T : class
        {
            List<T> DataList = new List<T>();
            try
            {
                using (UniWebEntities uniWebEntities = new UniWebEntities())
                {
                    DataList = uniWebEntities.Set<T>().Where(expression).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return DataList;
        }

        public static T GetData<T>(Expression<Func<T, bool>> expression) where T : class
        {
            T data = null;
            try
            {
                using (UniWebEntities uniWebEntities = new UniWebEntities())
                {
                    data = uniWebEntities.Set<T>().Where(expression).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
            }
            return data;
        }

        public static bool DeleteRange<T>(Expression<Func<T, bool>> expression) where T : class
        {
            bool IsSuccess = false;
            try
            {
                using (UniWebEntities uniWebEntities = new UniWebEntities())
                {
                    // uniWebEntities.Entry<T>(expression).State = System.Data.Entity.EntityState.Deleted ;
                    List<T> removeDataList = uniWebEntities.Set<T>().Where(expression).ToList();
                    uniWebEntities.Set<T>().RemoveRange(removeDataList);
                    uniWebEntities.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return IsSuccess;
        }

        public static bool Delete<T>(Expression<Func<T, bool>> expression) where T : class
        {
            bool IsSuccess = false;
            try
            {
                using (UniWebEntities uniWebEntities = new UniWebEntities())
                {
                    T data = uniWebEntities.Set<T>().Where(expression).ToList().FirstOrDefault();
                    uniWebEntities.Set<T>().Remove(data);
                    uniWebEntities.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return IsSuccess;
        }

        public static bool Delete<T>(T data) where T : class
        {
            bool IsSuccess = false;
            try
            {
                using (UniWebEntities uniWebEntities = new UniWebEntities())
                {
                    uniWebEntities.Set<T>().Remove(data);
                    uniWebEntities.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return IsSuccess;
        }

        [Obsolete("We getting same element after running expression so need to run this query")]
        public static bool Update<T>(Expression<Func<T, bool>> expression) where T : class
        {
            bool IsSuccess = false;
            try
            {
                using (UniWebEntities uniWebEntities = new UniWebEntities())
                {
                    T data = uniWebEntities.Set<T>().Where(expression).ToList().FirstOrDefault();
                    uniWebEntities.Entry<T>(data).State = System.Data.Entity.EntityState.Modified;
                    uniWebEntities.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return IsSuccess;
        }

        public static bool Update<T>(T data) where T : class
        {
            bool IsSuccess = false;
            try
            {
                using (UniWebEntities uniWebEntities = new UniWebEntities())
                {
                    uniWebEntities.Entry<T>(data).State = System.Data.Entity.EntityState.Modified;
                    uniWebEntities.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return IsSuccess;
        }

    }
}
