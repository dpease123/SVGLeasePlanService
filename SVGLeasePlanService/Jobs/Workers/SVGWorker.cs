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
    public class SVGWorker
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly LDBRepository _repo = new LDBRepository();
        readonly StringBuilder sb = new StringBuilder();
        public async Task Work()
        {
            var PNGInputFolder = ConfigurationManager.AppSettings["PNGInputFolder"];
            var SVGOutputFolder = ConfigurationManager.AppSettings["SVGOutputFolder"];

            string[] pngFiles = GetPNGPlansToProcess(PNGInputFolder);

            foreach (var png in pngFiles)
            {
                GetCntrAbbrandFloorFromPNGName(png, out string PNGName, out dynamic x);

                var FloorTenantPolygons = await _repo.GetPolygonsByCenterandFloor(x.CtrAbbr, x.Floor);

                if (FloorTenantPolygons.Count == 0)
                {
                    log.Info("***Skipping No polygon data found: " + x.CtrAbbr + "-" + "FloorNo: " + x.Floor + " | PNG File: " + png);
                    continue;
                }

                log.Info("Building SVG floor plan for: " + x.CtrAbbr + "-" + "FloorNo: " + x.Floor + " | PNG File: " + png);

                AddSVGFileHeader(ConvertPNGtoBase64String(png));

                var BldgId = GetBuildngId(FloorTenantPolygons);

                AddFloorTenannatPolygonsToSVGFile(x, FloorTenantPolygons, BldgId);

                WriteSVGFileToDisk(SVGOutputFolder, PNGName);

                sb.Clear();

            }

        }

        private void WriteSVGFileToDisk(string SVGOutputFolder, string PNGName)
        {
            File.WriteAllText(@SVGOutputFolder + PNGName + ".svg", sb.ToString());
        }

        private void AddFloorTenannatPolygonsToSVGFile(dynamic x, dynamic Floorpolygons, string BldgId)
        {
            foreach (var s in Floorpolygons)
            {
                sb.AppendLine($@"<polygon id=""{x.CtrAbbr}-{BldgId}"" title=""{s.SuitId}"" points="" ");
                //sb.AppendLine($@"<polygon id=""{x.CtrAbbr}-{s.SuitId}"" title=""{s.SuitId}"" points="" ");
                foreach (var p in s.Polygons)
                {
                    sb.AppendLine($"{p.X.ToString("N0").Replace(",", "")}, {p.Y.ToString("N0").Replace(",", "")}");
                }
                sb.Append("\"");
                sb.Append("/>");
            }
            sb.AppendLine("</svg>");
        }

        private void AddSVGFileHeader(string PngBase64String)
        {
            sb.AppendLine($@"<svg version = ""1.1"" id=""Map"" class=""gen-by-synoptic-designer"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" viewBox=""0 0 4200 3000"" xml:space=""preserve""><image width = ""4200"" height=""3000"" xlink:href=""data:image/png;base64,{PngBase64String}"" />");
        }

        private static string[] GetPNGPlansToProcess(string PNGInputFolder)
        {
            return Directory.GetFiles(@PNGInputFolder, "*.png");
        }

        private static string GetBuildngId(dynamic FloorSpaces)
        {
            return FloorSpaces[0].Polygons[0].BldgId;
        }

        private static void GetCntrAbbrandFloorFromPNGName(string png, out string PNGName, out dynamic x)
        {
            var f = new FileInfo(png);
            PNGName = f.Name.Replace(".png", "");
            x = Utilities.GetCenterFloorFromFileName(PNGName);
        }

        private static string ConvertPNGtoBase64String(string pngPath)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(@pngPath);
            return Convert.ToBase64String(imageArray);
        }
    }
}
