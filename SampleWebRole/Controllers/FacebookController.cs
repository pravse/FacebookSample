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
        string          SignedRequest = null;
        ISocialService  fbService = null;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            fbService = new FacebookService();
        }

        public ActionResult IFramePlugins()
        {
            string linkUrl = ConfigHelper.CreateExternalUrl(Request.Url.AbsoluteUri, Request.Url);
            string linkTitle = "Controls that use IFrames";
            string linkCaption = "Example of FB IFrame plugins";
            string pictureUrl = "http://static.howstuffworks.com/gif/willow/goldfish-info0.gif";
            string linkDescription = "Very useful if you don't know the first thing about FB APIs";

            CodeGenerator.CodeStyle Style = CodeGenerator.CodeStyle.IFRAME;
            string    homeUrl = ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url);

            SetCommonViewData(linkTitle, linkUrl, pictureUrl, linkCaption, linkDescription);

            ViewData["LikeIFrame"] = FBScriptGenerator.GenerateLike(Style,"Ref1", homeUrl);
            ViewData["ActivityFeedIFrame"] = FBScriptGenerator.GenerateActivityFeed(Style, "Ref2", "www.huffingtonpost.com,news.yahoo.com");
            ViewData["LikeFacepileIFrame"] = FBScriptGenerator.GenerateLikeFacepile(Style, homeUrl);
            ViewData["AppFacepileIFrame"] = FBScriptGenerator.GenerateAppFacepile(Style);

            return View("IFramePlugins");
        }

        private void InitHtml5ControlsViewData()
        {
            CodeGenerator.CodeStyle Style = CodeGenerator.CodeStyle.HTML5;
            string homeUrl = ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url);

            ViewData["LikeHtml5"] = FBScriptGenerator.GenerateLike(Style, "Ref1", homeUrl, true);
            ViewData["LikeBoxHtml5"] = FBScriptGenerator.GenerateLikeBox(Style, "www.facebook.com/cocacola", true, false);
            ViewData["ActivityFeedHtml5"] = FBScriptGenerator.GenerateActivityFeed(Style, "Ref4", "www.huffingtonpost.com,news.yahoo.com");
            ViewData["CommentsHtml5"] = FBScriptGenerator.GenerateComments(Style, homeUrl);
            ViewData["LikeFacepileHtml5"] = FBScriptGenerator.GenerateLikeFacepile(Style, homeUrl);
            ViewData["AppFacepileHtml5"] = FBScriptGenerator.GenerateAppFacepile(Style);
        }

        public ActionResult NoAppId()
        {
            string linkUrl = ConfigHelper.CreateExternalUrl(Request.Url.AbsoluteUri, Request.Url);
            string linkTitle = "Controls without an AppId";
            string linkCaption = "Example of FB controls that do not need an AppID";
            string pictureUrl = "http://static.howstuffworks.com/gif/willow/goldfish-info0.gif";
            string linkDescription = "Very useful if you don't know the first thing about FB APIs";

            SetCommonViewData(linkTitle, linkUrl, pictureUrl, linkCaption, linkDescription);

            InitHtml5ControlsViewData();

            return View("NoAppId");
        }

        public ActionResult WithAppId()
        {
            string linkUrl = ConfigHelper.CreateExternalUrl(Request.Url.AbsoluteUri, Request.Url);
            string linkTitle = "Controls with an AppId";
            string linkCaption = "Example of FB controls that use an AppID";
            string pictureUrl = "http://static.howstuffworks.com/gif/willow/goldfish-info0.gif";
            string linkDescription = "Very useful if you don't know the first thing about FB APIs";

            SetCommonViewData(linkTitle, linkUrl, pictureUrl, linkCaption, linkDescription);

            InitHtml5ControlsViewData();

            return View("WithAppId");
        }

        public ActionResult AddFriendCallback()
        {
            Debug.Assert(null != fbService);
            if (null != this.Request["action"])
            {
                fbService.AddFriendResponse(this.Request["action"]);
            }

            // return RedirectToAction("Dialogs", "Facebook");
            // Better to redirect, but doing this for now to ensure that the same controller state is maintained
            return Dialogs();
        }

        public ActionResult Dialogs()
        {
            Debug.Assert(null != fbService);
            ViewData.Model = fbService.Model;

            string dialogsUrl = ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Facebook", action = "Dialogs", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url);
            string addFriendCallbackUrl = ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Facebook", action = "AddFriendCallback", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url);
            string linkUrl = ConfigHelper.CreateExternalUrl(Request.Url.AbsoluteUri, Request.Url);
            string linkTitle = "Interacting via Dialogs"; 
            string linkCaption = "Example of FB dialogs";
            string pictureUrl = "http://static.howstuffworks.com/gif/willow/goldfish-info0.gif";
            string linkDescription = "Very useful if you don't know the first thing about FB APIs";

            SetCommonViewData(linkTitle, linkUrl, pictureUrl, linkCaption, linkDescription);

            ViewData["FriendsDialogUriPage"] = FBScriptGenerator.FriendDialogUri("Satya.Nadella", addFriendCallbackUrl, false);
            ViewData["FriendsDialogUriIFrame"] = FBScriptGenerator.FriendDialogUri("Satya.Nadella", addFriendCallbackUrl, true);

            ViewData["FeedDialogUriPage"] = FBScriptGenerator.FeedDialogUri(dialogsUrl, linkUrl, linkTitle, linkCaption, linkDescription, pictureUrl, false);
            ViewData["FeedDialogUriIFrame"] = FBScriptGenerator.FeedDialogUri(dialogsUrl, linkUrl, linkTitle, linkCaption, linkDescription, pictureUrl, true);

            ViewData["SendDialogUriPage"] = FBScriptGenerator.SendDialogUri("praveen.seshadri", dialogsUrl, linkUrl, linkTitle, linkCaption, linkDescription, pictureUrl, false);
            ViewData["SendDialogUriIFrame"] = FBScriptGenerator.SendDialogUri("praveen.seshadri", dialogsUrl, linkUrl, linkTitle, linkCaption, linkDescription, pictureUrl, true);

            return View("Dialogs");
        }

        public ActionResult Queries()
        {
            string linkUrl = ConfigHelper.CreateExternalUrl(Request.Url.AbsoluteUri, Request.Url);
            string linkTitle = "Queries over the graph API";
            string linkCaption = "Example of FB queries using the graph API";
            string pictureUrl = "http://static.howstuffworks.com/gif/willow/goldfish-info0.gif";
            string linkDescription = "Very useful if you don't know the first thing about FB APIs";
            CodeGenerator.CodeStyle Style = CodeGenerator.CodeStyle.HTML5;

            SetCommonViewData(linkTitle, linkUrl, pictureUrl, linkCaption, linkDescription);

            ViewData["LikeBoxHtml5"] = FBScriptGenerator.GenerateLikeBox(
                            Style,
                            "http://www.facebook.com/cocacola",
                            true, true);

            return View("Queries");
        }

        // **************************************
        // URL: /Facebook/LogOn
        // **************************************
        public ActionResult LogOn()
        {
            string linkUrl = ConfigHelper.CreateExternalUrl(Request.Url.AbsoluteUri, Request.Url);
            string linkTitle = "LogOn using FB OAuth2.0";
            string linkCaption = "How to LogOn via Facebook authentication";
            string pictureUrl = "http://static.howstuffworks.com/gif/willow/goldfish-info0.gif";
            string linkDescription = "Very useful if you don't know the first thing about FB APIs";

            SetCommonViewData(linkTitle, linkUrl, pictureUrl, linkCaption, linkDescription);

            FBPermissions Permissions = new FBPermissions();
            Permissions.AddUserPermission(FBUserAndFriendPermissions.ABOUT_ME);
            Permissions.AddUserPermission(FBUserAndFriendPermissions.BIRTHDAY);
            Permissions.AddUserPermission(FBUserAndFriendPermissions.EMAIL);
            Permissions.AddFriendsPermission(FBUserAndFriendPermissions.ABOUT_ME);
            Permissions.AddExtendedPermission(FBExtendedPermissions.READ_MAILBOX);
            Permissions.AddExtendedPermission(FBExtendedPermissions.OFFLINE_ACCESS);

            ViewData["FBLoginHtml5"] = FBScriptGenerator.GenerateLogin(CodeGenerator.CodeStyle.HTML5, Permissions, true, 200, 1);

            ViewData["FBRegisterOrLoginHtml5"] = FBScriptGenerator.GenerateRegisterOrLogin(CodeGenerator.CodeStyle.HTML5,
                      ConfigHelper.CreateExternalUrl(this.Url.RouteUrl("Default", new { controller = "Facebook", action = "Register", id = UrlParameter.Optional }, Request.Url.Scheme), Request.Url),
                      Permissions);

            return View("LogOn");
        }

        // **************************************
        // URL: /Facebook/Register
        // **************************************
        public ActionResult Register()
        {
            string linkUrl = ConfigHelper.CreateExternalUrl(Request.Url.AbsoluteUri, Request.Url);
            string linkTitle = "Register using FB";
            string linkCaption = "How to Register via Facebook";
            string pictureUrl = "http://static.howstuffworks.com/gif/willow/goldfish-info0.gif";
            string linkDescription = "Very useful if you don't know the first thing about FB APIs";

            SetCommonViewData(linkTitle, linkUrl, pictureUrl, linkCaption, linkDescription);

            string RegistrationCallbackUri = (null != ConfigHelper.GetConfigurationSettingValue(FBRegCallbackKey)) ?
                                                ConfigHelper.GetConfigurationSettingValue(FBRegCallbackKey) : linkUrl;

            ViewData["FBRegistrationIFrame"] = FBScriptGenerator.GenerateRegister(CodeGenerator.CodeStyle.IFRAME, RegistrationCallbackUri);
            ViewData["FBRegistrationHtml5"] = FBScriptGenerator.GenerateRegister(CodeGenerator.CodeStyle.HTML5, RegistrationCallbackUri);

            if (null != SignedRequest)
            {
                ViewData["SignedRequest"] = SignedRequest;
            }
 
            return View("Register");
        }

        [HttpPost]
        public ActionResult RegisterCallback()
        {
            SignedRequest = this.Request["signed_request"];
            Debug.Assert(null != SignedRequest);

            // should have received a signed request. Get it and try to decipher it: TODO

            return RedirectToAction("Index", "Home");

         }

    }
}
