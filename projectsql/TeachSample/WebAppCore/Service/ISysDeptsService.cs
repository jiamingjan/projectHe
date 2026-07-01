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
    public interface ISysDeptsService : IBaseService<SysDept, int>
    {
		/// <summary>
		///
		/// </summary>
		string GetDeptTree();
		string GetTableData();
		string GetRoleDeptTree(long Id);
	}
}