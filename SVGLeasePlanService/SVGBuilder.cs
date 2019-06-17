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
            var pngFiles = Directory.GetFiles(@"c:\temp\plans\input", "*.png");
            foreach (var png in pngFiles)
            {
               
                var f = new FileInfo(png);
                var stream = File.OpenText(png).ReadToEnd();
                sb.AppendLine($@"<svg version = ""1.1"" id=""Map"" class=""gen-by-synoptic-designer"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" viewBox=""0 0 4200 3000"" xml:space=""preserve""><image width = ""4200"" height=""3000"" xlink:href=""data:image/png;base64,{stream}"" />");

                var x = Utilities.GetCenterFloorFromFileName(f.Name.Replace(".png", ""));
                log.Info("Building SVG floor plan for: " + x.CtrAbbr + "-" + "FloorNo: " + x.Floor + " | PNG File: " + png);

               var spaces = _repo.GetPolygonsByCenterandFloor(x.CtrAbbr, x.Floor);
                
                foreach (var s in spaces)
                {

                    sb.AppendLine($@"<polygon id=""_x31_224 - {s.SuitId}"" title=""{s.SuitId} points="" ");
                    foreach (var p in s.Polygons)
                    {
                        sb.AppendLine($"{p.X}, {p.Y}");
                    }
                    sb.Append("\"");
                    sb.Append("/>");

                }
                sb.AppendLine("</svg>");
                File.WriteAllText(@"C:\temp\plans\output\CCK2.svg", sb.ToString());

            }
           
        }
    }
}
