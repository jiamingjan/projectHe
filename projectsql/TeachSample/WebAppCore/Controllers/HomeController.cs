using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCore.DbModel;
using Autofac;
using WebAppCore.Service.Samples;
using System.Text.Json.Nodes;
using System.Text.Json;

//https://www.cnblogs.com/PatrickLiu/p/17147826.html

namespace WebAppCore.Controllers
{
    public class HomeController : Controller
    {
       // private readonly IPerson _person;
        private readonly IServiceProvider _serviceProvider;
        private readonly IComponentContext _componentContext;
		private readonly VueworkdbTeachContext _db;

		/// <summary>
		///
		/// </summary>
		/// <param name="person"></param>
		/// <param name="serviceProvider">服务提供器，类型是 AutofacServiceProvider，获取类型。</param>
		/// <param name="componentContext">autofac 的上下文对象，可以获取容器中的服务。</param>
		public HomeController(/*IPerson person, */IServiceProvider serviceProvider, IComponentContext componentContext, VueworkdbTeachContext db)
        {
           // _person = person;
            _serviceProvider = serviceProvider;
            _componentContext = componentContext;
			_db = db;
		}

        public IActionResult Index()
        {
            //_person.Eat("炸酱面");

            //var single = _serviceProvider.GetService<SinglePerson>();
            //single!.Eat("残羹冷炙");

            //var singleTwo = _componentContext.Resolve<SinglePerson>();
            //singleTwo.Eat("残羹剩饭");

            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }


		public IActionResult IndexVue()
        {
            return View();
        }

		public IActionResult DashBoard()
		{
			return View();
		}

		public IActionResult Privacy()
        {      
            return View();
        }

		public IActionResult GetMovement()
		{
            var data = new int[] { 2115, 3562, 4584, 1892, 1587, 1923, 2566, 2448, 2805, 3438, 2917, 3327 };
			return Content(JsonSerializer.Serialize(data));
		}

		class where
		{
            public string text { get; set; }
			public string href { get; set; }
            public where(string s, string h) { text = s; href = h; }
		}
		public IActionResult GetElseWhere()
		{
            var data = new List<where>();
            data.Add(new where("Instagram", "#"));
			data.Add(new where("LinkedIn", "#"));
			data.Add(new where("Facebook", "#"));
			data.Add(new where("Baidu", "www.baidu.com"));
			return Content(JsonSerializer.Serialize(data));
		}

		// GET: Home/Test/5
		public ActionResult Test(int id)
        {
            return Content("param:" + id);
        }

        // GET: Home/Test/5
        public ActionResult TestDb(int id)
        {
            string temp = "";
			var data2 = _db.SysDepts.FromSqlRaw("SELECT * FROM vueworkdb_teach.sys_depts");
			foreach (var item in data2)
			{
				temp += item.DeptName;
			}
			return Content("param:" + temp);
		}
    }
}
