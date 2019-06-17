using SVGLeasePlanService.Data.DTO;
using SVGLeasePlanService.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGLeasePlanService.Data
{
    public class LDBRepository
    {
        private readonly LDBContext _dbContext = new LDBContext();
       
        public async Task<IList<Space>> GetPolygonsByCenterandFloor(string CntrAbbr, int Floor)
        {
            return await _dbContext.Polygon.AsNoTracking()
                        .Where(p=> p.CtrAbbr == CntrAbbr && p.FloorNO == Floor)
                        .GroupBy(x => x.SuitId)
                        .Select(g => new Space { SuitId = g.Key, Polygons = g.ToList() })
                        .ToListAsync();
        }
    }
}
