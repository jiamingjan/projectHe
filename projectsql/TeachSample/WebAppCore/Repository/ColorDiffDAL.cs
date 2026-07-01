using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class ColorDiffDAL : BaseRepository<ColorDiff, int>, IColorDiffDAL
	{        
        public ColorDiffDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }
    }
}