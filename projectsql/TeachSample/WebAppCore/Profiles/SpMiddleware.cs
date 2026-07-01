using AutoMapper;
using WebAppCore.DbModel;
using WebAppCore.ViewModels;

namespace WebAppCore.Profiles
{
    public class SpMiddleware
    {
        private readonly RequestDelegate _next;

        public SpMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string s = httpContext.Request.Path;

            byte[] result;
			//下面这个TokenInfo应该不用了，因为用jwt，不需要用session来判断，可以用token来判断
			httpContext.Session.TryGetValue("TokenInfo", out result);
            s = s.ToLower();
            //类似访问登录页面的直接通过
            if (s.Contains("login/index") || s.Contains("user/login")
                || s.Contains("login/signup") || s.Contains("login/userregister")
                || s.Contains("home/index") || s.Contains("user/getcaptcha"))
            {
                await _next(httpContext);
            }
            else
            {
                //非登录页面，判断是否已经存在Session键值，如果不存在，跳转到登录页面，你也可以返回其他信息
                if (result == null)
                {
					//string loginhtml = "<html><head></head><body><script>window.location.href='/Login/Index'</script></body></html>";
					string loginhtml = "../Login/Index";
                    await httpContext.Response.WriteAsync(loginhtml);

                }
                else  //如果存在Session键值，通过请求
                {
                    await _next(httpContext);
                }
            }


        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SpMiddlewareExtensions
    {
        public static IApplicationBuilder UseSpMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SpMiddleware>();
        }
    }
}