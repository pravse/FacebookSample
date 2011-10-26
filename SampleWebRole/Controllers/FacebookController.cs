using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using SampleWebRole.Models;
using FacebookIntegration;

namespace SampleWebRole.Controllers
{

    [HandleError]
    public class FacebookController : FBEnabledController
    {

        public ActionResult IFramePlugins()
        {
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
                            this.Url.RouteUrl("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, Request.Url.Scheme));

            ViewData["ActivityFeedIFrame"] = FBScriptGenerator.GenerateActivityFeed(
                                        Style,
                                        "Ref2",
                                        "www.huffingtonpost.com,news.yahoo.com");

            ViewData["LikeFacepileIFrame"] = FBScriptGenerator.GenerateLikeFacepile(
                Style,
                this.Url.RouteUrl("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, Request.Url.Scheme));

            ViewData["AppFacepileIFrame"] = FBScriptGenerator.GenerateAppFacepile(Style);

            return View();
        }

        public ActionResult NoAppId()
        {
            CodeGenerator.CodeStyle Style = CodeGenerator.CodeStyle.HTML5;

            // TODO: put in appropriate tags
            ViewData["OpenGraphTags"] = FBScriptGenerator.GenerateOpenGraphTags(
                "Dummy Title", // title
                "website", // type
                "http://www.example.com", // url
                "http://www.example.com/image.gif", // url of an image
                "Example of FB controls that don't need AppId", // site name (simple description)
                FBScriptGenerator.FBAppId); // id of a facebook user or application id

            ViewData["FBRootWithoutAppId"] = FBScriptGenerator.GenerateRoot(false);

            ViewData["LikeHtml5"] = FBScriptGenerator.GenerateLike(
                            Style,
                            "Ref3",
                            this.Url.RouteUrl("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, Request.Url.Scheme),
                            true);

            ViewData["LikeBoxHtml5"] = FBScriptGenerator.GenerateLikeBox(
                            Style, 
//                            this.Url.Encode("http://www.facebook.com/praveen.seshadri"),
                            "http://www.facebook.com/praveen.seshadri",
                            true, true);

            ViewData["ActivityFeedHtml5"] = FBScriptGenerator.GenerateActivityFeed(
                                        Style,
                                        "Ref4",
                                        "www.huffingtonpost.com,news.yahoo.com");

            ViewData["CommentsHtml5"] = FBScriptGenerator.GenerateComments(
                            Style,
                            this.Url.RouteUrl("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, Request.Url.Scheme));

            ViewData["LikeFacepileHtml5"] = FBScriptGenerator.GenerateLikeFacepile(
                Style,
                //                this.Url.RouteUrl("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, Request.Url.Scheme));
                "http://www.facebook.com/cocacola");

            return View();
        }

        public ActionResult Dialogs()
        {
            // TODO: put in appropriate tags
            ViewData["OpenGraphTags"] = FBScriptGenerator.GenerateOpenGraphTags(
                "Dummy Title", // title
                "website", // type
                "http://www.example.com", // url
                "http://www.example.com/image.gif", // url of an image
                "Example of FB dialogs", // site name (simple description)
                FBScriptGenerator.FBAppId); // id of a facebook user or application id

            ViewData["FriendsDialogURI"] = FBScriptGenerator.FriendDialogUri("4", "www.example.com");

            return View();
        }

        public ActionResult WithAppId()
        {
            CodeGenerator.CodeStyle Style = CodeGenerator.CodeStyle.HTML5;

            // TODO: put in appropriate tags
            ViewData["OpenGraphTags"] = FBScriptGenerator.GenerateOpenGraphTags(
                "Dummy Title", // title
                "website", // type
                "http://www.example.com", // url
                "http://www.example.com/image.gif", // url of an image
                "Example of FB controls that use AppId", // site name (simple description)
                FBScriptGenerator.FBAppId); // id of a facebook user or application id

            ViewData["FBRoot"] = FBScriptGenerator.GenerateRoot(true);

            ViewData["LikeBoxHtml5"] = FBScriptGenerator.GenerateLikeBox(
                            Style,
                //                            this.Url.Encode("http://www.facebook.com/cocacola"),
                            "http://www.facebook.com/cocacola",
                            true, true);



            ViewData["FriendsDialogURI"] = FBScriptGenerator.FriendDialogUri("4", "www.example.com");

            ViewData["AppFacepileHtml5"] = FBScriptGenerator.GenerateAppFacepile(Style);

            return View();
        }

        public ActionResult RicherJS()
        {
            CodeGenerator.CodeStyle Style = CodeGenerator.CodeStyle.HTML5;

            ViewData["FBRoot"] = FBScriptGenerator.GenerateRoot(true);

            // TODO: put in appropriate tags
            ViewData["OpenGraphTags"] = FBScriptGenerator.GenerateOpenGraphTags(
                "Dummy Title", // title
                "website", // type
                "http://www.example.com", // url
                "http://www.example.com/image.gif", // url of an image
                "Example of FB controls that use AppId", // site name (simple description)
                FBScriptGenerator.FBAppId); // id of a facebook user or application id

            ViewData["LikeBoxHtml5"] = FBScriptGenerator.GenerateLikeBox(
                            Style,
                //                            this.Url.Encode("http://www.facebook.com/cocacola"),
                            "http://www.facebook.com/cocacola",
                            true, true);



            ViewData["FriendsDialogURI"] = FBScriptGenerator.FriendDialogUri("4", "www.example.com");

            return View();
        }

        // **************************************
        // URL: /Facebook/LogOn
        // **************************************
        public ActionResult LogOn()
        {
            ViewData["FBRoot"] = FBScriptGenerator.GenerateRoot(true);
            ViewData["FBLoginHtml5"] = FBScriptGenerator.GenerateLogin(CodeGenerator.CodeStyle.HTML5, null, true, 200, 1);

            ViewData["FBRegisterOrLoginHtml5"] = FBScriptGenerator.GenerateRegisterOrLogin(CodeGenerator.CodeStyle.HTML5, 
                      this.Url.RouteUrl("Default", new { controller = "Facebook", action = "Register", id = UrlParameter.Optional }, Request.Url.Scheme));

            return View();
        }

        // **************************************
        // URL: /Facebook/Register
        // **************************************
        public ActionResult Register()
        {
            ViewData["FBRoot"] = FBScriptGenerator.GenerateRoot(true);

            string RegistrationCallbackUri = (null != ConfigHelper.GetConfigurationSettingValue(FBRegCallbackKey)) ?
                                                ConfigHelper.GetConfigurationSettingValue(FBRegCallbackKey) :
                                                this.Url.RouteUrl("Default", new { controller = "Facebook", action = "Register", id = UrlParameter.Optional }, Request.Url.Scheme);

            ViewData["FBRegistrationIFrame"] = FBScriptGenerator.GenerateRegister(CodeGenerator.CodeStyle.IFRAME, RegistrationCallbackUri);
            ViewData["FBRegistrationHtml5"] = FBScriptGenerator.GenerateRegister(CodeGenerator.CodeStyle.HTML5, RegistrationCallbackUri);
            return View();
        }

        [HttpPost]
        public ActionResult Register(string SignedRequest)
        {
            return RedirectToAction("Index", "Home");
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
