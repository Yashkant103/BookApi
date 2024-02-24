using BookApi.DAL;

namespace BookApi.BAL
{
    public class Login_BALBase
    {
        public int PR_USER_LOGIN(string UserName, string UserPassword)
        {
            try
            {
                Login_DalBase login_DalBase = new Login_DalBase();
                int user = login_DalBase.PR_USER_LOGIN(UserName, UserPassword);
                return user;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
