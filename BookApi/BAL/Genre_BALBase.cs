using BookApi.DAL;
using BookApi.Model;

namespace BookApi.BAL
{
    public class Genre_BALBase : DAL_Helper
    {
        public List<GenreModel> PR_GENRE_SELECT_ALL()
        {
            try
            {
                Genre_BALBase genre_BALBase = new Genre_BALBase();
                List<GenreModel> genreModels = genre_BALBase.PR_GENRE_SELECT_ALL();
                return genreModels;
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
                Genre_BALBase genre_BALBase = new Genre_BALBase();
                GenreModel genreModel = genre_BALBase.PR_GENRE_SELECT_BY_PK(GenreID);
                return genreModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PR_GENRE_INSERT(GenreModel genreModel)
        {
            try
            {
                Genre_BALBase genre_BALBase = new Genre_BALBase();
                if (genre_BALBase.PR_GENRE_INSERT(genreModel))
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
        public bool PR_GENRE_UPDATE(int GenreID, GenreModel genreModel)
        {
            try
            {
                Genre_BALBase genre_BALBase = new Genre_BALBase();
                if (genre_BALBase.PR_GENRE_UPDATE(GenreID, genreModel))
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
        public bool PR_GENRE_DELETE(int GenreID)
        {
            try
            {
                Genre_BALBase genre_BALBase = new Genre_BALBase();
                if (genre_BALBase.PR_GENRE_DELETE(GenreID))
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
