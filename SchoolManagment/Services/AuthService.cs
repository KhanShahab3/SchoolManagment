using Microsoft.IdentityModel.Tokens;
using SchoolManagment.Models.ModelsDTO;
using SchoolManagment.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolManagment.Services
{
    public class AuthService:IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public AuthService(IUserRepository userRepeository,IConfiguration configuration)
        {
            _userRepository = userRepeository;
            _configuration = configuration;
        }
        public async Task<TokenResponse> Authenticate(Auth auth)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(auth.email);
                if (user == null || user.Password != auth.password)
                {
                    return null;
                }
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Role)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    //expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                    signingCredentials: creds);

                string eToken = new JwtSecurityTokenHandler().WriteToken(token);

                var response = new TokenResponse
                {
                    Token = eToken,
                    StatusCode = 200,
                    StatusMessage = "Authorized"
                };
                return response;
            }

            catch (Exception ex)
            {
                return new TokenResponse
                {
            Token=null,
            StatusCode=500,
            StatusMessage=ex.Message


                };
            }
        }
    }
}
