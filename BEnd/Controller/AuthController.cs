using BEnd.DTO;
using BEnd.Model;
using BEnd.Repository;
using BEnd.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BEnd.Controller
{
    [Route("api/auth/")]
    public class AuthController : ControllerBase
    {
        public readonly UserRepository userRepo;
        public readonly UserService userServ;

        public AuthController(UserRepository userRepo, UserService userServ)
        {
            this.userRepo = userRepo;
            this.userServ = userServ;
        }


        [HttpPost("login")]
        public async Task<ActionResult> LogIn([FromBody] UserDTO userDTO)
        {
            if (userDTO == null || userDTO.pass == null || userDTO.username == null)
                return Unauthorized("не правильный пароль или имя пользователя");

            User user = await userRepo.GetUserByUserNmae(userDTO.username);
            if (user == null)
                return Unauthorized("не правильный пароль или имя пользователя");

            PassHash ph = await userRepo.GetUserPassH(user.id);
            if (ph == null)
                return Unauthorized("не правильный пароль или имя пользователя");

            if (await userServ.VerifyHashedPassword(ph.passHash, userDTO.pass))
            {
                System.Console.WriteLine("Auth");
                var claims = new List<Claim> {new Claim(ClaimTypes.Name, userDTO.username) };var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), //время жизни токена 2 минуты
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                return Ok(Results.Json(new {
                    access_token = encodedJwt,
                    username = userDTO.username
                }));
            }
            return Unauthorized("не правильный пароль или имя пользователя");
        }
    }
}