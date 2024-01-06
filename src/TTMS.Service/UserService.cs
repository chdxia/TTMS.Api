using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TTMS.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _secretKey;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _issuer = configuration.GetSection("JwtConfig:Issuer").Value;
            _audience = configuration.GetSection("JwtConfig:Audience").Value;
            _secretKey = configuration.GetSection("JwtConfig:Key").Value;
        }

        public async Task<UserLoginResponse> UserLoginAsync(UserLoginRequest request)
        {
            var result = await _userRepository.UserLoginAsync(request);
            
            var claims = new[] // 创建声明集合
            {
                new Claim(JwtRegisteredClaimNames.Sub, result.Id.ToString()), // 用户id;用户唯一标识
                new Claim("Account", result.Account ?? ""),
                new Claim("UserName", result.UserName ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Jwt Id;Jwt唯一标识
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64) //  Jwt的发布时间
            };

            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey)); // 创建密钥

            var tokenOptions = new JwtSecurityToken( // 创建 JWT 配置
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7), // 7天到期
                signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature) // 创建签名凭证
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions); // 生成 JWT 令牌

            result.AccessToken = tokenString;

            return result;
        }
    }
}
