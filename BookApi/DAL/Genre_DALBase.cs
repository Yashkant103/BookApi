using BookApi.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace BookApi.DAL
{
    public class Genre_DALBase : DAL_Helper
    {
        SqlDatabase sqlDatabase = null;
        public Genre_DALBase()
        {
            sqlDatabase = new SqlDatabase(ConnString);
        }
        public List<GenreModel> PR_GENRE_SELECT_ALL()
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_GENRE_SELECT_ALL");
                List<GenreModel> GenreModels = new List<GenreModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        GenreModel GenreModel = new GenreModel();
                        GenreModel.GenreID = Convert.ToInt32(dr["GenreID"]);
                        GenreModel.GenreName = Convert.ToString(dr["GenreName"]);
                        GenreModels.Add(GenreModel);
                    }
                }
                return GenreModels;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public GenreModel PR_GENRE_SELECT_BY_PK(int GenreID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_GENRE_SELECT_BY_PK");
                sqlDatabase.AddInParameter(dbCommand, "@AuhtorID", SqlDbType.Int, GenreID);
                GenreModel GenreModel = new GenreModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        GenreModel.GenreID = Convert.ToInt32(dr["GenreID"]);
                        GenreModel.GenreName = Convert.ToString(dr["GenreName"]);
                    }
                }
                return GenreModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PR_GENRE_INSERT(GenreModel GenreModel)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_GENRE_INSERT");
                sqlDatabase.AddInParameter(dbCommand, "@GenreName", SqlDbType.VarChar, GenreModel.GenreName);
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
        public bool PR_GENRE_UPDATE(int GenreID, GenreModel GenreModel)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_GENRE_UPDATE");
                sqlDatabase.AddInParameter(dbCommand, "@GenreID", SqlDbType.Int, GenreModel.GenreID);
                sqlDatabase.AddInParameter(dbCommand, "@GenreName", SqlDbType.VarChar, GenreModel.GenreName);
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
        public bool PR_GENRE_DELETE(int GenreID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_GENRE_DELETE");
                sqlDatabase.AddInParameter(dbCommand, "@GenreID", SqlDbType.Int, GenreID);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;
            }
            catch (Exception) { throw; }

        }
    }
}
