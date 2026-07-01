using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class SysDictDatumDAL : BaseRepository<SysDictDatum, int>, ISysDictDatumDAL
	{        
        public SysDictDatumDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }
    }
}