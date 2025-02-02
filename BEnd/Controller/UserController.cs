using BEnd.DTO;
using BEnd.Model;
using BEnd.Repository;
using BEnd.Service;
using Microsoft.AspNetCore.Mvc;

namespace BEnd.Controller
{
    [Route("api/user/")]
    public class UserController : ControllerBase
    {
        public readonly UserRepository userRepo;
        public readonly UserService userServ;

        public UserController(UserRepository userRepo, UserService userServ)
        {
            this.userRepo = userRepo;
            this.userServ = userServ;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateUser(UserDTO userDTO)
        {
            User user = await userRepo.GetUserByUserNmae(userDTO.username);
            if (user != null)
                return Unauthorized("имя пользователя занято");
            try
            {
                user = new User(userDTO.username, DateTime.UtcNow);
                PassHash passHash = new PassHash() { passHash = await userServ.HashPassword(userDTO.pass) };
                await userRepo.CreateUser(user, passHash);
            }
            catch (Exception exp)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}