using SVGLeasePlanService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGLeasePlanService.Data
{
    public class LDBRepository
    {
        private readonly LDBContext _dbContext = new LDBContext();
        public BldgScale GetBuilding(string Id)
        {
            return _dbContext.BldgScale.Where(x => x.stAbbrev == Id).FirstOrDefault();
           
        }

        public List<Space> GetPolygonsByCenterandFloor(string CntrAbbr, int Floor)
        {
            var spaces =  from p in _dbContext.Polygon
                            where p.CtrAbbr == CntrAbbr && p.FloorNO == Floor
                            group p by p.SuitId into g
                   select new Space
                   {
                       SuitId = g.Key,
                       Polygons = g.ToList()
                   };
            return spaces.ToList(); 
        }

        //   return from p in _dbContext.Polygon.Where(x => x.CtrAbbr == CntrAbbr && x.FloorNO == Floor).GroupBy(o => o.SuitId).ToList();

        
    }
}
