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
    public class ApiController : Controller
    {
        private readonly ISysApisService _service;		

		/// <summary>
		///
		/// </summary>	
		public ApiController(ISysApisService service)
        {
			_service = service;			
		}

		public ActionResult list(int? pageNum, int? pageSize)
		{
			string res = _service.GetTableData(pageNum == null ? 1 : (int)pageNum, pageSize == null ? 10 : (int)pageSize);
			return Content(res);
		}

		public ActionResult all()
		{			
			string res = _service.GetAllData();
			return Content(res);
		}

		[HttpGet]
		public ActionResult getPolicyPathByRoleId(string roleKey)
		{
			string res = _service.getPolicyPathByRoleId(roleKey);
			return Content(res);
		}

	}
}
