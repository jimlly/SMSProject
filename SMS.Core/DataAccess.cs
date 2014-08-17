using SMS.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SMS.DALFactory
{
    public sealed partial class DataAccess
    {
        public static readonly string path = ConfigurationManager.AppSettings["DALPath"];
        public static IContactorDAL CreateContactorDAL()
        {
            var className = DALFactory.DataAccess.path + ".Addr.ContactorDAL";

            try
            {
                return (IContactorDAL)Assembly.Load(DALFactory.DataAccess.path).CreateInstance(className);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static IContactorGroupDAL CreateContactorGroupDAL()
        {
            var className = DALFactory.DataAccess.path + ".Addr.ContactorGroupDAL";

            try
            {
                return (IContactorGroupDAL)Assembly.Load(DALFactory.DataAccess.path).CreateInstance(className);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static ISMSDAL CreateSmsDAL()
        {
            var className = DALFactory.DataAccess.path + ".SmsDAL";

            try
            {
                return (ISMSDAL)Assembly.Load(DALFactory.DataAccess.path).CreateInstance(className);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
