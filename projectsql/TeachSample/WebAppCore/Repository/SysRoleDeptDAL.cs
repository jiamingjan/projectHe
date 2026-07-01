using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class SysRoleDeptDAL : BaseRepository<SysRoleDept, int>, ISysRoleDeptDAL
	{        
        public SysRoleDeptDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }
    }
}