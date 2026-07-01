using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class SysDeptsDAL : BaseRepository<SysDept, int>, ISysDeptsDAL
	{        
        public SysDeptsDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }
    }
}