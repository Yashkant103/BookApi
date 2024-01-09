using BookApi.DAL;
using BookApi.Model;

namespace BookApi.BAL
{
    public class Login_BALBase
    {
        Login_BALBase login_BALBase = null;
        public Login_BALBase()
        {
            login_BALBase = new Login_BALBase();
        }
        public int PR_USER_LOGIN(UserModel userModel)
        {
            try
            {
                Login_DalBase login_DalBase = new Login_DalBase();
                int result = login_DalBase.PR_USER_LOGIN(userModel.UserName, userModel.UserPassword);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
