using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class SysDictTypeDAL : BaseRepository<SysDictType, int>, ISysDictTypeDAL
	{        
        public SysDictTypeDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }
    }
}