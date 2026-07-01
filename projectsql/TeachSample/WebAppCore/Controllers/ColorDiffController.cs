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
    public class ColorDiffController : Controller
    {
        private readonly IColorDiffService _service;		

		/// <summary>
		///
		/// </summary>	
		public ColorDiffController(IColorDiffService service)
        {
			_service = service;			
		}
				

		public ActionResult all()
		{			
			string res = _service.GetAllData();
			return Content(res);
		}

		public ActionResult list(int? pageNum, int? pageSize, string? name)
		{
			string res = _service.GetListData(pageNum, pageSize,name);
			return Content(res);
		}

		public ActionResult getImage(string name)
		{
			string res = _service.GetImage(name);
			return Content(res);
		}

		[HttpPost]
		public ActionResult update([FromBody] ColorDiffModel data)
		{			
			string json = _service.UpdateTableData(data);
			return Content(json);
		}

	}
}
