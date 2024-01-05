using BookApi.DAL;
using BookApi.Model;

namespace BookApi.BAL
{
    public class User_BALBase
    {
        User_DALBase user_DALBase = new User_DALBase();
        public List<UserModel> PR_USER_SELECT_ALL()
        {
            try
            {
                List<UserModel> userModels = user_DALBase.PR_USER_SELECT_ALL();
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
                UserModel userModel = user_DALBase.PR_USER_SELECT_BY_PK(UserID);
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
                if (user_DALBase.PR_USER_INSERT(userModel))
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
                if (user_DALBase.PR_USER_UPDATE(UserID, userModel))
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
                if (user_DALBase.PR_USER_DELETE(UserID))
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
