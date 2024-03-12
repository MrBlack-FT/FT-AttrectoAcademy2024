using Academy_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy_2024.Repositories
{
    public interface ICourseRepository
    {
        public Task CreateAsync(Course data);

        public Task<bool> DeleteAsync(int id);

        public Task<List<Course>> GetAllAsync();

        public Task<Course?> GetByIdAsync(int id);

        public Task<Course?> UpdateAsync(int id, Course data);
    }
}