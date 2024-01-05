using BookApi.DAL;
using BookApi.Model;

namespace BookApi.BAL
{
    public class User_BALBase
    {
        public List<UserModel> PR_USER_SELECT_ALL()
        {
            try
            {
                User_DALBase user_DAlBase = new User_DALBase();
                List<UserModel> userModels = user_DAlBase.PR_USER_SELECT_ALL();
                return userModels;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public UserModel PR_USER_SELECT_BY_PK(int UserID)
        {
            try
            {
                User_DALBase user_DAlBase = new User_DALBase();
                UserModel userModel = user_DAlBase.PR_USER_SELECT_BY_PK(UserID);
                return userModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PR_USER_INSERT(UserModel userModel)
        {
            try
            {
                User_DALBase user_DAlBase = new User_DALBase();
                if (user_DAlBase.PR_USER_INSERT(userModel))
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
        public bool PR_USER_UPDATE(int UserID, UserModel userModel)
        {
            try
            {
                User_DALBase user_DAlBase = new User_DALBase();
                if (user_DAlBase.PR_USER_UPDATE(UserID, userModel))
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
        public bool PR_USER_DELETE(int UserID)
        {
            try
            {
                User_DALBase user_DAlBase = new User_DALBase();
                if (user_DAlBase.PR_USER_DELETE(UserID))
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
