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
using Autofac.Core;

namespace WebAppCore.Controllers
{
	[Route("system/dict")]
	public class DictController : Controller
    {
        private readonly ISysDictDatumService _service;
		private readonly ISysDictTypeService sysDictTypeService;

		/// <summary>
		///
		/// </summary>
		/// <param name="radarRawData"></param>       
		public DictController(ISysDictDatumService dictDatumService, ISysDictTypeService dictTypeService)
        {
			_service = dictDatumService;
			sysDictTypeService = dictTypeService;

		}

		//Api(false)] // 设置为false以显示此方法
		[Route("type/list")]
		[HttpGet]
		public ActionResult list(int? pageNum, int? pageSize)
		{			
			string res = sysDictTypeService.GetTableData(pageNum == null ? 1 : (int)pageNum, pageSize == null ? 10 : (int)pageSize);
			return Content(res);
		}

		
		[Route("data/type")]
		[HttpGet]
		public ActionResult type(string dictType)
		{
			string json = _service.GetDicts(dictType);
			return Content(json);
		}
	}
}
