using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Diagnostics;
using SampleWebRole.Models;
using FacebookIntegration;

namespace SampleWebRole.Controllers
{

    [HandleError]
    public class FacebookController : FBEnabledController
    {
        string SignedRequest = null;
        ISocialService fbService = new FacebookService();

        public ActionResult IFramePlugins()
        {
            SetCommonViewData();

            CodeGenerator.CodeStyle Style = CodeGenerator.CodeStyle.IFRAME;

            // TODO: put in appropriate tags
            ViewData["OpenGraphTags"] = FBScriptGenerator.GenerateOpenGraphTags(
                "Dummy Title", // title
                "website", // type
                "http://www.example.com", // url
                "http://www.example.com/image.gif", // url of an image
                "Example of IFrame Plugins", // site name (simple description)
                FBScriptGenerator.FBAppId); // id of a facebook user or application id

            ViewData["LikeIFrame"] = FBScriptGenerator.GenerateLike(
                            Style,
                            "Ref1",
                            ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, Request.Url.Scheme),
                                                           Request.Url));

            ViewData["ActivityFeedIFrame"] = FBScriptGenerator.GenerateActivityFeed(
                                        Style,
                                        "Ref2",
                                        "www.huffingtonpost.com,news.yahoo.com");

            ViewData["LikeFacepileIFrame"] = FBScriptGenerator.GenerateLikeFacepile(
                Style,
                ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, Request.Url.Scheme),
                                                Request.Url));

            ViewData["AppFacepileIFrame"] = FBScriptGenerator.GenerateAppFacepile(Style);

            return View();
        }

        public void InitHtml5ControlsViewData()
        {
            CodeGenerator.CodeStyle Style = CodeGenerator.CodeStyle.HTML5;

            ViewData["FBRootWithoutAppId"] = FBScriptGenerator.GenerateRoot(false);
            ViewData["FBRoot"] = FBScriptGenerator.GenerateRoot(true);

            ViewData["LikeHtml5"] = FBScriptGenerator.GenerateLike(
                            Style,
                            "Ref3",
                            ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url),
                            true);

            ViewData["LikeBoxHtml5"] = FBScriptGenerator.GenerateLikeBox(
                            Style,
                //                            this.Url.Encode("http://www.facebook.com/praveen.seshadri"),
                            "www.facebook.com/cocacola",
                            true, false);

            ViewData["ActivityFeedHtml5"] = FBScriptGenerator.GenerateActivityFeed(
                                        Style,
                                        "Ref4",
                                        "www.huffingtonpost.com,news.yahoo.com");

            ViewData["CommentsHtml5"] = FBScriptGenerator.GenerateComments(
                            Style,
                            ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url));

            ViewData["LikeFacepileHtml5"] = FBScriptGenerator.GenerateLikeFacepile(
                Style,
                ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url));

            ViewData["AppFacepileHtml5"] = FBScriptGenerator.GenerateAppFacepile(Style);

        }

        public ActionResult NoAppId()
        {
            SetCommonViewData();

            InitHtml5ControlsViewData();

            // TODO: put in appropriate tags
            ViewData["OpenGraphTags"] = FBScriptGenerator.GenerateOpenGraphTags(
                "Dummy Title", // title
                "website", // type
                "http://www.example.com", // url
                "http://www.example.com/image.gif", // url of an image
                "Example of FB controls that don't need AppId", // site name (simple description)
                FBScriptGenerator.FBAppId); // id of a facebook user or application id

            return View();
        }

        public ActionResult WithAppId()
        {
            SetCommonViewData();

            InitHtml5ControlsViewData();

            // TODO: put in appropriate tags
            ViewData["OpenGraphTags"] = FBScriptGenerator.GenerateOpenGraphTags(
                "Dummy Title", // title
                "website", // type
                "http://www.example.com", // url
                "http://www.example.com/image.gif", // url of an image
                "Example of FB controls that use AppId", // site name (simple description)
                FBScriptGenerator.FBAppId); // id of a facebook user or application id

            return View();
        }

        public ActionResult AddFriendCallback()
        {
            Debug.Assert(null != fbService);
            if (null != this.Request["action"])
            {
                fbService.AddFriendResponse(this.Request["action"]);
            }
            else
            {
                fbService.AddFriendResponse("yahoo");
            }
            Debug.Assert(true == fbService.Model.AddFriendResponseValid);

            return RedirectToAction("Dialogs", "Facebook");
        }

        public ActionResult Dialogs()
        {
            SetCommonViewData();

            Debug.Assert(null != fbService);
            if (false == fbService.Model.AddFriendResponseValid)
            {
                fbService.AddFriendResponse("placeholder");
            }

            ViewData.Model = fbService.Model;

            // TODO: put in appropriate tags
            ViewData["OpenGraphTags"] = FBScriptGenerator.GenerateOpenGraphTags(
                "Dummy Title", // title
                "website", // type
                "http://www.example.com", // url
                "http://www.example.com/image.gif", // url of an image
                "Example of FB dialogs", // site name (simple description)
                FBScriptGenerator.FBAppId); // id of a facebook user or application id

            ViewData["FBRoot"] = FBScriptGenerator.GenerateRoot(true);

            ViewData["FriendsDialogUriPage"] = FBScriptGenerator.FriendDialogUri("Satya.Nadella",
                                                ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Facebook", action = "AddFriendCallback", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url),
                                                false);

            ViewData["FriendsDialogUriIFrame"] = FBScriptGenerator.FriendDialogUri("Satya.Nadella",
                                                ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Facebook", action = "Dialogs", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url),
                                                true);

            ViewData["FeedDialogUriPage"] = FBScriptGenerator.FeedDialogUri(
                                                ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Facebook", action = "Dialogs", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url),
                                                ConfigHelper.CreateExternalUrl(Request.Url.AbsoluteUri, Request.Url),
                                                "Sample FB Dialogs",
                                                "Some simple samples of FB Dialogs",
                                                "Very useful if you don't know the first thing about FB APIs",
                                                "http://static.howstuffworks.com/gif/willow/goldfish-info0.gif",
                                                false);

            ViewData["FeedDialogUriIFrame"] = FBScriptGenerator.FeedDialogUri(
                                     ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Facebook", action = "Dialogs", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url),
                                     ConfigHelper.CreateExternalUrl(Request.Url.AbsoluteUri, Request.Url),
                                     "Sample FB Dialogs",
                                     "Some simple samples of FB Dialogs",
                                     "Very useful if you don't know the first thing about FB APIs",
                                     "http://static.howstuffworks.com/gif/willow/goldfish-info0.gif",
                                     true);

            ViewData["SendDialogUriPage"] = FBScriptGenerator.SendDialogUri(
                                                ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Facebook", action = "Dialogs", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url),
                                                "praveen.seshadri",
                                                ConfigHelper.CreateExternalUrl(Request.Url.AbsoluteUri, Request.Url),
                                                "Sample FB Dialogs",
                                                "Some simple samples of FB Dialogs",
                                                "Very useful if you don't know the first thing about FB APIs",
                                                "http://static.howstuffworks.com/gif/willow/goldfish-info0.gif",
                                                false);

            ViewData["SendDialogUriIFrame"] = FBScriptGenerator.SendDialogUri(
                                     ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Facebook", action = "Dialogs", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url),
                                     "praveen.seshadri",
                                     ConfigHelper.CreateExternalUrl(Request.Url.AbsoluteUri, Request.Url),
                                     "Sample FB Dialogs",
                                     "Some simple samples of FB Dialogs",
                                     "Very useful if you don't know the first thing about FB APIs",
                                     "http://static.howstuffworks.com/gif/willow/goldfish-info0.gif",
                                     true);

            return View();
        }

        public ActionResult Queries()
        {
            SetCommonViewData();

            CodeGenerator.CodeStyle Style = CodeGenerator.CodeStyle.HTML5;

            ViewData["FBRoot"] = FBScriptGenerator.GenerateRoot(true);

            // TODO: put in appropriate tags
            ViewData["OpenGraphTags"] = FBScriptGenerator.GenerateOpenGraphTags(
                "Dummy Title", // title
                "website", // type
                "http://www.example.com", // url
                "http://www.example.com/image.gif", // url of an image
                "Example of FB queries", // site name (simple description)
                FBScriptGenerator.FBAppId); // id of a facebook user or application id

            ViewData["LikeBoxHtml5"] = FBScriptGenerator.GenerateLikeBox(
                            Style,
                            "http://www.facebook.com/cocacola",
                            true, true);

            return View();
        }

        // **************************************
        // URL: /Facebook/LogOn
        // **************************************
        public ActionResult LogOn()
        {
            SetCommonViewData();

            ViewData["FBRoot"] = FBScriptGenerator.GenerateRoot(true);
            ViewData["FBLoginHtml5"] = FBScriptGenerator.GenerateLogin(CodeGenerator.CodeStyle.HTML5, null, true, 200, 1);

            ViewData["FBRegisterOrLoginHtml5"] = FBScriptGenerator.GenerateRegisterOrLogin(CodeGenerator.CodeStyle.HTML5,
                      ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Facebook", action = "Register", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url));

            return View();
        }

        // **************************************
        // URL: /Facebook/Register
        // **************************************
        public ActionResult Register()
        {
            SetCommonViewData();

            ViewData["FBRoot"] = FBScriptGenerator.GenerateRoot(true);

            string RegistrationCallbackUri = (null != ConfigHelper.GetConfigurationSettingValue(FBRegCallbackKey)) ?
                                                ConfigHelper.GetConfigurationSettingValue(FBRegCallbackKey) :
                                                ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Facebook", action = "RegisterCallback", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url);

            ViewData["FBRegistrationIFrame"] = FBScriptGenerator.GenerateRegister(CodeGenerator.CodeStyle.IFRAME, RegistrationCallbackUri);
            ViewData["FBRegistrationHtml5"] = FBScriptGenerator.GenerateRegister(CodeGenerator.CodeStyle.HTML5, RegistrationCallbackUri);

            if (null != SignedRequest)
            {
                ViewData["SignedRequest"] = SignedRequest;
            }
 
            return View();
        }

        [HttpPost]
        public ActionResult RegisterCallback()
        {
            SignedRequest = this.Request["signed_request"];
            Debug.Assert(null != SignedRequest);

            // should have received a signed request. Get it and try to decipher it
            return RedirectToAction("Register", "Facebook");
            /****
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsService.SignIn(model.UserName, false );
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            ****/
         }

    }
}
