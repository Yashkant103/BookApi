using BookApi.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace BookApi.DAL
{
    public class Author_DALBase : DAL_Helper
    {
        SqlDatabase sqlDatabase = null;
        public Author_DALBase()
        {
            sqlDatabase = new SqlDatabase(ConnString);
        }
        public List<AuthorModel> PR_AUTHOR_SELECT_ALL()
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_AUTHOR_SELECT_ALL");
                List<AuthorModel> authorModels = new List<AuthorModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        AuthorModel authorModel = new AuthorModel();
                        authorModel.AuthorID = Convert.ToInt32(dr["AuthorID"]);
                        authorModel.AuthorName = Convert.ToString(dr["AuthorName"]);
                        authorModel.AuthorEmail = Convert.ToString(dr["AuthorEmail"]);
                        authorModel.Created = Convert.ToDateTime(dr["Created"]);
                        authorModel.Modified = Convert.ToDateTime(dr["Modified"]);
                        authorModels.Add(authorModel);
                    }
                }
                return authorModels;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public AuthorModel PR_AUTHOR_SELECT_BY_PK(int AuthorID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_AUTHOR_SELECT_BY_PK");
                sqlDatabase.AddInParameter(dbCommand, "@AuthorID", SqlDbType.Int, AuthorID);
                AuthorModel authorModel = new AuthorModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        authorModel.AuthorID = Convert.ToInt32(dr["AuthorID"]);
                        authorModel.AuthorName = Convert.ToString(dr["AuthorName"]);
                        authorModel.AuthorEmail = Convert.ToString(dr["AuthorEmail"]);
                    }
                }
                return authorModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PR_AUTHOR_INSERT(AuthorModel authorModel)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_AUTHOR_INSERT");
                sqlDatabase.AddInParameter(dbCommand, "@AuthorName", SqlDbType.VarChar, authorModel.AuthorName);
                sqlDatabase.AddInParameter(dbCommand, "@AuthorEmail", SqlDbType.VarChar, authorModel.AuthorEmail);
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
        public bool PR_AUTHOR_UPDATE(AuthorModel authorModel)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_AUTHOR_UPDATE");
                sqlDatabase.AddInParameter(dbCommand, "@AuthorID", SqlDbType.Int, authorModel.AuthorID);
                sqlDatabase.AddInParameter(dbCommand, "@AuthorName", SqlDbType.VarChar, authorModel.AuthorName);
                sqlDatabase.AddInParameter(dbCommand, "@AuthorEmail", SqlDbType.VarChar, authorModel.AuthorEmail);
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
        public bool PR_AUTHOR_DELETE(int AuthorID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_AUTHOR_DELETE");
                sqlDatabase.AddInParameter(dbCommand, "@AuthorID", SqlDbType.Int, AuthorID);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;
            }
            catch (Exception) { throw; }

        }
    }
}
