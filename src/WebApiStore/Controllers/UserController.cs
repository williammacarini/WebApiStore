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
        public async Task<ActionResult> PostUserAsync([FromBody] UserDTO userDTO)
        {
            var result = await _userService.CreateAsync(userDTO);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetPeopleAsync()
        {
            var result = await _userService.GetPeopleAsync();
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
