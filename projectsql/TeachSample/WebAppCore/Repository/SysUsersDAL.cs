using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class SysUsersDAL : BaseRepository<SysUser, int>, ISysUsersDAL
    {        
        public SysUsersDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }
    }
}