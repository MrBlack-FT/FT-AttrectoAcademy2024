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

        public Task<List<User>> GetAllAsync()
        {
            return _context.Users.ToListAsync();
        }

        public Task<User?> GetByIdAsync(int id) => _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        //Age added here.
        //Users where to list
        //ToList
        public List<User> GetAdultsAsync()
        {
            var adults = new List<User>();
            foreach (var user in _context.Users)
            {
                if (user.Age > 17)
                {
                    adults.Add(user);
                }
            }
            return adults;
        }

        public async Task CreateAsync(User data)
        {
            await _context.Users.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> UpdateAsync(int id, User data)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                if (user.Id == id)
                {
                    user.FirstName = data.FirstName;
                    user.LastName = data.LastName;
                    //Age added here.
                    user.Age = data.Age;

                    _context.SaveChanges();

                    return user;
                }
            }
            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
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