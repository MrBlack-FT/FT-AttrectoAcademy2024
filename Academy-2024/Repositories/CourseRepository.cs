using Academy_2024.Data;
using Academy_2024.Models;

namespace Academy_2024.Repositories
{
    public class CourseRepository
    {
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
    }
}
