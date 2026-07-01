using WebAppCore.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAppCore.Service
{
	public class AuthService
	{
		//通过依赖注入的方式，将配置参数带入到类中
		private readonly JwtSettings _jwtSettings;

		public AuthService(IOptions<JwtSettings> jwtSettings)
		{
			_jwtSettings = jwtSettings.Value;
		}


		/// <summary>
		/// 用于令牌的生成
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public string GenerateToken(AuthUser user)
		{
			var handler = new JwtSecurityTokenHandler();
			var privateKey = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);

			var credentials = new SigningCredentials(
						new SymmetricSecurityKey(privateKey),
						SecurityAlgorithms.HmacSha256);


			var tokenDescriptor = new SecurityTokenDescriptor
			{
				SigningCredentials = credentials,
				Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes),
				Subject = GenerateClaims(user)
			};

			var token = handler.CreateToken(tokenDescriptor);
			return handler.WriteToken(token);

		}

		//准备给Token中的值
		private static ClaimsIdentity GenerateClaims(AuthUser user)
		{
			var ci = new ClaimsIdentity();

			//ci.AddClaim(new Claim("id", user.Id.ToString()));
			ci.AddClaim(new Claim(ClaimTypes.Name, user.Username));			
			//ci.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));
			//ci.AddClaim(new Claim(ClaimTypes.Email, user.Email));

			foreach (var role in user.Roles)
				ci.AddClaim(new Claim(ClaimTypes.Role, role));

			return ci;
		}
	}
}

