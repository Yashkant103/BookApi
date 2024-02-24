using BookApi.BAL;
using BookApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class BookController : Controller
    {
        Book_BALBase bal = null;
        public BookController()
        {
            bal = new Book_BALBase();
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<BookModel> books = bal.PR_BOOK_SELECT_ALL();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (books.Count > 0 && books != null)
            {
                //response.Add("status", true);
                //response.Add("message", "Data found.");
                //response.Add("data", books);
                return Ok(books);
            }
            return NotFound(books);

        }
        [HttpGet("{BookID}")]
        public IActionResult GetById(int BookID)
        {
            BookModel bookModel = bal.PR_BOOK_SELECT_BY_PK(BookID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (bookModel.BookID != null)
            {
                //response.Add("status", true);
                //response.Add("message", "Data found.");
                //response.Add("data", bookModel);
                return Ok(bookModel);
            }
            return NotFound(bookModel);
        }
        [HttpPost]
        public IActionResult Post([FromBody] BookModel bookModel)
        {
            bool IsSuccess = bal.PR_BOOK_INSERT(bookModel);
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
        public IActionResult Put([FromBody] BookModel bookModel)
        {
            //bookModel.BookID = BookID;
            bool IsSuccess = bal.PR_BOOK_UPDATE(bookModel);
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
        public IActionResult Delete(int BookID)
        {
            bool IsSuccess = bal.PR_BOOK_DELETE(BookID);
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
