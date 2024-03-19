using Academy_2024.Models;
using Academy_2024.Repositories;
using Microsoft.AspNetCore.Mvc;




namespace Academy_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<Course>> Get()
        {
            return await _courseRepository.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> Get(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            return course == null ? NotFound() : course;
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Course data)
        {
            await _courseRepository.CreateAsync(data);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Course data)
        {
            var course = await _courseRepository.UpdateAsync(id, data);

            return course == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await _courseRepository.DeleteAsync(id) ? NoContent() : NotFound();
        }

        //DEBUG! => Author
        [HttpGet("Author")]
        public async Task<ActionResult<Course>> GetAuthor(User Author)
        {
            var author = await _courseRepository.GetByAuthorAsync(Author);

            return author == null ? NotFound() : author;
        }
    }
}
