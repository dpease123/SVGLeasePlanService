using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGLeasePlanService.Data.Models
{
    public class Polygon
    {
        [Key]
        public int Id { get; set; }
        public string PolygonId { get; set; }
        public string BldgId { get; set; }
        public string SuitId { get; set; }
        public int? FloorNO { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public string CtrAbbr { get; set; }
    }
}
