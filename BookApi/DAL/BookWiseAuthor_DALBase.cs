using BookApi.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace BookApi.DAL
{
    public class BookWiseAuthor_DALBase : DAL_Helper
    {
        SqlDatabase sqlDatabase = null;
        public BookWiseAuthor_DALBase()
        {
            sqlDatabase = new SqlDatabase(ConnString);
        }
        public List<BookWiseAuthorModel> PR_BookWiseAuthor_SELECT_ALL()
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BookWiseAuthor_SELECT_ALL");
                List<BookWiseAuthorModel> bookWiseAuthorModels = new List<BookWiseAuthorModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        BookWiseAuthorModel bookWiseAuthorModel = new BookWiseAuthorModel();
                        bookWiseAuthorModel.BookWiseAuthorID = Convert.ToInt32(dr["BookWiseAuthorID"]);
                        bookWiseAuthorModel.AuthorID = Convert.ToInt32(dr["AuthorID"]);
                        bookWiseAuthorModel.BookID = Convert.ToInt32(dr["BookID"]);
                        bookWiseAuthorModels.Add(bookWiseAuthorModel);
                    }
                }
                return bookWiseAuthorModels;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public BookWiseAuthorModel PR_BookWiseAuthor_SELECT_BY_PK(int BookWiseAuthorID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BookWiseAuthor_SELECT_BY_PK");
                sqlDatabase.AddInParameter(dbCommand, "@BookWiseAuthorID", SqlDbType.Int, BookWiseAuthorID);
                BookWiseAuthorModel bookWiseAuthorModel = new BookWiseAuthorModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        bookWiseAuthorModel.BookWiseAuthorID = Convert.ToInt32(dr["BookWiseAuthorID"]);
                        bookWiseAuthorModel.AuthorID = Convert.ToInt32(dr["AuthorID"]);
                        bookWiseAuthorModel.BookID = Convert.ToInt32(dr["BookID"]);
                    }
                }
                return bookWiseAuthorModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PR_BookWiseAuthor_INSERT(BookWiseAuthorModel bookWiseAuthorModel)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BookWiseAuthor_INSERT");
                sqlDatabase.AddInParameter(dbCommand, "@AuthorID", SqlDbType.Int, bookWiseAuthorModel.AuthorID);
                sqlDatabase.AddInParameter(dbCommand, "@BookID", SqlDbType.Int, bookWiseAuthorModel.BookID);
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
        public bool PR_BookWiseAuthor_UPDATE(int BookWiseAuthorID, BookWiseAuthorModel bookWiseAuthorModel)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BookWiseAuthor_UPDATE");
                sqlDatabase.AddInParameter(dbCommand, "@BookWiseAuthorID", SqlDbType.Int, bookWiseAuthorModel.BookWiseAuthorID);
                sqlDatabase.AddInParameter(dbCommand, "@AuthorID", SqlDbType.Int, bookWiseAuthorModel.AuthorID);
                sqlDatabase.AddInParameter(dbCommand, "@BookID", SqlDbType.Int, bookWiseAuthorModel.BookID);
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
        public bool PR_BookWiseAuthor_DELETE(int BookWiseAuthorID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BookWiseAuthor_DELETE");
                sqlDatabase.AddInParameter(dbCommand, "@BookWiseAuthorID", SqlDbType.Int, BookWiseAuthorID);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;
            }
            catch (Exception) { throw; }

        }
    }
}
