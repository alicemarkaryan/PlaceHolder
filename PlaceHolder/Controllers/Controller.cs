using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using PlaceHolder.Models;
using PlaceHolder.Services;
using System.Text;

namespace PlaceHolder.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class Controller(ApiService apiService) : ControllerBase
    {

        private readonly ApiService _apiService = apiService;

        [HttpGet("posts")]
        public  ActionResult<List<Post>> GetData([FromQuery] int userId, [FromQuery] string title)
        {
            return  _apiService.GetDataByUserAndTitle(userId, title);
          
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

        [HttpPost("users")]
        public ActionResult<List<User>> CreateUser([FromBody] User user)
        {
            return _apiService.CreateUser(user);
        }

        [HttpPut("users/{id}")]
        public ActionResult<User> UpdateUser(int id, [FromBody] User updatedUser)
        {
            var result = _apiService.UpdateUser(id, updatedUser);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("posts/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _apiService.DeletePostById(id);
            return Ok();
        }
    }
}
