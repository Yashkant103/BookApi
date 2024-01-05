using BookApi.Model;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace BookApi.DAL
{
    public class Book_DALBase : DAL_Helper
    {
        SqlDatabase sqlDatabase = null;
        public Book_DALBase()
        {
            sqlDatabase = new SqlDatabase(ConnString);
        }
        public List<BookModel> PR_BOOK_SELECT_ALL()
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BOOK_SELECT_ALL");
                List<BookModel> bookModels = new List<BookModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        BookModel bookModel = new BookModel();
                        bookModel.BookID = Convert.ToInt32(dr["BookID"]);
                        bookModel.Title = dr["Title"].ToString();
                        bookModel.Image = dr["Image"].ToString();
                        bookModel.GenreID = Convert.ToInt32(dr["GenreID"]);
                        bookModel.ISBN = dr["ISBN"].ToString();
                        bookModel.PublishDate = Convert.ToDateTime(dr["PublishDate"]);
                        bookModel.Price = Convert.ToDecimal(dr["Price"]);
                        bookModels.Add(bookModel);
                    }
                }
                return bookModels;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public BookModel PR_BOOK_SELECT_BY_PK(int BookID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BOOK_SELECT_BY_PK");
                sqlDatabase.AddInParameter(dbCommand, "@BookID", SqlDbType.Int, BookID);
                BookModel bookModel = new BookModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        bookModel.BookID = Convert.ToInt32(dr["BookID"]);
                        bookModel.Title = dr["Title"].ToString();
                        bookModel.Image = dr["Image"].ToString();
                        bookModel.GenreID = Convert.ToInt32(dr["GenreID"]);
                        bookModel.ISBN = dr["ISBN"].ToString();
                        bookModel.PublishDate = Convert.ToDateTime(dr["PublishDate"]);
                        bookModel.Price = Convert.ToDecimal(dr["Price"]);
                    }
                }
                return bookModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PR_BOOK_INSERT(BookModel bookModel)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BOOK_INSERT");
                sqlDatabase.AddInParameter(dbCommand, "@Title", SqlDbType.VarChar, bookModel.Title);
                sqlDatabase.AddInParameter(dbCommand, "@Image", SqlDbType.VarChar, bookModel.Image);
                sqlDatabase.AddInParameter(dbCommand, "@GenreID", SqlDbType.Int, bookModel.GenreID);
                sqlDatabase.AddInParameter(dbCommand, "@ISBN", SqlDbType.VarChar, bookModel.ISBN);
                sqlDatabase.AddInParameter(dbCommand, "@PublishDate", SqlDbType.DateTime, bookModel.PublishDate);
                sqlDatabase.AddInParameter(dbCommand, "@Price", SqlDbType.Decimal, bookModel.Price);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PR_BOOK_UPDATE(int BookID, BookModel bookModel)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BOOK_UPDATE");
                sqlDatabase.AddInParameter(dbCommand, "@BookID", SqlDbType.Int, bookModel.BookID);
                sqlDatabase.AddInParameter(dbCommand, "@Title", SqlDbType.VarChar, bookModel.Title);
                sqlDatabase.AddInParameter(dbCommand, "@Image", SqlDbType.VarChar, bookModel.Image);
                sqlDatabase.AddInParameter(dbCommand, "@GenreID", SqlDbType.Int, bookModel.GenreID);
                sqlDatabase.AddInParameter(dbCommand, "@ISBN", SqlDbType.VarChar, bookModel.ISBN);
                sqlDatabase.AddInParameter(dbCommand, "@PublishDate", SqlDbType.DateTime, bookModel.PublishDate);
                sqlDatabase.AddInParameter(dbCommand, "@Price", SqlDbType.Decimal, bookModel.Price);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PR_BOOK_DELETE(int BookID)
        {
            try
            {
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_BOOK_DELETE");
                sqlDatabase.AddInParameter(dbCommand, "@BookID", SqlDbType.Int, BookID);
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;
            }
            catch (Exception) { throw; }

        }
    }
}
