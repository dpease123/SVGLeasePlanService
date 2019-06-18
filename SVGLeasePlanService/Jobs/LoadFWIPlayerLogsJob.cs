using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SVGLeasePlanService.Jobs.Workers;

namespace SVGLeasePlanService.Jobs
{
    public class LoadFWIPlayerLogsJob : IJob
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public async Task Execute(IJobExecutionContext context)
        {
            LoadFWIPlayerLogsWorker LoadFWIPlayerLogsWorker = new LoadFWIPlayerLogsWorker();
            try
            {
                log.Info("-----------------------------------------------------------------------------------------------------");
                log.Info("LoadFWIPlayerLogsJob Starting...");
                await LoadFWIPlayerLogsWorker.Work();
                log.Info("LoadFWIPlayerLogsJob Done!");
                log.Info("-----------------------------------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
            }
        }
    }
}
