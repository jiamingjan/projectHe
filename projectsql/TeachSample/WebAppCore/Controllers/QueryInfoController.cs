using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCore.DbModel;
using Autofac;
using WebAppCore.Service.Samples;
using Microsoft.AspNetCore.Hosting.Server;
using WebAppCore.Service;
using System.IO;
using WebAppCore.ViewModels;

//https://www.cnblogs.com/PatrickLiu/p/17147826.html

namespace WebAppCore.Controllers
{
    public class QueryInfoController : Controller
    {       
        private readonly IServiceProvider _serviceProvider;
        private readonly IComponentContext _componentContext;
        private readonly IWebHostEnvironment _webHostEnvironment; //用于获取服务器程序的地址
        private readonly IQueryInfoService _queryInfoService;

        /// <summary>
        ///
        /// </summary>       
        /// <param name="serviceProvider">服务提供器，类型是 AutofacServiceProvider，获取类型。</param>
        /// <param name="componentContext">autofac 的上下文对象，可以获取容器中的服务。</param>
        public QueryInfoController(/*IPerson person, */IServiceProvider serviceProvider, 
            IComponentContext componentContext, IWebHostEnvironment webHostEnvironment, IQueryInfoService queryInfoService)
        {
           // _person = person;
            _serviceProvider = serviceProvider;
            _componentContext = componentContext;
            _webHostEnvironment = webHostEnvironment;
            _queryInfoService = queryInfoService;
        }

        public IActionResult Index()
        {         
            return View();
        }

        public IActionResult IndexVxe()
        {
            return View();
        }


        public IActionResult GetTableData(int page, int rows, string user, string queryStock, string startTime, string endTime)
        {
            string json = _queryInfoService.GetTableData(page, rows, user, queryStock,startTime, endTime);
            return Content(json);
        }

        public IActionResult GetVxeTableData(int? page, int? rows, QueryInfoModel data)
        {
            string json = _queryInfoService.GetVxeTableData(page == null ? 1 : (int)page, rows == null ? 20 : (int)rows, data);
            return Content(json);
        }

       
        public IActionResult DeleteTableData(string Ids)
        {
            string json = _queryInfoService.DeleteTableData(Ids);
            return Content(json);
        }

        //下面用于vxe表格,FromBody不可少
        [HttpPost]
        public ActionResult Delete([FromBody] List<QueryInfoModel> list)
        {
            string json = _queryInfoService.DeleteTableData(list);
            return Content(json);
        }

        [HttpPost]
        public ActionResult Update([FromBody] List<QueryInfoModel> list)
        {
            string json = _queryInfoService.UpdateTableData(list);
            return Content(json);
        }

        [HttpPost]
        public ActionResult Add([FromBody] List<QueryInfoModel> list)
        {
            string json = _queryInfoService.AddTableData(list);
            return Content(json);
        }
    }
}
