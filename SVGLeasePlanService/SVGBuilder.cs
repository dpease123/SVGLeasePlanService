using SVGLeasePlanService.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace SVGLeasePlanService
{
    public class SVGBuilder
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly LDBRepository _repo = new LDBRepository();
        StringBuilder sb = new StringBuilder();
        public async Task Build()
        {
            var PNGInputFolder = ConfigurationManager.AppSettings["PNGInputFolder"];
            var SVGOutputFolder = ConfigurationManager.AppSettings["SVGOutputFolder"];
            var pngFiles = Directory.GetFiles(@PNGInputFolder, "*.png");
            foreach (var png in pngFiles)
            {
                GetCntrAbbrandFloorFromPNGName(png, out string PNGName, out dynamic x);


                var FloorSpaces = await _repo.GetPolygonsByCenterandFloor(x.CtrAbbr, x.Floor);

                if (FloorSpaces.Count == 0)
                {
                    log.Info("Skipping SVG floor plan for: " + x.CtrAbbr + "-" + "FloorNo: " + x.Floor + " | PNG File: " + png);
                    continue;
                }

                log.Info("Building SVG floor plan for: " + x.CtrAbbr + "-" + "FloorNo: " + x.Floor + " | PNG File: " + png);
                var stream = await File.OpenText(png).ReadToEndAsync();
                sb.AppendLine($@"<svg version = ""1.1"" id=""Map"" class=""gen-by-synoptic-designer"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" viewBox=""0 0 4200 3000"" xml:space=""preserve""><image width = ""4200"" height=""3000"" xlink:href=""data:image/png;base64,{stream}"" />");

                foreach (var s in FloorSpaces)
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
                File.WriteAllText(@SVGOutputFolder + PNGName + ".svg", sb.ToString());

            }

        }

        private static void GetCntrAbbrandFloorFromPNGName(string png, out string PNGName, out dynamic x)
        {
            var f = new FileInfo(png);
            PNGName = f.Name.Replace(".png", "");
            x = Utilities.GetCenterFloorFromFileName(PNGName);
        }
    }
}
