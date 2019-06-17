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
            log.Info("Hello from GenerateSVGJob job! This where the work happens...");
            SVGBuilder SVGBuilder = new SVGBuilder();
            try
            {
                log.Info("GenerateSVGJob starting...");
                await SVGBuilder.Build();
                log.Info("GenerateSVGJob done");
            }
            catch(Exception ex)
            {
                log.Error(ex.ToString());
            }
        }
    }
}
