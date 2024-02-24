using BookApi.BAL;
using BookApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class GenreController : Controller
    {
        Genre_BALBase bal = null;
        public GenreController()
        {
            bal = new Genre_BALBase();
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<GenreModel> genres = bal.PR_GENRE_SELECT_ALL();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (genres.Count > 0 && genres != null)
            {
                //response.Add("status", true);
                //response.Add("message", "Data found.");
                //response.Add("data", genres);
                return Ok(genres);
            }
            return NotFound(genres);
        }
        [HttpGet("{GenreID}")]
        public IActionResult GetById(int GenreID)
        {
            GenreModel genreModel = bal.PR_GENRE_SELECT_BY_PK(GenreID);
            //Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (genreModel != null)
            {
                //response.Add("status", true);
                //response.Add("message", "Data found.");
                //response.Add("data", genreModel);
                return Ok(genreModel);
            }
            return NotFound(genreModel);
        }
        [HttpPost]
        public IActionResult Post([FromBody] GenreModel genreModel)
        {
            bool IsSuccess = bal.PR_GENRE_INSERT(genreModel);
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
        public IActionResult Put([FromBody] GenreModel genreModel)
        {
            //genreModel.GenreID = GenreID;
            bool IsSuccess = bal.PR_GENRE_UPDATE(genreModel);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                //response.Add("status", true);
                //response.Add("message", "Data Updated Successfully");
                return Ok(genreModel);
            }
            return NotFound(genreModel);

        }
        [HttpDelete]
        public IActionResult Delete(int GenreID)
        {
            bool IsSuccess = bal.PR_GENRE_DELETE(GenreID);
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
