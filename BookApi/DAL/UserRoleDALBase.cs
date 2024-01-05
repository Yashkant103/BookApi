using BookApi.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace BookApi.DAL
{
    public class UserRole_DALBase : DAL_Helper
    {
        SqlDatabase sqlDatabase = null;
        public UserRole_DALBase()
        {
            sqlDatabase = new SqlDatabase(ConnString);
        }
        public List<UserRoleModel> PR_ROLE_SELECT_ALL()
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_ROLE_SELECT_ALL");
                List<UserRoleModel> userRoleModels = new List<UserRoleModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        UserRoleModel userRoleModel = new UserRoleModel();
                        userRoleModel.RoleID = Convert.ToInt32(dr["RoleID"]);
                        userRoleModel.RoleName = Convert.ToString(dr["RoleName"]);
                        userRoleModels.Add(userRoleModel);
                    }
                }
                return userRoleModels;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public UserRoleModel PR_ROLE_SELECT_BY_PK(int RoleID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_ROLE_SELECT_BY_PK");
                sqlDatabase.AddInParameter(dbCommand, "@AuhtorID", SqlDbType.Int, RoleID);
                UserRoleModel userRoleModel = new UserRoleModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        userRoleModel.RoleID = Convert.ToInt32(dr["RoleID"]);
                        userRoleModel.RoleName = Convert.ToString(dr["RoleName"]);
                    }
                }
                return userRoleModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PR_ROLE_INSERT(UserRoleModel userRoleModel)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_ROLE_INSERT");
                sqlDatabase.AddInParameter(dbCommand, "@RoleName", SqlDbType.VarChar, userRoleModel.RoleName);
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
        public bool PR_ROLE_UPDATE(int RoleID, UserRoleModel userRoleModel)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_ROLE_UPDATE");
                sqlDatabase.AddInParameter(dbCommand, "@RoleID", SqlDbType.Int, userRoleModel.RoleID);
                sqlDatabase.AddInParameter(dbCommand, "@RoleName", SqlDbType.VarChar, userRoleModel.RoleName);
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
        public bool PR_ROLE_DELETE(int RoleID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_ROLE_DELETE");
                sqlDatabase.AddInParameter(dbCommand, "@RoleID", SqlDbType.Int, RoleID);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;
            }
            catch (Exception) { throw; }

        }

    }
}
