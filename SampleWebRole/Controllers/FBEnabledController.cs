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
using System.Diagnostics;
using SampleWebRole.Models;
using FacebookIntegration;

namespace SampleWebRole.Controllers
{
    public abstract class FBEnabledController : Controller
    {
        static public string FBAppIdLookupKey = "FBAppId";
        static public string FBRegCallbackKey = "FBRegistrationCallback";


#if  !RUNNING_IN_AZURE
        public class ConfigHelper
        {
            static public string GetConfigurationSettingValue(string SettingKey)
            {
                return ConfigurationManager.AppSettings[SettingKey];
            }

            static public string GetHostName()
            {
                return ConfigurationManager.AppSettings["host"];
            }

            static public string CreateExternalUrl(string ReturnUrl, Uri BaseUri)
            {
                return ReturnUrl.Replace((BaseUri.Host +":"+ BaseUri.Port), BaseUri.Host);
            }
        }


#endif

        public System.Version  CodeVersion;   // useful to print the build version with the app UI

        public CodeGenerator FBScriptGenerator { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            CodeVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

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

        protected virtual void SetCommonViewData(string PageTitle, string PageUrl, string PageGifUrl, string PageCaption, string PageDescription)
        {
            Debug.Assert(null != PageTitle);
            Debug.Assert(null != PageUrl);
            Debug.Assert(null != PageGifUrl);
            Debug.Assert(null != PageDescription);
            Debug.Assert(null != PageCaption);

            ViewData["AppBuildVersion"] = CodeVersion.ToString();
            ViewData["OpenGraphTags"] = FBScriptGenerator.GenerateOpenGraphTags(PageTitle, "website", PageUrl, PageGifUrl, PageDescription, FBScriptGenerator.FBAppId);
            ViewData["PageTitle"] = PageTitle;
            ViewData["PageUrl"] = PageUrl;
            ViewData["PageGifUrl"] = PageGifUrl;
            ViewData["PageCaption"] = PageCaption;
            ViewData["PageDescription"] = PageDescription;

            ViewData["FBRoot"] = FBScriptGenerator.GenerateRoot(true);
            ViewData["FBRootWithoutAppId"] = FBScriptGenerator.GenerateRoot(false);

        }

   
    }
}