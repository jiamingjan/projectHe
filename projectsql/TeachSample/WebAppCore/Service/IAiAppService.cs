using Autofac.Extras.DynamicProxy;
using IService;
using MyTool;
using System.Security.Claims;
using WebAppCore.AutofacExtensions;
using WebAppCore.DbModel;
using WebAppCore.ViewModels;
using WebAppCore.ViewModels.DeepSeek;

namespace WebAppCore.Service
{
    /// <summary>
    ///
    /// </summary>   
    public interface IAiAppService
    {
		/// <summary>
		/// 通用的AI接口调用，如果imagePath不为null或者空，那么表示图像理解，否则是回答问题
		/// </summary>
		/// <param name="type"></param>
		/// <param name="question"></param>
		/// <returns></returns>
		Task<string> CallAiApi(AiCompany company,int model, string question, string imagePath = null);
	}
}