using BookApi.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace BookApi.DAL
{
    public class User_DALBase : DAL_Helper
    {
        SqlDatabase sqlDatabase = null;
        public User_DALBase()
        {
            sqlDatabase = new SqlDatabase(ConnString);
        }
        public List<UserModel> PR_USER_SELECT_ALL()
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_USER_SELECT_ALL");
                List<UserModel> userModels = new List<UserModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        UserModel userModel = new UserModel();
                        userModel.UserID = Convert.ToInt32(dr["UserID"]);
                        userModel.UserName = dr["UserName"].ToString();
                        userModel.UserEmail = dr["UserEmail"].ToString();
                        userModel.RoleID = Convert.ToInt32(dr["RoleID"].ToString());
                        userModel.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        userModels.Add(userModel);
                    }
                }
                return userModels;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public UserModel PR_USER_SELECT_BY_PK(int UserID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_USER_SELECT_BY_PK");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);
                UserModel userModel = new UserModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        userModel.UserID = Convert.ToInt32(dr["UserID"]);
                        userModel.UserName = dr["UserName"].ToString();
                        userModel.UserEmail = dr["UserEmail"].ToString();
                        userModel.RoleID = Convert.ToInt32(dr["RoleID"].ToString());
                        userModel.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    }
                }
                return userModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PR_USER_INSERT(UserModel userModel)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_USER_INSERT");
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, userModel.UserName);
                sqlDatabase.AddInParameter(dbCommand, "@UserEmail", SqlDbType.VarChar, userModel.UserEmail);
                sqlDatabase.AddInParameter(dbCommand, "@UserPassword", SqlDbType.VarChar, userModel.UserPassword);
                sqlDatabase.AddInParameter(dbCommand, "@RoleID", SqlDbType.Int, userModel.RoleID);
                sqlDatabase.AddInParameter(dbCommand, "@IsActive", SqlDbType.Bit, userModel.IsActive);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PR_USER_UPDATE(int UserID, UserModel userModel)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_USER_UPDATE");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, userModel.UserName);
                sqlDatabase.AddInParameter(dbCommand, "@UserEmail", SqlDbType.VarChar, userModel.UserEmail);
                sqlDatabase.AddInParameter(dbCommand, "@UserPassword", SqlDbType.VarChar, userModel.UserPassword);
                sqlDatabase.AddInParameter(dbCommand, "@RoleID", SqlDbType.Int, userModel.RoleID);
                sqlDatabase.AddInParameter(dbCommand, "@IsActive", SqlDbType.Bit, userModel.IsActive);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool PR_USER_DELETE(int UserID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_USER_DELETE");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;
            }
            catch (Exception) { throw; }

        }
    }
}
