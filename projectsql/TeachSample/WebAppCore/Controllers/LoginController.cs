using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCore.DbModel;
using Autofac;
using WebAppCore.ViewModels.DeepSeek;
using WebAppCore.Service;
using MyTool;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using WebAppCore.ViewModels;
using Newtonsoft.Json;

namespace WebAppCore.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAiAppService _service;
		private readonly ISysUsersService _userService;

		/// <summary>
		///
		/// </summary>	
		public LoginController(IAiAppService service, ISysUsersService userService)
        {
			_service = service;
			_userService = userService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult MainUser()
		{
			return View();
		}

		public IActionResult MainStock()
		{
			return View();
		}

		public IActionResult Main()
		{
			string userName = _userService.GetTokenUserName(HttpContext.Request.Headers["Authorization"]);
			if (string.IsNullOrEmpty(userName))
			{
				string token = Request.Cookies["token"];
				userName = _userService.GetTokenUserName(token);
			}

			//这里最好是读取比较全的用户信息
			SysUsersModel user = new SysUsersModel();
			user.username = userName;
			ViewBag.user = user;
			return View();
		}

		[HttpGet]
		public IActionResult Contacts()
		{
			return View();
		}

		/// <summary>
		/// 下面这个不用了
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult login([FromBody] LoginReq req)
		{
			VueResMsg<string> resMsg = new VueResMsg<string>();
			if (string.IsNullOrEmpty(req.username) || string.IsNullOrEmpty(req.password))
			{
				resMsg.SetFail(-1, "账号或者密码为空！");
			}
			else if (req.username.Equals("admin") /*&& password.Equals("123456")*/)
			{
				resMsg.SetOK();
			}
			else
			{
				resMsg.SetFail(-1, "账号或者密码不对！");
			}
			string res = JsonConvert.SerializeObject(resMsg);
			return Content(res);
		}
				
	}
}
