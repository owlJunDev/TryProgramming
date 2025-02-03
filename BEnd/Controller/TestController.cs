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
            return Ok("кто там?");
        }

        [HttpGet("free")]
        public async Task<ActionResult> TestFree()
        {
            return Ok("тук тук");
        }
    }
}