using Microsoft.AspNetCore.Mvc;
using PlaceHolder.Models;
using PlaceHolder.Services;

namespace PlaceHolder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(ApiService apiService) : ControllerBase
    {
        private readonly ApiService _apiService = apiService;

        [HttpPost("users")]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            var createdUser = _apiService.CreateUser(user);
            return CreatedAtAction(nameof(_apiService.GetDataById), new { id = createdUser.Id }, createdUser);
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
    }
}
