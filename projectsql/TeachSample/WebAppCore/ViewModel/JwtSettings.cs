
namespace WebAppCore.ViewModels
{
	public class JwtSettings
	{
		public string SecretKey { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public int AccessTokenExpirationMinutes { get; set; }
		public int RefreshTokenExpirationDays { get; set; }
	}
		
	/// <summary>
	/// 用于存储到token中的数据
	/// </summary>
	public class AuthUser
	{
		//下面注释掉的暂时不用
		//public int Id { get; set; }
		public string Username { get; set; }
		//public string Name { get; set; }
		//public string Email { get; set; }
		public string Password { get; set; }
		public string[] Roles { get; set; }
	}


	/// <summary>
	/// token解析结果
	/// </summary>
	public class TokenParse
	{
		public string unique_name { get; set; }
		public long nbf { get; set; }		
		public long exp { get; set; }
		public long iat { get; set; }
	}
}