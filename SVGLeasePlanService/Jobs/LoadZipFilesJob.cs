using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVGLeasePlanService.Jobs.Workers;

namespace SVGLeasePlanService.Jobs
{
    public class LoadZipFilesJob : IJob
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public async Task Execute(IJobExecutionContext context)
        {
            LoadZipFilesWorker LoadZipFilesWorker = new LoadZipFilesWorker();
            try
            {
                log.Info("-----------------------------------------------------------------------------------------------------");
                log.Info("LoadZipFilesJob Starting...");
                await LoadZipFilesWorker.Work();
                log.Info("LoadZipFilesJob Done!");
                log.Info("-----------------------------------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }
    }
}
