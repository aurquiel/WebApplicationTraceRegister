using ClassLibraryDataAccess.Data;
using ClassLibraryDataAccess.Models;
using ClassLibraryTools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApplicationTraceRegister.Models.Output;

namespace WebApplicationTraceRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserData _userData;

        public AccessController(IConfiguration configuration, IUserData userData)
        {
            this._configuration = configuration;
            this._userData = userData;
        }

        private string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], null,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<GeneralAnswer> UserLoginToken(UserLoginToken user)
        {
            try
            {
                user.usr_password = Hash256.HashOfUserPassword(user.usr_password);
                int userId = await _userData.AcccesLoginToken(user.usr_alias, user.usr_password);
                if (userId != 0)
                {
                    var userDb = await _userData.Get(userId);
                    var token = GenerateToken();

                    return new GeneralAnswer(true, "Exitoso: usuario y token obtenidos con exito.", new { User = userDb, Token = token });
                }
                else
                {
                    return new GeneralAnswer(false, "Error: usuario sin autorizacion.", new { User = new User(), Token = string.Empty });
                }
            }
            catch (Exception ex)
            {
                return new GeneralAnswer(false, "Error al obtener usuario y token, Excepcion: " + ex.Message, new { User = new User(), Token = string.Empty });
            }

        }
    }
}
