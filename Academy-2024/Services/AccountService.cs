using Academy_2024.Dtos;
using Academy_2024.Models;

namespace Academy_2024.Services
{
    public class AccountService
        : IAccountService
    {
        private readonly IUserService _userService;

        public AccountService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userService.GetByEmailAsync(loginDto.Email);

            if (user is null || user.Password != loginDto.Password)
            {
                return null;
            }

            return user;
        }
    }
}
