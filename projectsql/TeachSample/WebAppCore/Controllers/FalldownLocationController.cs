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
using Autofac.Core;

namespace WebAppCore.Controllers
{
    public class FalldownLocationController : Controller
    {
        private readonly IFalldownLocationService _service;		

		/// <summary>
		///
		/// </summary>		 
		public FalldownLocationController(IFalldownLocationService service)
        {
			_service = service;			
		}

		public ActionResult query(string deviceCode, DateTime? startTime, DateTime? endTime)
		{
			//获取request中的token
			//string token = HttpContext.Request.Headers["AUTH-TOKEN"];
			//string res = TokenHelper.DecodeToken(token);            
			string res = _service.Query(deviceCode, startTime, endTime);
			return Content(res);
		}
	}
}
