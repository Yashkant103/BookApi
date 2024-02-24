using BookApi.BAL;
using BookApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class AuthorController : Controller
    {
        Author_BALBase bal = null;
        public AuthorController()
        {
            bal = new Author_BALBase();
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<AuthorModel> authors = bal.PR_AUTHOR_SELECT_ALL();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (authors.Count > 0 && authors != null)
            {
                //response.Add("status", true);
                //response.Add("message", "Data found.");
                //response.Add("data", authors);
                return Ok(authors);
            }
            return Ok(authors);
        }
        [HttpGet("{AuthorID}")]
        public IActionResult GetbyId(int AuthorID)
        {
            AuthorModel authorModel = bal.PR_AUTHOR_SELECT_BY_PK(AuthorID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (authorModel != null)
            {
                //response.Add("status", true);
                //response.Add("message", "Data found.");
                //response.Add("data", authors);
                return Ok(authorModel);
            }
            return NotFound(authorModel);
        }
        [HttpPost]
        public IActionResult Post([FromBody] AuthorModel authorModel)
        {
            bool IsSuccess = bal.PR_AUTHOR_INSERT(authorModel);
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
        public IActionResult Put([FromBody] AuthorModel authorModel)
        {
            //authorModel.AuthorID = AuthorID;
            bool IsSuccess = bal.PR_AUTHOR_UPDATE(authorModel);
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
        public IActionResult Delete(int AuthorID)
        {
            bool IsSuccess = bal.PR_AUTHOR_DELETE(AuthorID);
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