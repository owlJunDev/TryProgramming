using Microsoft.AspNetCore.Mvc;
// using Backend.DTO;
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/user")]
    public class UserController : Controller {

        private readonly UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            System.Console.WriteLine("GET one");
            var result = await userRepository.GetUser(id);
            return result == null ? NoContent() : Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            System.Console.WriteLine("GET one");
            var result = await userRepository.GetAll();
            return result == null ? NoContent() : Ok(result);
        }

    }
}