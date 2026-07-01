using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;

namespace Repository
{
    public class RadarRawDataDAL : RadarBaseRepository<RadarRawDatum, int>, IRadarRawDataDAL
    {        
        public RadarRawDataDAL(LbRadarMngContext Dbcontext) : base(Dbcontext)
        {           
        }

    }
}