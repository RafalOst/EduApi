using EduApi.Models.Dto;
using EduApi.Models.Repositories.Interfaces.ModelInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        /// <summary>
        /// POST method register new account for regular user and add to database
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "email": "user@user.com",
        ///        "password": "User123",
        ///        "firstName":"User",
        ///        "lastName":"User",
        ///        "confirmPassword": "User123"
        ///     }
        ///
        /// </remarks>
        /// <param name="dto"></param>
        /// <returns>Returns endpoint to new object</returns>
        /// <response code="200">Returns endpoint to new user</response>
        [HttpPost("register/user")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDto dto)
        {
            await _accountRepository.RegisterUser(dto);

            return Ok();
        }

        /// <summary>
        /// POST method register new account for admin and add to database
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "email": "admin@admin.com",
        ///        "password": "Admin1",
        ///        "firstName":"Admin",
        ///        "lastName":"Admin",
        ///        "confirmPassword": "Admin1"
        ///     }
        /// </remarks>
        /// <param name="dto"></param>
        /// <returns>Returns endpoint to new object</returns>
        /// <response code="200">Returns endpoint to new admin</response>
        [HttpPost("register/admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RegisterAdmin([FromBody] RegisterUserDto dto)
        {
            await _accountRepository.RegisterAdmin(dto);

            return Ok();
        }

        /// <summary>
        /// POST method pass user login
        /// </summary>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "email": "admin@admin.com",
        ///        "password": "Admin1"
        ///     }
        /// </remarks>
        /// <param name="dto"></param>
        /// <returns>Returns JWT token</returns>
        /// <response code="200">Returns JWT token</response>
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            string token = await _accountRepository.GenerateJwt(dto);

            return Ok(token);
        }
    }
}
