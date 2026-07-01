using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using JWT.Exceptions;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace MyTool
{
	//这个TokenInfo和TokenHelper目前暂时不用了
	public class TokenInfo
    {
        public TokenInfo(string UserName, string Pwd)
        {
            this.UserName = UserName;
			this.Pwd = Pwd;
        }
        public string UserName { get; set; }
        public string Pwd { get; set; }
    }

    /// <summary>
    /// 这里没有expire？
    /// </summary>
    public class TokenHelper
    {
        public static string SecretKey = "bqsid123k12s0h1d3uhf493fh02hdd102h9s3h38ff";//这个服务端加密秘钥 属于私钥
        //private static IJsonSerializer myJson = new JavaScriptSerializer();
        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        public static string GenToken(TokenInfo M)
        {
            //var payload = new Dictionary<string, dynamic>
            //{
            //    {"UserName", M.UserName},//用于存放当前登录人账户信息
            //    {"UserPwd", M.Pwd}//用于存放当前登录人登录密码信息
            //};            
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            return encoder.Encode(M, SecretKey);
        }
        /// <summary>
        /// 验证Token
        /// token:来自前台的请求带的token
        /// </summary>
        /// <returns></returns>
        public static string DecodeToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return "Token has invalid signature";
            //去掉前面的Bearer
            if (token != null && token.StartsWith("Bearer"))
                token = token.Substring("Bearer ".Length).Trim();
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
                var json = decoder.Decode(token, SecretKey, verify: true);

                TokenInfo info = JsonConvert.DeserializeObject<TokenInfo>(json);
                //这里要比对info和session里面存的结果么？
                return "Token is true";
            }
            catch (TokenExpiredException)
            {
                return "Token has expired";
            }
            catch (SignatureVerificationException)
            {
                return "Token has invalid signature";
            }
        }
			/// <summary>
			/// 验证Token
			/// token:来自前台的请求带的token
			/// </summary>
			/// <returns></returns>
		public static bool DecodeToken(string token, string key, ref string msg)
		{
			if (string.IsNullOrEmpty(token))
            {
				msg = "Token has invalid signature";
				return false;
			}
				
			//去掉前面的Bearer
			if (token != null && token.StartsWith("Bearer"))
				token = token.Substring("Bearer ".Length).Trim();
			try
			{
				IJsonSerializer serializer = new JsonNetSerializer();
				IDateTimeProvider provider = new UtcDateTimeProvider();
				IJwtValidator validator = new JwtValidator(serializer, provider);
				IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
				IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
				IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
				msg = decoder.Decode(token, key, verify: true);
				
				return true;
			}
			catch (TokenExpiredException)
			{
                msg = "Token has expired";
				return false;
			}
			catch (SignatureVerificationException)
			{				
				msg = "Token has invalid signature";
				return false;
			}
		}


    }
}
