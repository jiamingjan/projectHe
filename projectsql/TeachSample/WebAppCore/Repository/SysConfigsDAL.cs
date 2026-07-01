using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class SysConfigsDAL : BaseRepository<SysConfig, int>, ISysConfigsDAL
	{        
        public SysConfigsDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }
    }
}