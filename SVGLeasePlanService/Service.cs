using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using System.Collections.Specialized;

namespace SVGLeasePlanService
{
    public class Service
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Start()
        {
            // write code here that runs when the Windows Service starts up. 
            log.Info("SVGLeasePlanService started.");
            RunProgram().GetAwaiter().GetResult();

        }
        public void Stop()
        {
            // write code here that runs when the Windows Service stops.  
            log.Info("SVGLeasePlanService stopped.");
        }

        private static async Task RunProgram()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };

                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

                // some sleep to show what's happening
                await Task.Delay(TimeSpan.FromSeconds(60));

                // and last shut down the scheduler when you are ready to close your program
                await scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }
    }
}

