using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class SysApisDAL : BaseRepository<SysApi, int>, ISysApisDAL
	{        
        public SysApisDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }
    }
}