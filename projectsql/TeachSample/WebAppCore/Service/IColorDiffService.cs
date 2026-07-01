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
    public interface IColorDiffService : IBaseService<ColorDiff, int>
    {
		string GetAllData();
		string GetListData(int? pageNum, int? pageSize,string? name);
		string UpdateTableData(ColorDiffModel data);
        string GetImage(string name);
	}
}