using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class SysRoleMenusDAL : BaseRepository<SysRoleMenu, int>, ISysRoleMenusDAL
	{        
        public SysRoleMenusDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }
    }
}