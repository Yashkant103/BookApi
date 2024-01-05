using BookApi.DAL;
using BookApi.Model;

namespace BookApi.BAL
{
    public class UserRole_BALBase
    {
        UserRole_DALBase userRole_DALBase = new UserRole_DALBase();
        public List<UserRoleModel> PR_ROLE_SELECT_ALL()
        {
            try
            {
                List<UserRoleModel> userRoleModels = userRole_DALBase.PR_ROLE_SELECT_ALL();
                return userRoleModels;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public UserRoleModel PR_ROLE_SELECT_BY_PK(int RoleID)
        {
            try
            {
                UserRoleModel userRoleModel = userRole_DALBase.PR_ROLE_SELECT_BY_PK(RoleID);
                return userRoleModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool PR_ROLE_INSERT(UserRoleModel userRoleModel)
        {
            try
            {
                if (userRole_DALBase.PR_ROLE_INSERT(userRoleModel))
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
        public bool PR_ROLE_UPDATE(int RoleID, UserRoleModel userRoleModel)
        {
            try
            {
                if (userRole_DALBase.PR_ROLE_UPDATE(RoleID, userRoleModel))
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
        public bool PR_ROLE_DELETE(int RoleID)
        {
            try
            {
                if (userRole_DALBase.PR_ROLE_DELETE(RoleID))
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
