using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGLeasePlanService.Data.Models
{
    public class BldgScale
    {
        [Key]
        public string BldgId { get; set; }
        public double? IFactor { get; set; }
        public string stAbbrev { get; set; }
    }
}
