using SVGLeasePlanService.Data;
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
        FWIContext _dbContect = new FWIContext();
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
            using (var ctx = new FWIContext())
            {
                foreach (var l in logs)
                {
                    var fi = new FileInfo(l);
                    var sql = $@"INSERT INTO PLayerLogXML(XMLData, LoadedDateTime, Name)
                        SELECT CONVERT(XML, BulkColumn) AS BulkColumn, GETDATE(),'{fi.Name}' 
                        FROM OPENROWSET(BULK '{l}', SINGLE_BLOB) AS x;";
                   ctx.Database.ExecuteSqlCommand(sql);
                }
            }

        }
    }
}
