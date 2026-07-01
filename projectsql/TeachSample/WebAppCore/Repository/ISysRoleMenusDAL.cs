using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
	public interface ISysRoleMenusDAL : IBaseRepository<SysRoleMenu, int>
	{
	}
}