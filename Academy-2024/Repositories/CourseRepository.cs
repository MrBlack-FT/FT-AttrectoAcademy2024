﻿using Academy_2024.Data;
using Academy_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy_2024.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        private static List<Course> Courses = new List<Course>
        {
            new Course
            {
                Id = 1,
                Name ="TestCourse1",
                Description = "This is the TestCourse1."
            }
        };

        public Task<List<Course>> GetAllAsync()
        {
            return _context.Courses.ToListAsync();
        }

        public Task<Course?> GetByIdAsync(int id) => _context.Courses.FirstOrDefaultAsync(x => x.Id == id);

        public async Task CreateAsync(Course data)
        {
            await _context.Courses.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task<Course?> UpdateAsync(int id, Course data)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course != null)
            {
                //if (course.Id == id)
                //{
                    course.Name = data.Name;
                    course.Description = data.Description;

                    await _context.SaveChangesAsync();

                    return course;
                //}
            }
            return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        //Old version
        /*
        public List<Course> GetAll()
        {
            return Courses;
        }

        public Course? GetById(int id)
        {
            foreach (var course in GetAll())
            {
                if (course.Id == id)
                {
                    return course;
                }
            }

            return null;
        }

        public void Create(Course data)
        {
            Courses.Add(data);
        }

        public Course? Update(int id, Course data)
        {
            foreach (var course in GetAll())
            {
                if (course.Id == id)
                {
                    course.Id = data.Id;
                    course.Name = data.Name;
                    course.Description = data.Description;

                    return course;
                }
            }

            return null;
        }

        public bool Delete(int id)
        {
            foreach (var course in GetAll())
            {
                if (course.Id == id)
                {
                    Courses.Remove(course);

                    return true;
                }
            }

            return false;
        }
        */
    }
}
