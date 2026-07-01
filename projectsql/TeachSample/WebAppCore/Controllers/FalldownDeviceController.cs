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
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

namespace WebAppCore.Controllers
{
    public class FalldownDeviceController : Controller
    {
        private readonly IFalldownDeviceService _service;		

		/// <summary>
		///
		/// </summary>		 
		public FalldownDeviceController(IFalldownDeviceService service)
        {
			_service = service;			
		}

		[Authorize]
		public ActionResult testauth()
		{
			string res = "ok";
			return Content(res);
		}

		//[Authorize]
		public ActionResult list(int? pageNum, int? pageSize, FalldownDeviceModel data)
		{
			//string token = HttpContext.Request.Headers["Authorization"];
			//TokenParse user = _service.GetTokenUser(token);
			string res = _service.GetTableData(pageNum == null ? 1 : (int)pageNum, pageSize == null ? 10 : (int)pageSize, data);
			return Content(res);
		}

		[HttpPost(Name = "add")]
		public ActionResult add([FromBody] FalldownDeviceModel data)
		{
			//获取request中的token
			//string token = HttpContext.Request.Headers["AUTH-TOKEN"];
			//string res = TokenHelper.DecodeToken(token);
			//string tistr = HttpContext.Session.GetString("TokenInfo");			
			//if (!string.IsNullOrEmpty(tistr))
			//{				
			//	TokenInfo ti = JsonSerializer.Deserialize<TokenInfo>(tistr);
			//	data.CreateBy = ti.UserName;
			//	data.CreateTime = DateTime.Now;
			//}

			data.CreateBy = _service.GetTokenUserName(HttpContext.Request.Headers["Authorization"]);
			data.CreateTime = DateTime.Now;

			List<FalldownDeviceModel> list = new List<FalldownDeviceModel>();
			list.Add(data);
			string res = _service.AddTableData(list);
			return Content(res);
		}

		[HttpPost]
		public ActionResult update([FromBody] FalldownDeviceModel data)
		{
			if (data == null)
				return Content("error");
			//string tistr = HttpContext.Session.GetString("TokenInfo");
			//string userName = "";
			//if (!string.IsNullOrEmpty(tistr))
			//{
			//	TokenInfo ti = JsonSerializer.Deserialize<TokenInfo>(tistr);
			//	data.UpdateBy = ti.UserName;
			//	data.UpdateTime = DateTime.Now;
			//}


			data.UpdateBy = _service.GetTokenUserName(HttpContext.Request.Headers["Authorization"]);
			data.UpdateTime = DateTime.Now;

			List<FalldownDeviceModel> list = new List<FalldownDeviceModel>();
			list.Add(data);
			string json = _service.UpdateTableData(list);
			return Content(json);
		}

		/// <summary>
		/// 支持一次性删除多个
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult delete([FromBody] List<long> ids)
		{
			string json = _service.DeleteTableData(ids);
			return Content(json);
		}		
	}
}
