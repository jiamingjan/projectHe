using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using Repository;

namespace IRepository
{
    public interface ISysMenusDAL : IBaseRepository<SysMenu, int>
    {
		List<SysMenu> GetSysMenusByRoleIds(string roleIds);

	}
}
