using Microsoft.AspNetCore.Mvc;
using Store.Service.DTOs;
using Store.Service.Services.Interfaces;

namespace WebApiStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserAsync([FromBody] UserDTO userDTO)
        {
            var result = await _userService.CreateAsync(userDTO);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UserDTO userDTO)
        {
            var result = await _userService.UpdateUserAsync(userDTO);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<ActionResult> DeleteUserAsync(int userId)
        {
            var result = await _userService.DeleteUserAsync(userId);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetUserAsync()
        {
            var result = await _userService.GetUserAsync();
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult> GetUserByIdAsync(int userId)
        {
            var result = await _userService.GetUserByIdAsync(userId);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
