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
            var row = _dbContext.BldgScale.Where(x => x.stAbbrev == Id).FirstOrDefault();
            return row;
        }
    }
}
