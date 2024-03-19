using Academy_2024.Dtos;
using Academy_2024.Services;
using Microsoft.AspNetCore.Mvc;

namespace Academy_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController 
        : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDto>> LoginAsync([FromBody] LoginDto loginDto)
        {
            var user = await _accountService.LoginAsync(loginDto);
            if (user is null)
            {
                return Unauthorized();
            }

            return Ok(_tokenService.CreateToken(user));
        }
    }
}
