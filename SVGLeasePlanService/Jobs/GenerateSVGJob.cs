using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task Execute(IJobExecutionContext context)
        {
            SVGWorker SVGWorker = new SVGWorker();
            try
            {
                log.Info("-----------------------------------------------------------------------------------------------------");
                log.Info("GenerateSVGJob Starting...");
                await SVGWorker.Work();
                log.Info("GenerateSVGJob Done!");
                log.Info("-----------------------------------------------------------------------------------------------------");
            }
            catch(Exception ex)
            {
                log.Error(ex.ToString());
            }
        }
    }
}
