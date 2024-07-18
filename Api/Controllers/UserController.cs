using Api.Dto;
using Business;
using Business.Exceptions;
using Dal.Exceptions;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IBussinesUser _business;
        private readonly IConfiguration _configuration;

        public UserController(ILogger<UserController> logger, IConfiguration configuration, IBussinesUser business)
        {
            _logger = logger;
            _configuration = configuration;
            _business = business;
        }

        /// <summary>
        /// Consulta un usuario dado su login y contraseña
        /// </summary>
        /// <param name="data">Usuario y contraseña del usaurio</param>
        /// <returns>Usuario con los datos cargados desde la base de datos</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public LoginResponse ReadByLoginAndPassword(LoginRequest data)
        {
            try
            {
                LoginResponse result = new();
                User user = _business.ReadByEmailAndPassword(new() { Email = data.Login }, data.Password, _configuration["Aes:Key"] ?? "", _configuration["Aes:IV"] ?? "");
                if (user.Id != 0)
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? ""));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    IList<Role> roles = _business.ListRoles("", "", 100, 0, user).List;

                    var claims = new[] {
                        new Claim("id", user.Id.ToString()),
                        new Claim("email", user.Email),
                        new Claim("name", user.Name),
                        new Claim("roles", string.Join(",", roles.Select(x => x.Id).ToList()))
                };

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: credentials);

                    result = new() { Valid = true, Token = new JwtSecurityTokenHandler().WriteToken(token) };
                }
                //LogInfo("data: " + JsonSerializer.Serialize(data), JsonSerializer.Serialize(result));
                return result;
            }
            catch (PersistentException e)
            {
                //LogError(e, "P", "data: " + JsonSerializer.Serialize(data));
            }
            catch (BusinessException e)
            {
                //LogError(e, "B", "data: " + JsonSerializer.Serialize(data));
            }
            catch (Exception e)
            {
                //LogError(e, "A", "data: " + JsonSerializer.Serialize(data));
            }
            Response.StatusCode = 500;
            return new();
        }
    }
}
