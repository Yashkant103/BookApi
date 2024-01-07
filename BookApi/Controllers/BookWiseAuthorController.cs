using BookApi.BAL;
using BookApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BookWiseAuthorController : Controller
    {
        BookWiseAuthor_BALBase bal = null;
        public BookWiseAuthorController()
        {
            bal = new BookWiseAuthor_BALBase();
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<BookWiseAuthorModel> roles = bal.PR_BookWiseAuthor_SELECT_ALL();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (roles.Count > 0 && roles != null)
            {
                response.Add("status", true);
                response.Add("message", "Data found.");
                response.Add("data", roles);
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
        [HttpGet("{BookWiseAuthorID}")]
        public IActionResult Get(int BookWiseAuthorID)
        {
            BookWiseAuthorModel bookWiseAuthorModel = bal.PR_BookWiseAuthor_SELECT_BY_PK(BookWiseAuthorID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (bookWiseAuthorModel != null)
            {
                response.Add("status", true);
                response.Add("message", "Data found.");
                response.Add("data", bookWiseAuthorModel);
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
        public IActionResult Post([FromBody] BookWiseAuthorModel bookWiseAuthorModel)
        {
            bool IsSuccess = bal.PR_BookWiseAuthor_INSERT(bookWiseAuthorModel);
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
        public IActionResult Put(int BookWiseAuthorID, [FromBody] BookWiseAuthorModel bookWiseAuthorModel)
        {
            bookWiseAuthorModel.BookWiseAuthorID = BookWiseAuthorID;
            bool IsSuccess = bal.PR_BookWiseAuthor_UPDATE(BookWiseAuthorID, bookWiseAuthorModel);
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
        public IActionResult Delete(int BookWiseAuthorID)
        {
            bool IsSuccess = bal.PR_BookWiseAuthor_DELETE(BookWiseAuthorID);
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
