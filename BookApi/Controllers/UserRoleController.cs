using BookApi.BAL;
using BookApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class UserRoleController : Controller
    {
        UserRole_BALBase bal = null;
        public UserRoleController()
        {
            bal = new UserRole_BALBase();
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<UserRoleModel> roles = bal.PR_ROLE_SELECT_ALL();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (roles.Count > 0 && roles != null)
            {
                //response.Add("status", true);
                //response.Add("message", "Data found.");
                //response.Add("data", roles);
                return Ok(roles);
            }
            return NotFound(roles);

        }
        [HttpGet("{RoleID}")]
        public IActionResult GetById(int RoleID)
        {
            UserRoleModel userRoleModel = bal.PR_ROLE_SELECT_BY_PK(RoleID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (userRoleModel != null)
            {
                response.Add("status", true);
                response.Add("message", "Data found.");
                response.Add("data", userRoleModel);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] UserRoleModel userRoleModel)
        {
            bool IsSuccess = bal.PR_ROLE_INSERT(userRoleModel);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data inserted Successfully.");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data not inserted");
                return NotFound(response);
            }
        }
        [HttpPut]
        public IActionResult Put(int RoleID, [FromBody] UserRoleModel userRoleModel)
        {
            userRoleModel.RoleID = RoleID;
            bool IsSuccess = bal.PR_ROLE_UPDATE(RoleID, userRoleModel);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Updated Successfully");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data not Found");
                return NotFound(response);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int RoleID)
        {
            bool IsSuccess = bal.PR_ROLE_DELETE(RoleID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Deleted Successfully");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data not Found");
                return NotFound(response);
            }
        }
    }
}
