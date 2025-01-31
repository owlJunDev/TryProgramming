using BEnd.DTO;
using BEnd.Model;
using BEnd.Repository;
using BEnd.Service;
using Microsoft.AspNetCore.Mvc;

namespace BEnd.Controller
{
    public class AuthController : ControllerBase 
    {
        public readonly UserRepository userRepo;
        public readonly UserService userServ;

        public AuthController(UserRepository userRepo) {
            this.userRepo = userRepo;
        }

        [HttpPost]
        public async Task<ActionResult> LogIn(UserDTO userDTO) {
            User user = await userRepo.GetUserByUserNmae(userDTO.username);
            if (user == null)
                return NotFound();
            PassHash ph = await userRepo.GetUserPassH(user.id);
            if (await userServ.VerifyHashedPassword(ph.passHash, userDTO.pass)) {
                //TODO: get JWT
                return Ok();
            }
            return Unauthorized("не правильный пароль или имя пользователя");
        }
    }
}