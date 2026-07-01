using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;

namespace IRepository
{
    public interface ISysUsersDAL : IBaseRepository<SysUser, int>
    {
    }
}
