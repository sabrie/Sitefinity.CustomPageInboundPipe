using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Telerik.Sitefinity.Publishing;
using Telerik.Sitefinity.Publishing.Pipes;

namespace SitefinityWebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Telerik.Sitefinity.Abstractions.Bootstrapper.Initialized += Bootstrapper_Initialized;
        }

        void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs e)
        {
            if (e.CommandName == "Bootstrapped")
            {
                PublishingSystemFactory.UnregisterPipe(PageInboundPipe.PipeName);
                PublishingSystemFactory.RegisterPipe(PageInboundPipeCustom.PipeName, typeof(PageInboundPipeCustom));
            }
        }        
    }
}