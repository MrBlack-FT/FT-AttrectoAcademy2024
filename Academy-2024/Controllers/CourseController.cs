using Academy_2024.Models;
using Academy_2024.Repositories;
using Microsoft.AspNetCore.Mvc;




namespace Academy_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private CourseRepository _courseRepository;

        public CourseController()
        {
            _courseRepository = new CourseRepository();
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return _courseRepository.GetAll();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            var course = _courseRepository.GetById(id);

            return course == null ? NotFound() : course;
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] Course data)
        {
            _courseRepository.Create(data);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course data)
        {
            var user = _courseRepository.Update(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _courseRepository.Delete(id) ? NoContent() : NotFound();
        }
    }
}
