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
    public interface ISysDictTypeService : IBaseService<SysDictType, int>
    {
		/// <summary>
		///
		/// </summary>

		string GetTableData(int pageNum, int pageSize);

	}
}