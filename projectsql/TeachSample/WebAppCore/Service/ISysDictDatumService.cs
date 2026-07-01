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
    public interface ISysDictDatumService : IBaseService<SysDictDatum, int>
    {
		/// <summary>
		///
		/// </summary>

		string GetDicts(string dictType);

	}
}