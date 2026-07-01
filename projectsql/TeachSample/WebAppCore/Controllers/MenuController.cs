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

namespace WebAppCore.Controllers
{
    public class MenuController : Controller
    {
        private readonly ISysMenusService _service;

		/// <summary>
		///
		/// </summary>
		/// <param name="ISysMenuService"></param>       
		public MenuController(ISysMenusService service)
        {
			_service = service;            
        }


		[HttpGet]
		public ActionResult list(SysMenu data)
		{
			string res = _service.GetTableData(data);
			return Content(res);
		}

		[HttpGet]
		public ActionResult menuTreeSelect()
		{
			string res = _service.MenuTreeSelect();
			return Content(res);
		}

		[HttpPost]
		public ActionResult add([FromBody] SysMenusModel data)
		{
			//获取request中的token
			string token = HttpContext.Request.Headers["AUTH-TOKEN"];
			string res = TokenHelper.DecodeToken(token);
			List<SysMenusModel> list = new List<SysMenusModel>();
			list.Add(data);
			string tistr = HttpContext.Session.GetString("TokenInfo");			
			if (!string.IsNullOrEmpty(tistr))
			{
				TokenInfo ti = JsonSerializer.Deserialize<TokenInfo>(tistr);
				data.createBy = ti.UserName;
				data.create_time = DateTime.Now;
			}

			res = _service.AddTableData(list);
			return Content(res);
		}

		[HttpPut]
		public ActionResult update([FromBody] SysMenusModel data)
		{
			if (data == null)
				return Content("error");
			List<SysMenusModel> list = new List<SysMenusModel>();
			list.Add(data);
			string tistr = HttpContext.Session.GetString("TokenInfo");		 	
			if (!string.IsNullOrEmpty(tistr))
			{
				TokenInfo ti = JsonSerializer.Deserialize<TokenInfo>(tistr); 
				data.update_by = ti.UserName;
				data.update_time = DateTime.Now;
			}
			string json = _service.UpdateTableData(list);
			return Content(json);
		}

		[HttpPost]
		public ActionResult delete([FromBody] List<long> menuId)
		{
			string json = _service.DeleteTableData(menuId);
			return Content(json);
		}


		[HttpGet]
		public ActionResult roleMenuTreeSelect(int roleId)
		{
			////获取request中的token
			//string token = HttpContext.Request.Headers["AUTH-TOKEN"];
			//string res = TokenHelper.DecodeToken(token);

			string res = _service.RoleMenuTreeSelect(roleId);
			return Content(res);
		}


	}
}
