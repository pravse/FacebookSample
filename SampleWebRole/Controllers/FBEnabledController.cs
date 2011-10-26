using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Configuration;
using AzureHelper;
using SampleWebRole.Models;
using FacebookIntegration;

namespace SampleWebRole.Controllers
{
    public abstract class FBEnabledController : Controller
    {
        static public string FBAppIdLookupKey = "FBAppId";
        static public string FBRegCallbackKey = "FBRegistrationCallback";

        public CodeGenerator FBScriptGenerator { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            JavascriptSDKOptions Options = new JavascriptSDKOptions();
            Options.AppId = ConfigHelper.GetConfigurationSettingValue(FBAppIdLookupKey);
            Options.ChannelUrl = null;
            Options.CheckLoginStatus = true;
            Options.EnableCookies = true;
            Options.EnableLogging = true;
            Options.EnableOAuth2 = true;
            Options.ParseXFBML = true;

            FBScriptGenerator = new CodeGenerator(Options);
        }

   
    }
}