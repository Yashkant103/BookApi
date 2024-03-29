﻿using BookApi.BAL;
using BookApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class UserController : Controller
    {
        User_BALBase bal = null;
        public UserController()
        {
            bal = new User_BALBase();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<UserModel> users = bal.PR_USER_SELECT_ALL();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (users.Count > 0 && users != null)
            {
                response.Add("status", true);
                response.Add("message", "Data found.");
                response.Add("data", users);
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
        [HttpGet("{UserID}")]
        public IActionResult GetByID(int UserID)
        {
            UserModel userModel = bal.PR_USER_SELECT_BY_PK(UserID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (userModel.UserID != null)
            {
                response.Add("status", true);
                response.Add("message", "data found.");
                response.Add("data", userModel);
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
        public IActionResult Post([FromBody] UserModel userModel)
        {
            bool IsSuccess = bal.PR_USER_INSERT(userModel);
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
        public IActionResult Put([FromBody] UserModel userModel)
        {
            //userModel.UserID = UserID;
            bool IsSuccess = bal.PR_USER_UPDATE(userModel);
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
        public IActionResult Delete(int UserID)
        {
            bool IsSuccess = bal.PR_USER_DELETE(UserID);
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
        [HttpPost]
        public IActionResult Login([FromBody] Login_Model login_Model)
        {
            Login_BALBase login_BALBase = new Login_BALBase();
            return Ok(login_BALBase.PR_USER_LOGIN(login_Model.UserName, login_Model.UserPassword));
        }

    }

}
