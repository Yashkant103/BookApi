using BookApi.DAL;
using BookApi.Model;

namespace BookApi.BAL
{
    public class Author_BALBase
    {
        Author_DALBase author_DALBase = new Author_DALBase();

        public List<AuthorModel> PR_AUTHOR_SELECT_ALL()
        {
            try
            {
                List<AuthorModel> authorModels = author_DALBase.PR_AUTHOR_SELECT_ALL();
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
                AuthorModel authorModel = author_DALBase.PR_AUTHOR_SELECT_BY_PK(AuthorID);
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
                if (author_DALBase.PR_AUTHOR_INSERT(authorModel))
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
        public bool PR_AUTHOR_UPDATE(AuthorModel authorModel)
        {
            try
            {
                if (author_DALBase.PR_AUTHOR_UPDATE(authorModel))
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
        public bool PR_AUTHOR_DELETE(int AuthorID)
        {
            try
            {
                if (author_DALBase.PR_AUTHOR_DELETE(AuthorID))
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
