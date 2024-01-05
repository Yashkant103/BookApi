using BookApi.DAL;
using BookApi.Model;

namespace BookApi.BAL
{
    public class Genre_BALBase
    {
        Genre_DALBase genre_DALBase = new Genre_DALBase();

        public List<GenreModel> PR_GENRE_SELECT_ALL()
        {
            try
            {
                List<GenreModel> genreModels = genre_DALBase.PR_GENRE_SELECT_ALL();
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
                GenreModel genreModel = genre_DALBase.PR_GENRE_SELECT_BY_PK(GenreID);
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
                if (genre_DALBase.PR_GENRE_INSERT(genreModel))
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
                if (genre_DALBase.PR_GENRE_UPDATE(GenreID, genreModel))
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
                if (genre_DALBase.PR_GENRE_DELETE(GenreID))
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
