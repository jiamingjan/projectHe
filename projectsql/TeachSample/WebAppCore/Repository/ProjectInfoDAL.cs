using WebAppCore.DbModel;
using IRepository;

namespace Repository
{
    public class ProjectInfoDAL : BaseRepository<ProjectInfo, int>, IProjectInfoDAL
    {
        public ProjectInfoDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {
        }
    }
}