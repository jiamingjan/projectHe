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

namespace WebAppCore.Controllers
{
    public class DeptController : Controller
    {
        private readonly ISysDeptsService _service;		

		/// <summary>
		///
		/// </summary>
		/// <param name="radarRawData"></param>       
		public DeptController(ISysDeptsService service)
        {
			_service = service;			
		}

		public ActionResult deptTree()
		{
			//string json = "{\"code\":200,\"msg\":\"success\",\"data\":[{\"deptId\":2,\"parentId\":0,\"deptPath\":\"/0/2\",\"deptName\":\"熊猫科技\",\"sort\":0,\"leader\":\"xm\",\"phone\":\"18353366836\",\"email\":\"342@qq.com\",\"status\":\"0\",\"createBy\":\"admin\",\"updateBy\":\"admin\",\"children\":[{\"deptId\":3,\"parentId\":2,\"deptPath\":\"/3\",\"deptName\":\"研发部\",\"sort\":1,\"leader\":\"panda\",\"phone\":\"18353366543\",\"email\":\"ewr@qq.com\",\"status\":\"0\",\"createBy\":\"\",\"updateBy\":\"\",\"children\":[],\"create_time\":\"2021-12-01T17:37:43Z\",\"update_time\":\"2021-12-02T08:55:56Z\"}],\"create_time\":\"2021-12-01T17:31:53Z\",\"update_time\":\"2021-12-02T08:56:19Z\"}]}";
			string json = _service.GetDeptTree();
			return Content(json);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult list()
		{
			////获取request中的token
			//string token = HttpContext.Request.Headers["AUTH-TOKEN"];
			//string res = TokenHelper.DecodeToken(token);

			string res = _service.GetTableData();
			return Content(res);
		}

		[HttpGet]
		public ActionResult roleDeptTreeSelect(long roleId)
		{
			string res = _service.GetRoleDeptTree(roleId);
			return Content(res);
		}
	}
}
