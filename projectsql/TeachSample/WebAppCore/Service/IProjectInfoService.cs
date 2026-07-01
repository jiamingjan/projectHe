using IService;
using WebAppCore.DbModel;
using WebAppCore.ViewModels;

namespace WebAppCore.Service
{
    public interface IProjectInfoService : IBaseService<ProjectInfo, int>
    {
        string GetTableData(int pageNum, int pageSize, ProjectInfoModel dataParams);
        string AddTableData(List<ProjectInfoModel> list);
        string UpdateTableData(List<ProjectInfoModel> list);
        string DeleteTableData(List<long> Ids);
    }
}