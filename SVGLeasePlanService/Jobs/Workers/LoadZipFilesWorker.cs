using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGLeasePlanService.Jobs.Workers
{
    public class LoadZipFilesWorker
    {
        public async Task Work()
        {
            var zipPath = (@"C:\Temp\UnZipSource");
            var extractPath = (@"C:\Temp\UnZipTarget");

            string[] zips = Directory.GetFiles(zipPath);
            foreach (var z in zips)
            {
                ZipFile.ExtractToDirectory(z, extractPath);

            }


            var logs = Directory.GetFiles(@extractPath, "*.log");
            foreach (var log in logs)
            {
                ZipFile.ExtractToDirectory(z, extractPath);

            }

        }
    }
}
