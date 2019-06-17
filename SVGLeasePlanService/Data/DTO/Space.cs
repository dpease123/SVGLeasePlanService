using SVGLeasePlanService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGLeasePlanService.Data.DTO
{
    public class Space
    {
        public string SuitId { get; set; }
        public List<Polygon> Polygons { get; set; }
    }
}
