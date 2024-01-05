using BookApi.Model;

namespace BookApi.BAL
{
    public class Author_BALBase
    {
        public List<AuthorModel> PR_AUTHOR_SELECT_ALL()
        {
            try
            {
                Author_BALBase author_BALBase = new Author_BALBase();
                List<AuthorModel> authorModels = author_BALBase.PR_AUTHOR_SELECT_ALL();
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
                Author_BALBase author_BALBase = new Author_BALBase();
                AuthorModel authorModel = author_BALBase.PR_AUTHOR_SELECT_BY_PK(AuthorID);
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
                Author_BALBase author_BALBase = new Author_BALBase();
                if (author_BALBase.PR_AUTHOR_INSERT(authorModel))
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
        public bool PR_AUTHOR_UPDATE(int AuthorID, AuthorModel authorModel)
        {
            try
            {
                Author_BALBase author_BALBase = new Author_BALBase();
                if (author_BALBase.PR_AUTHOR_UPDATE(AuthorID, authorModel))
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
                Author_BALBase author_BALBase = new Author_BALBase();
                if (author_BALBase.PR_AUTHOR_DELETE(AuthorID))
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
