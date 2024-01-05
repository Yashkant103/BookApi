using BookApi.DAL;
using BookApi.Model;

namespace BookApi.BAL
{
    public class Book_BALBase
    {
        public List<BookModel> PR_BOOK_SELECT_ALL()
        {
            try
            {
                Book_DALBase book_DALBase = new Book_DALBase();
                List<BookModel> bookModels = book_DALBase.PR_BOOK_SELECT_ALL();
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
                Book_DALBase book_DALBase = new Book_DALBase();
                BookModel bookModel = book_DALBase.PR_BOOK_SELECT_BY_PK(BookID);
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
                Book_DALBase book_DAlBase = new Book_DALBase();
                if (book_DAlBase.PR_BOOK_INSERT(bookModel))
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
                Book_DALBase book_DAlBase = new Book_DALBase();
                if (book_DAlBase.PR_BOOK_UPDATE(BookID, bookModel))
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
                Book_DALBase book_DAlBase = new Book_DALBase();
                if (book_DAlBase.PR_BOOK_DELETE(BookID))
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
    }
}
