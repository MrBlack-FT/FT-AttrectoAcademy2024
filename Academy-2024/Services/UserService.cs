using Academy_2024.Dtos;
using Academy_2024.Models;
using Academy_2024.Repositories;

namespace Academy_2024.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task CreateAsync(UserDto data) => _userRepository.CreateAsync(MapToModel(data));

        public Task<bool> DeleteAsync(int id)=> _userRepository.DeleteAsync(id);

        public async Task<List<UserDto>> GetAdultsAsync()
        {
            //return await _context.Users.Where(user => (user.DateOfBirth - DateTime.Now.Year) > 17).ToListAsync();

            var users = await _userRepository.GetAllAsync();

            return users.Select(MapToDto).Where(user => (user.DateOfBirth - DateTime.Now.Year) > 17).ToList();

            //throw new NotImplementedException();
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(MapToDto).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            return user != null ? MapToDto(user) : null;
        }

        public Task<User?> GetByEmailAsync(string email) => _userRepository.GetByEmailAsync(email);

        public async Task<User?> UpdateAsync(int id, UserDto data)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if(user != null)
            {
                user.Name = data.Name;
                //user.Role = data.Role;
                user.Email = data.Email;
                //user.Password = data.Password;
                //user.DateOfBirth = data.DateOfBirth;

                await _userRepository.UpdateAsync();
            }
            return user;
        }

        private static UserDto MapToDto(User user) => new()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            //DateOfBirth = user.DateOfBirth,
            //Role = user.Role
        };
        private static User MapToModel(UserDto userDtio) => new()
        {
            Id = userDtio.Id,
            Name = userDtio.Name,
            Email = userDtio.Email,
            Password = userDtio.Password,
            DateOfBirth = userDtio.DateOfBirth,
            Role = userDtio.Role
        };
    }
}
