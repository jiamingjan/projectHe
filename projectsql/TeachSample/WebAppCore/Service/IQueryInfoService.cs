using Autofac.Extras.DynamicProxy;
using IService;
using System.Security.Claims;
using WebAppCore.AutofacExtensions;
using WebAppCore.DbModel;
using WebAppCore.ViewModels;

namespace WebAppCore.Service
{
    /// <summary>
    ///
    /// </summary>   
    public interface IQueryInfoService : IBaseService<queryinfo, int>
    {        

        string GetTableData(int page, int rows, string user, string queryStock, string startTime, string endTime);
        string GetVxeTableData(int pageIndex, int pageSize, QueryInfoModel data);
        string DeleteTableData(string Ids);

        //下面用于vxe表格
        string DeleteTableData(List<QueryInfoModel> data);
        string AddTableData(List<QueryInfoModel> data);

        string UpdateTableData(List<QueryInfoModel> data);
    }
}