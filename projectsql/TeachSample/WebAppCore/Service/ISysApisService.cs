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
    public interface ISysApisService : IBaseService<SysApi, int>
    {
		string GetTableData(int pageNum, int pageSize);
		string GetAllData();
		string getPolicyPathByRoleId(string roleKey);
	}
}