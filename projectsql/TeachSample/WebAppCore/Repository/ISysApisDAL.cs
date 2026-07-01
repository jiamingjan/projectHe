using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using Repository;

namespace IRepository
{
    public interface ISysApisDAL : IBaseRepository<SysApi, int>
    {
    }
}
