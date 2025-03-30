using Microsoft.AspNetCore.Mvc;
using PlaceHolder.Models;
using PlaceHolder.Services;

namespace PlaceHolder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController(ApiService apiService) : ControllerBase
    {
        private readonly ApiService _apiService = apiService;

        [HttpGet("posts")]
        public ActionResult<Post>? GetData([FromQuery] int userId, [FromQuery] string title)
        {
            var post =  _apiService.GetDataByUserAndTitle(userId, title);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);

        }

        [HttpGet("posts/{id}")]
        public ActionResult<Post> GetDataById(int id)
        {
            var post = _apiService.GetDataById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpDelete("posts/{id}")]
        public  IActionResult DeletePost(int id)
        {
             _apiService.DeletePostById(id);
            return NoContent();
        }
    }
}
