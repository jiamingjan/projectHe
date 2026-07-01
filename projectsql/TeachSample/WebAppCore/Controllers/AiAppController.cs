using Microsoft.AspNetCore.Mvc;
using WebAppCore.ViewModels.DeepSeek;
using WebAppCore.Service;
using Tesseract;
using WebAppCore.ViewModels;
using Newtonsoft.Json;

namespace WebAppCore.Controllers
{
	//路由
	//[Route("AiApp")]
	public class AiAppController : Controller
    {
        private readonly IAiAppService _service; //Service层
		private readonly IWebHostEnvironment _webHostEnvironment; //用于获取服务器程序的地址

		/// <summary>
		///	构造器
		/// </summary>	
		public AiAppController(IAiAppService service, IWebHostEnvironment webHostEnvironment)
        {
			_service = service;
			_webHostEnvironment = webHostEnvironment;
		}

		/// <summary>
		/// 前端页面Main
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Main()
		{
			return View();
		}

		/// <summary>
		/// 前端页面DeepSeek
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult DeepSeek()
		{
			return View();
		}

		/// <summary>
		/// 前端页面DsBaiduMap
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult DsBaiduMap()
		{
			return View();
		}

		/// <summary>
		/// 前端页面DsCesium
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult DsCesium()
		{
			return View();
		}


		/// <summary>
		/// DeepSeek请求，可以用AiChatReq来代替
		/// </summary>
		/// <param name="model"></param>
		/// <param name="question"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<ActionResult> DeepSeekReq(int model, string question)
		{
			string res = await _service.CallAiApi(AiCompany.COM_DEEPSEEK, model,question);
			return Content(res);
		}

		/// <summary>
		/// AiChatReq 聊天请求
		/// </summary>
		/// <param name="company">AI提供公司，类型为AiCompany定义</param>
		/// <param name="model">具体的模型</param>
		/// <param name="question">要问的问题，目前这个接口只支持一个问题，本质上可以多个问题</param>
		/// <returns></returns>
		[HttpGet]
		public async Task<ActionResult> AiChatReq(int company,int model, string question)
		{
			string res = await _service.CallAiApi((AiCompany)company, model, question);
			return Content(res);
		}

		/// <summary>
		/// UploadFile是图像上传并理解的接口
		/// </summary>
		/// <param name="question">要问的问题</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> UploadFile(string question)
		{
			VueResMsg<string> res = new VueResMsg<string>();
			if (string.IsNullOrEmpty(question))
			{
				res.code = -1;
				res.msg = "智能助手的输入问题为空，请输入问题！";
				res.data = res.msg;
				return Content(JsonConvert.SerializeObject(res));
			}
			var path = _webHostEnvironment.ContentRootPath;
			path = Path.Combine(path, "UploadFilePath");
			IFormFileCollection files = Request.Form.Files;
			foreach (IFormFile file in files) 
			{
				//string exten = Path.GetExtension(file.FileName).ToLower();
				string fileName =file.FileName;
				string filePath = Path.Combine(path, fileName);
				//下面保存到服务器
				try
				{
					if (Directory.Exists(path) == false)//如果不存在就创建file文件夹
						Directory.CreateDirectory(path);

					using (FileStream fileStream = System.IO.File.Create(filePath))
					{
						//保存到文件路径：filePath
						file.CopyTo(fileStream);
						fileStream.Flush();						
					}

					string str = await _service.CallAiApi(AiCompany.COM_AlICLOUD, 0, question, filePath);

					//// 初始化OCR引擎 chi_sim eng
					//var ocr = new Tesseract.TesseractEngine(@"./tessdata", "chi_sim", EngineMode.Default);
					//// 加载OCR模型（指定模型路径）
					//var img = Pix.LoadFromFile(filePath);
					//var result = ocr.Process(img);
					//string text = result.GetText();


					return Content(str);
				}
				catch (Exception ex)
				{					
					res.code = -1;
					res.msg = ex.Message;
					res.data = res.msg;
					return Content(JsonConvert.SerializeObject(res));
				}
			}
			res.code = -1;
			return Content(JsonConvert.SerializeObject(res));
		}

	}
}
