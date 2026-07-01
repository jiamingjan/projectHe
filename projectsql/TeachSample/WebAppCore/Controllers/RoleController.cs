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
    public class RoleController : Controller
    {
        private readonly ISysRolesService _service;

		/// <summary>
		///
		/// </summary>
		/// <param name="ISysRolesService"></param>       
		public RoleController(ISysRolesService sysRolesService)
        {
			_service = sysRolesService;            
        }
				

		public ActionResult list(int? pageNum, int? pageSize, SysRolesModel data)
		{			
			string res = _service.GetTableData(pageNum == null ? 1 : (int)pageNum, pageSize == null ? 10 : (int)pageSize, data);
			return Content(res);
		}

		public ActionResult getById(long roleId)
		{
			string res = _service.GetById(roleId);
			return Content(res);
		}

		//下面未完成
		[HttpPost]
		public ActionResult add([FromBody] sys_rolesAddParam param)
		{
			string tistr = HttpContext.Session.GetString("TokenInfo");			
			if (!string.IsNullOrEmpty(tistr))
			{
				TokenInfo ti = JsonSerializer.Deserialize<TokenInfo>(tistr);
				param.createBy = ti.UserName;
			} 
			
			string res = _service.AddTableData(param);
			return Content(res);
		}

		public ActionResult getPolicyPathByRoleId(string roleKey)
		{
			string res = _service.GetById(1);
			return Content(res);
		}

		[HttpPut]
		public ActionResult update([FromBody] sys_rolesUpdate param)
		{
			//string token = HttpContext.Request.Headers["Authorization"];
			//string res = TokenHelper.DecodeToken(token);

			string tistr = HttpContext.Session.GetString("TokenInfo");
			if (!string.IsNullOrEmpty(tistr))
			{
				TokenInfo ti = JsonSerializer.Deserialize<TokenInfo>(tistr);
				param.updateBy = ti.UserName;
			}
			string res = _service.UpdateTableData(param);
			return Content(res);
		}
	}
}
