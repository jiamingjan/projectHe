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
    public interface ISysMenusService : IBaseService<SysMenu, int>
    {
		string GetTableData(SysMenu data);
		string MenuTreeSelect();
		string AddTableData(List<SysMenusModel> list);
		string UpdateTableData(List<SysMenusModel> list);
		string DeleteTableData(List<long> Ids);
		string RoleMenuTreeSelect(int roleId);
	}
}