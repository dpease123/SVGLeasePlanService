using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SVGLeasePlanService
{
    public static class FileManager
    {
        private static StringBuilder sb = new StringBuilder();
       
        public static StringBuilder TodaysPNGtobeCovertedtoSVG()
        {
            var files = Directory.GetFiles(@"c:\temp\plans\input", "*.png").ToList();
          
            foreach (var f in files)
            {

                   var stream = File.OpenText(f).ReadToEnd();
                   sb.AppendLine($@"<svg version = ""1.1"" id=""Map"" class=""gen-by-synoptic-designer"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" viewBox=""0 0 4200 3000"" xml:space=""preserve""><image width = ""4200"" height=""3000"" xlink:href=""data:image/png;base64,{stream}"" />");

            }
            return sb;
        }

    }
}
