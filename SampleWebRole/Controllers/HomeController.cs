using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FacebookIntegration;

namespace SampleWebRole.Controllers
{
    [HandleError]
    public class HomeController : FBEnabledController
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to the Facebook Sample App";
            System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            ViewData["AppBuildVersion"] = version.ToString();
            return View();
        }

    }
}
