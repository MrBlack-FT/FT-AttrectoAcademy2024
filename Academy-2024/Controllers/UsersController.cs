using Academy_2024.Models;
using Academy_2024.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userRepository.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            return user == null ? NotFound() : user;
        }

        //Get Adults added here.
        [HttpGet("ADULTS")]
        public async Task<IEnumerable<User>> GetAdults()
        {
            return await _userRepository.GetAdultsAsync();
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User data)
        {
            await _userRepository.CreateAsync(data);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User data)
        {
            var user = await _userRepository.UpdateAsync(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return await _userRepository.DeleteAsync(id) ? NoContent() : NotFound();
        }
    }
}
