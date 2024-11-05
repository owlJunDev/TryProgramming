using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [Authorize]
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return Ok();
        }
        [Authorize]
        public ActionResult Logout()
        {
            return Ok();
        }
    }
}