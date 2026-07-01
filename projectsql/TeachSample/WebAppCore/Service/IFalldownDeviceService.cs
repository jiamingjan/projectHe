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
    public interface IFalldownDeviceService : IBaseService<FalldownDevice, int>
    {
		string GetTableData(int pageNum, int pageSize, FalldownDeviceModel dataParams);		
		string AddTableData(List<FalldownDeviceModel> list);
		string UpdateTableData(List<FalldownDeviceModel> list);
		string DeleteTableData(List<long> Ids);
	}
}