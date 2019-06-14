using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGLeasePlanService
{
    public class Service
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void Start()
        {
            // write code here that runs when the Windows Service starts up. 
            log.Info("SVGLeasePlanService started.");
            
        }
        public void Stop()
        {
            // write code here that runs when the Windows Service stops.  
            log.Info("SVGLeasePlanService stopped.");
        }
    }
}
