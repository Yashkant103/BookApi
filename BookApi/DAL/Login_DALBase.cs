using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace BookApi.DAL
{
    public class Login_DalBase : DAL_Helper
    {
        public int PR_USER_LOGIN(string UserName, string password)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_USER_LOGIN");
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, UserName);
                sqlDatabase.AddInParameter(dbCommand, "@UserPassword", SqlDbType.VarChar, password);
                int userID = -1;
                //UserModel model = new UserModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        userID = Convert.ToInt32(dr["UserID"]);
                    }
                    return userID;
                }
            }
            catch (Exception)
            {
                return -1;
            }

        }
    }
}