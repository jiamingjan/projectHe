using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class CasbinRuleDAL : BaseRepository<CasbinRule, int>, ICasbinRuleDAL
	{        
        public CasbinRuleDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }
    }
}