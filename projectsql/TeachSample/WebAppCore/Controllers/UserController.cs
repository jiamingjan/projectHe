using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCore.DbModel;
using Autofac;
using WebAppCore.ViewModels;
using WebAppCore.Service;
using MyTool;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace WebAppCore.Controllers
{
    public class UserController : Controller
    {
        private readonly ISysUsersService _service;
		private readonly AuthService _authService;
		/// <summary>
		///
		/// </summary>
		/// <param name="sys_users"></param>       
		public UserController(ISysUsersService sys_users, AuthService authService)
        {
			_service = sys_users;
            _authService = authService;

		}

		public ActionResult getCaptcha()
		{
			//string json = "{\"base64Captcha\":\"data: image / png; base64,iVBORw0KGgoAAAANSUhEUgAAAPAAAABQCAMAAAAQlwhOAAAA81BMVEUAAABRNRNJLQuWeliGakhILApDJwVVORfny6l1WTeKbkyxlXNKLgyZfVuliWe6nnzHq4nkyKZYPBqaflzdwZ / Lr42CZkRKLgxyVjTRtZOegmC8oH5PMxHGqoh7Xz2UeFZNMQ + vk3FWOhiLb014XDpEKAY + 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\",\"captchaId\":\"1zO86oZzuKkE6ovqdrok\"}";
			string strCode = string.Empty;
			string json = _service.GetCaptcha(ref strCode);
			//save to session 用于后续验证	,特别注意HttpContext.Session只能在Controller里用		
			HttpContext.Session.SetString("CheckCode", strCode);
			return Content(json);
		}

		[HttpPost]		
		public ActionResult login([FromBody] LoginReq req)
		{
			//这里暂时用Session保存验证码
			string sessionCode = HttpContext.Session.GetString("CheckCode");
            //TokenInfo ti = new TokenInfo("",""); //ti是传出参数，保存tokeninfo，因为.net core session只能在控制器里用
			LoginRes res = _service.Login(req, sessionCode);
			//save user info for validate token late request
			string json = "";
			if (res != null && res.code == 200)
			{
				//HttpContext.Session.SetString("TokenInfo", JsonSerializer.Serialize(ti));
				AuthUser user = new AuthUser();
				user.Username = req.username;
				//user.Name = req.username;
				user.Password = req.password;
				user.Roles = new string[0];
				//user.Email = "";
				//user.Id = 0;
				string token = _authService.GenerateToken(user);
				if (res.data == null)
					res.data = new LoginResData();
				res.data.token = token;				
			}

			json = JsonSerializer.Serialize(res);
			return Content(json);
		}

		/// <summary>
		/// 这个接口目前不再使用
		/// </summary>
		/// <param name="req"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult login_Old([FromBody] LoginReq req)
		{
			string sessionCode = HttpContext.Session.GetString("CheckCode");
			TokenInfo ti = new TokenInfo("", ""); //ti是传出参数，保存tokeninfo，因为.net core session只能在控制器里用
			string json = _service.Login(req, sessionCode, ref ti);
			//save user info for validate token late request
			if (json != null)
				HttpContext.Session.SetString("TokenInfo", JsonSerializer.Serialize(ti));

			return Content(json);
		}

		//下面的请求最后是定义结构
		public ActionResult list(int? pageNum, int? pageSize, string username, string phone, string status, int? deptId)
		{			
			SysUsersModel req = new SysUsersModel();
            req.username = username;
            req.phone = phone;
            req.status = status;
            req.deptId = deptId;
			string res = _service.GetTableData(pageNum, pageSize, req);
			return Content(res);
		}

		//public async Task<IActionResult> IndexVxe()
		//      {
		//          var users = sys_usersService.GetTableData();

		//          return View(users);
		//      }

		//拦截器
		[Authorize]
		public IActionResult GetVxeTableData(int? page, int? rows, SysUsersModel data)
        {
            string json = _service.GetVxeTableData(page == null ? 1 : (int)page, rows == null ? 20 : (int)rows, data);
            return Content(json);
        }

        [HttpPost]
        public ActionResult Delete([FromBody] List<SysUsersModel> list)
        {
            string json = _service.DeleteTableData(list);
            return Content(json);
        }

        [HttpPost]
        public ActionResult Update([FromBody] List<SysUsersModel> list)
        {
            string json = _service.UpdateTableData(list);
            return Content(json);
        }

        [HttpPost]
        public ActionResult Add([FromBody] List<SysUsersModel> list)
        {
			string json = _service.AddTableData(list);
            return Content(json);
        }

		//    public ActionResult getCaptcha()
		//    {
		//        //string json = "{\"base64Captcha\":\"data: image / png; base64,iVBORw0KGgoAAAANSUhEUgAAAPAAAABQCAMAAAAQlwhOAAAA81BMVEUAAABRNRNJLQuWeliGakhILApDJwVVORfny6l1WTeKbkyxlXNKLgyZfVuliWe6nnzHq4nkyKZYPBqaflzdwZ / Lr42CZkRKLgxyVjTRtZOegmC8oH5PMxHGqoh7Xz2UeFZNMQ + vk3FWOhiLb014XDpEKAY + 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\",\"captchaId\":\"1zO86oZzuKkE6ovqdrok\"}";
		//        string json = sys_usersService.GetCaptcha();
		//        return Content(json);
		//    }

		/// <summary>
		/// Bootstrap前端页面
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult IndexVxe()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult IndexVxe_Old()
		{
			return View();
		}

		//[Authorize]
		public ActionResult GetTableData(int page, int rows, string userName)
		{
			string json = _service.GetTableDataBootStrap(page, rows, userName);
			return Content(json);
		}

		[Authorize]
		public ActionResult testauth()
		{
			string json = "Ok";
			return Content(json);
		}

		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}

		[HttpPost]
		public ActionResult UserRegister([FromBody] SysUsersModel user)
		{			
			string json = _service.SignUp(user);
			return Content(json);
		}
	}
}
