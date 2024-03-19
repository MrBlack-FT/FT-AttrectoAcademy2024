using Academy_2024.Data;
using Academy_2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Academy_2024.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<User>> GetAllAsync() => _context.Users.ToListAsync();
        /*
        public Task<List<User>> GetAllAsync()
        {
            return _context.Users.ToListAsync();
        } 
        */

        public Task<User?> GetByIdAsync(int id) => _context.Users.FirstOrDefaultAsync(user => user.Id == id);

        public Task<User?> GetByEmailAsync(string email) => _context.Users.FirstOrDefaultAsync(user => user.Email == email);

        //DateOfBirth added here.
        public async Task<List<User>> GetAdultsAsync()
        {
            return await _context.Users.Where(user => (user.DateOfBirth - DateTime.Now.Year) > 17).ToListAsync();

            /*
            var adults = new List<User>();
            foreach (var user in _context.Users)
            {
                if (user.DateOfBirth > 17)
                {
                    adults.Add(user);
                }
            }
            return adults;
            */
        }

        public async Task CreateAsync(User data)
        {
            await _context.Users.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync() => _context.SaveChangesAsync();
        /*
        public async Task<User?> UpdateAsync(int id, User data)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user != null)
            {
                //if (user.Id == id)
                //{
                user.Name = data.Name;
                user.Role = data.Role;
                //DateOfBirth added here.
                user.DateOfBirth = data.DateOfBirth;

                await _context.SaveChangesAsync();

                return user;
                //}S
            }
            return null;
        }
        */

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}