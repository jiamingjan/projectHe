using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCore.DbModel;
using WebAppCore.AutofacExtensions;
using WebAppCore.Service.Samples;

namespace WebAppCore.Controllers
{
    /// <summary>
    ///
    /// </summary>
    public class PropertyInjectionController : Controller
    {
        private readonly IPropertyPerson _propertyPerson;

        /// <summary>
        ///
        /// </summary>
        /// <param name="propertyPerson"></param>
        public PropertyInjectionController(IPropertyPerson propertyPerson)
        {
            _propertyPerson = propertyPerson;
        }

        /// <summary>
        /// 这里就是控制器的属性，需要自动初始化。
        /// </summary>
        //[CustomPropertySelector]
       // public SinglePerson? SinglePerson { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            _propertyPerson.Process();

            return View();
        }
    }
}