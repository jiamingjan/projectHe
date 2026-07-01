using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class FalldownLocationDAL : BaseRepository<FalldownLocation, int>, IFalldownLocationDAL
	{        
        public FalldownLocationDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }
    }
}