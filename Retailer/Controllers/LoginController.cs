using EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Retailer.Login;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Retailer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsers<Users> _userServices;
        private readonly IConfiguration _config;
        public LoginController(IUsers<Users> userServices, IConfiguration config)
        {
            _userServices = userServices;
            _config = config;
        }
        // GET: api/<LoginController>
        [HttpGet]
        public async Task<string> Get(string UserName, string Password)
        {
            var token = string.Empty;
            var userObj = new Users();
            if (!string.IsNullOrEmpty(UserName))
                userObj.UserName = UserName;
            if (!string.IsNullOrEmpty(Password))
                userObj.Password = Password;
            userObj.IsActive = true;

            var userList = await _userServices.GetService(userObj);

            Users user = new Users();

            if (userList != null) 
                user = (Users)userList.FirstOrDefault();

            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                var tokenString = GenerateJSONWebToken(user);
                token = tokenString;
            }

            return token;
        }

        private string GenerateJSONWebToken(Users users)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Sub, users.UserName),
        new Claim(JwtRegisteredClaimNames.Email, users.EmailAddress),
        new Claim(JwtRegisteredClaimNames.Sid, users.Id.ToString()),
        
       // new Claim("DateOfJoing", usersDto.DateOfJoing.ToString("yyyy-MM-dd")),
        //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token); ;
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public async Task<bool> Post(Users input)
        {
            try
            {
                Users objUsersDto = new Users();
                objUsersDto.Id = Guid.NewGuid();
                objUsersDto.UpdatedDate = DateTime.Now;
                objUsersDto.CreatedDate = DateTime.Now;
                objUsersDto.IsActive = true;
                objUsersDto.UserName = input.UserName;
                objUsersDto.Password = input.Password;
                objUsersDto.EmailAddress = input.EmailAddress;
                objUsersDto.LastLogin = null;
                objUsersDto.RegistrationDate = DateTime.Now;
                objUsersDto.DateOfBirth = input.DateOfBirth;
                objUsersDto.FirstName = input.FirstName;
                objUsersDto.LastName = input.LastName;
                objUsersDto.Gender = input.Gender;

                var IsSave = await _userServices.InsertAsynch(objUsersDto);

                if (IsSave)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
