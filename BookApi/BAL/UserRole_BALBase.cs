using BookApi.Model;

namespace BookApi.BAL
{
    public class UserRole_BALBase
    {
        public List<UserRoleModel> PR_ROLE_SELECT_ALL()
        {
            try
            {
                UserRole_BALBase userRole_BALBase = new UserRole_BALBase();
                List<UserRoleModel> userRoleModels = userRole_BALBase.PR_ROLE_SELECT_ALL();
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
                UserRole_BALBase userRole_BALBase = new UserRole_BALBase();
                UserRoleModel userRoleModel = userRole_BALBase.PR_ROLE_SELECT_BY_PK(RoleID);
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
                UserRole_BALBase userRole_BALBase = new UserRole_BALBase();
                if (userRole_BALBase.PR_ROLE_INSERT(userRoleModel))
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
                UserRole_BALBase userRole_BALBase = new UserRole_BALBase();
                if (userRole_BALBase.PR_ROLE_UPDATE(RoleID, userRoleModel))
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
                UserRole_BALBase userRole_BALBase = new UserRole_BALBase();
                if (userRole_BALBase.PR_ROLE_DELETE(RoleID))
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
