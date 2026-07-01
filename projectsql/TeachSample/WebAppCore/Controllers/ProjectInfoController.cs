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
    public class ProjectInfoController : Controller
    {
        private readonly IProjectInfoService _service;

        public ProjectInfoController(IProjectInfoService service)
        {
            _service = service;
        }

        [Authorize]
        public ActionResult testauth()
        {
            string res = "ok";
            return Content(res);
        }

        public ActionResult list(int? pageNum, int? pageSize, ProjectInfoModel data)
        {
            string res = _service.GetTableData(pageNum == null ? 1 : (int)pageNum, pageSize == null ? 10 : (int)pageSize, data);
            return Content(res);
        }

        [HttpPost(Name = "add")]
        public ActionResult add([FromBody] ProjectInfoModel data)
        {
            data.CreateBy = _service.GetTokenUserName(HttpContext.Request.Headers["Authorization"]);
            data.CreateTime = DateTime.Now;

            List<ProjectInfoModel> list = new List<ProjectInfoModel>();
            list.Add(data);
            string res = _service.AddTableData(list);
            return Content(res);
        }

        [HttpPost]
        public ActionResult update([FromBody] ProjectInfoModel data)
        {
            if (data == null)
                return Content("error");

            data.UpdateBy = _service.GetTokenUserName(HttpContext.Request.Headers["Authorization"]);
            data.UpdateTime = DateTime.Now;

            List<ProjectInfoModel> list = new List<ProjectInfoModel>();
            list.Add(data);
            string json = _service.UpdateTableData(list);
            return Content(json);
        }

        [HttpPost]
        public ActionResult delete([FromBody] List<long> ids)
        {
            string json = _service.DeleteTableData(ids);
            return Content(json);
        }
    }
}