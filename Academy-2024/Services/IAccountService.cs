using Academy_2024.Dtos;
using Academy_2024.Models;

namespace Academy_2024.Services
{
    public interface IAccountService
    {
        Task<User?> LoginAsync(LoginDto LoginDto);
    }
}
