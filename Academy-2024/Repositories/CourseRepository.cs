using Academy_2024.Data;
using Academy_2024.Models;

namespace Academy_2024.Repositories
{
    public class CourseRepository
    {
        private readonly ApplicationDbContext _context;

        private static List<Course> Courses = new List<Course>
        {
            new Course
            {
                Id = 1,
                Name ="TestCourse1",
                Description = "This is the TestCourse1."
            }
        };

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course? GetById(int id) => _context.Courses.FirstOrDefault(x => x.Id == id);

        public void Create(Course data)
        {
            _context.Courses.Add(data);
            _context.SaveChanges();
        }

        public Course? Update(int id, Course data)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);
            if (course != null)
            {
                if (course.Id == id)
                {
                    course.Name = data.Name;
                    course.Description = data.Description;

                    _context.SaveChanges();

                    return course;
                }
            }
            return null;
        }

        public bool Delete(int id)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();

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
