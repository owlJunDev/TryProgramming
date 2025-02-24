using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BEnd.Controller
{
    [Route("test/")]
    public class TestController : ControllerBase
    {
        public TestController() { }

        [HttpGet("auth")]
        [Authorize]
        public async Task<ActionResult> TestAuth()
        {
            var user = HttpContext.User;
            Console.WriteLine("wwwwwwwwwwwwwwwwwwwwwwwww");
            Console.WriteLine(user.FindFirstValue(ClaimTypes.Name));
            Console.WriteLine("wwwwwwwwwwwwwwwwwwwwwwwww");
            return Ok("кто там?");
        }

        [HttpGet("free")]
        public async Task<ActionResult> TestFree()
        {
            return Ok("тук тук");
        }
    }
}