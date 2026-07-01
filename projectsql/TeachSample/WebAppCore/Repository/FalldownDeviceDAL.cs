using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class FalldownDeviceDAL : BaseRepository<FalldownDevice, int>, IFalldownDeviceDAL
	{        
        public FalldownDeviceDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }
    }
}