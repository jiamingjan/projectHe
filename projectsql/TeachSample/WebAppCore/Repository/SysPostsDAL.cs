using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class SysPostsDAL : BaseRepository<SysPost, int>, ISysPostsDAL
	{        
        public SysPostsDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }
    }
}