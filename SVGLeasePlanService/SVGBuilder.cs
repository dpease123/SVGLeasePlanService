using SVGLeasePlanService.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGLeasePlanService
{
    public class SVGBuilder
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly LDBRepository _repo = new LDBRepository();
        StringBuilder sb = new StringBuilder();
        public void Build()
        {
            //var files = Directory.GetFiles(@"c:\temp\plans\input", "*.png").ToList(); 
            //var x = Utilities.GetCenterFloorFromFileName(FileName);
            //var floor = int.Parse(x.Floor);
            //var start = FileManager.TodaysPNGtobeCovertedtoSVG();
            ////FIx this call to use the return from Utilities.GetCenterFloorFromFileName(FileName);
            //var spaces = _repo.GetPolygonsByCenterandFloor("CCK", 2);
            //sb.AppendLine(start.ToString());
            //foreach (var s in spaces)
            //{

            //    sb.AppendLine($@"<polygon id=""_x31_224 - {s.SuitId}"" title=""{s.SuitId} points="" ");
            //    foreach (var p in s.Polygons)
            //    {
            //        sb.AppendLine($"{p.X}, {p.Y}");
            //    }
            //    sb.Append("\"");
            //    sb.Append("/>");

            //}
            //sb.AppendLine("</svg>");

            ////Console.WriteLine(sb.ToString());
            //File.WriteAllText(@"C:\temp\plans\output\CCK2.svg", sb.ToString());
        }
    }
}
