using BookApi.DAL;
using BookApi.Model;

namespace BookApi.BAL
{
    public class BookWiseAuthor_BALBase
    {
        BookWiseAuthor_DALBase bookWiseAuthor_DALBase = new BookWiseAuthor_DALBase();
        public List<BookWiseAuthorModel> PR_BookWiseAuthor_SELECT_ALL()
        {
            try
            {
                List<BookWiseAuthorModel> bookWiseAuthorModels = bookWiseAuthor_DALBase.PR_BookWiseAuthor_SELECT_ALL();
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
                BookWiseAuthorModel bookWiseAuthorModel = bookWiseAuthor_DALBase.PR_BookWiseAuthor_SELECT_BY_PK(BookWiseAuthorID);
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
                if (bookWiseAuthor_DALBase.PR_BookWiseAuthor_INSERT(bookWiseAuthorModel))
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
        public bool PR_BookWiseAuthor_UPDATE(int BookWiseAuthorID, BookWiseAuthorModel bookWiseAuthorModel)
        {
            try
            {
                if (bookWiseAuthor_DALBase.PR_BookWiseAuthor_UPDATE(BookWiseAuthorID, bookWiseAuthorModel))
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
        public bool PR_BookWiseAuthor_DELETE(int BookWiseAuthorID)
        {
            try
            {
                if (bookWiseAuthor_DALBase.PR_BookWiseAuthor_DELETE(BookWiseAuthorID))
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
