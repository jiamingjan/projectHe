using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class QueryInfoDAL : BaseRepository<queryinfo, int>, IQueryInfoDAL
    {        
        public QueryInfoDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }

    }
}