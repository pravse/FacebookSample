using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcWebRole1
{
#if RUNNING_IN_AZURE
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
#endif
}
