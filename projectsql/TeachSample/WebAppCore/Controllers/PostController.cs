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
    public class PostController : Controller
    {
        private readonly ISysPostsService _service;		

		/// <summary>
		///
		/// </summary>
		/// <param name="radarRawData"></param>       
		public PostController(ISysPostsService service)
        {
			_service = service;			
		}

		public ActionResult list(int? pageNum, int? pageSize)
		{			
			string res = _service.GetTableData(pageNum == null ? 1 : (int)pageNum, pageSize == null ? 10 : (int)pageSize);
			return Content(res);
		}

		
	}
}
