using Autofac.Extras.DynamicProxy;
using IService;
using MyTool;
using System.Security.Claims;
using WebAppCore.AutofacExtensions;
using WebAppCore.DbModel;
using WebAppCore.ViewModels;

namespace WebAppCore.Service
{
    /// <summary>
    ///
    /// </summary>   
    public interface IFalldownLocationService : IBaseService<FalldownLocation, int>
    {
		string Query(string deviceCode, DateTime? startTime, DateTime? endTime);
	}
}