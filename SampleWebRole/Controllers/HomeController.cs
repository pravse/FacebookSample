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
            string linkUrl = ConfigHelper.CreateExternalUrl(Request.Url.AbsoluteUri, Request.Url);
            string linkTitle = "Home page -- FB API Sample";
            string linkCaption = "Examples of FB API usage";
            string pictureUrl = "http://static.howstuffworks.com/gif/willow/goldfish-info0.gif";
            string linkDescription = "Very useful if you don't know the first thing about FB APIs";

            SetCommonViewData(linkTitle, linkUrl, pictureUrl, linkCaption, linkDescription);

            if (null != this.Request["request_ids"])
            {
                // The user has come to this page hosted as a FB canvas page by clicking on a request sent by the application.
                // The app needs to read the request ids, process them and delete them
                ViewData["RequestIds"] = this.Request["request_ids"];
            }

            return View();
        }

    }
}
