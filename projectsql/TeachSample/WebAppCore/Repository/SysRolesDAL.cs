using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class SysRolesDAL : BaseRepository<SysRole, int>, ISysRolesDAL
	{        
        public SysRolesDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }
    }
}