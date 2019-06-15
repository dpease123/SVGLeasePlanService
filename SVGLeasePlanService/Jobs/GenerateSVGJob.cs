using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using SVGLeasePlanService.Data;

namespace SVGLeasePlanService.Jobs
{
    public class GenerateSVGJob : IJob
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly LDBRepository _repo = new LDBRepository();
        StringBuilder sb = new StringBuilder();
        

        public async Task Execute(IJobExecutionContext context)
        {
            log.Info("Hello from GenerateSVGJob job! This where the work happens...");
            var FileName = "CCK2";
            var x = Utilities.GetCenterFloorFromFileName(FileName);
            //var Building = _repo.GetBuilding(x.CtrAbbr);
            var floor = int.Parse(x.Floor);
            var start = FileManager.TodaysPNGtobeCovertedtoSVG();
            var spaces = _repo.GetPolygonsByCenterandFloor("CCK", 2);
            sb.AppendLine(start.ToString());
            foreach (var s in spaces)
            {

               sb.AppendLine($@"<polygon id=""_x31_224 - {s.SuitId}"" title=""{s.SuitId} "" />");

            }

            Console.WriteLine(sb.ToString());


        }
    }
}
