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
    public interface ISysRolesService : IBaseService<SysRole, int>
    {
		/// <summary>
		///
		/// </summary>

		string GetTableData(int pageNum, int pageSize, SysRolesModel data);
		List<SysRolesModel> GetRoles(SysRolesModel role);
		string GetById(long Id);
		string AddTableData(sys_rolesAddParam param);
		string UpdateTableData(sys_rolesUpdate param);
	}
}