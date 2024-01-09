using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace BookApi.DAL
{
    public class Login_DalBase : DAL_Helper
    {
        SqlDatabase sqlDatabase = null;
        public Login_DalBase()
        {
            sqlDatabase = new SqlDatabase(ConnString);
        }
        public int PR_USER_LOGIN(string UserName, string password)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_USER_LOGIN");
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, UserName);
                sqlDatabase.AddInParameter(dbCommand, "@UserPassword", SqlDbType.VarChar, password);
                int result = sqlDatabase.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}