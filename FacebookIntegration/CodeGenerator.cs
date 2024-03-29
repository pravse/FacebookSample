﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FacebookIntegration
{
    /// <summary>
    /// 
    /// </summary>
    public class JavascriptSDKOptions
    {
        public string AppId = null;
        public string ChannelUrl = null;  // for cross-domain scripting scenarios
        public bool   CheckLoginStatus = true;
        public bool   EnableCookies = false;
        public bool   EnableOAuth2 = false;
        public bool   ParseXFBML = false;
        public bool   FrictionlessRequests = true;
        public bool   EnableLogging = true;

        public string GetInitParameters(bool WithAppId)
        {
            return      ((false == WithAppId)?"":("   appId  : '" + AppId + "',")) +
                        ((null == ChannelUrl)?"":("   channelURL  : '" + ChannelUrl + "',")) +
                        "   status   : " + (CheckLoginStatus?"true":"false") + "," +
                        "   cookie   : " + (EnableCookies ? "true" : "false") + "," +
                        "   oauth    : " + (EnableOAuth2 ? "true" : "false") + "," +
                        "   xfbml    : " + (ParseXFBML ? "true" : "false") + "," +
                        "   frictionlessRequests    : " + (FrictionlessRequests ? "true" : "false") + "," +
                        "   logging  : " + (EnableLogging ? "true" : "false");

        }

    }

    /// <summary>
    /// 
    /// </summary>
    public partial class CodeGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        public enum CodeStyle { HTML5,
                                IFRAME 
                                };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Options"></param>
        public CodeGenerator(JavascriptSDKOptions Options)
        {
            Debug.Assert(null != Options);
            options = Options;
        }


        /// <summary>
        /// This asynchronously loads the FB Javascript SDK (for HTML5 and XFBML)
        /// </summary>
        /// <returns></returns>
        public string Root(bool WithAppId=true)
        {
            return "<div id=\"fb-root\"></div> " +
                   "<script>  " + generateFBInit(WithAppId) + "</script> \n" +
                    generateLoadSDK() + "\n";
        }

        /// <summary
        /// This needs to be added to the <html> tag of the page in order to enable XFBML. Probably defunct.</html>
        /// </summary>
        /// <returns></returns>
        public string Namespace()
        {
            return "xmlns:fb=\"http://ogp.me/ns/fb#\"";
        }

        public string OpenGraphTags(
            string Title,
            string Type,
            string Url,
            string ImageUrl,
            string SiteName,
            string FacebookId
            )
        {
            Debug.Assert(null != Title);
            Debug.Assert(null != Type);
            Debug.Assert(null != Url);
            Debug.Assert(null != ImageUrl);
            Debug.Assert(null != SiteName);
            Debug.Assert(null != FacebookId);

            return
                "<meta property=\"og:title\" content=\"" + Title + "\" />\n" +
                "<meta property=\"og:type\" content=\"" + Type + "\" />\n" +
                "<meta property=\"og:url\" content=\"" + Url + "\" />\n" +
                "<meta property=\"og:image\" content=\"" + ImageUrl + "\" />\n" +
                "<meta property=\"og:site_name\" content=\"" + SiteName + "\" />\n" +
                "<meta property=\"fb:admins\" content=\"" + FacebookId + "\" />\n";
        }

        public string FBAppId { get {return options.AppId;} }

        #region private
        private JavascriptSDKOptions options;

        private string generateLoadSDK()
        {
            return "<script src=\"../Scripts/FBInit.js\"></script>\n"; 
        }

        private string generateFBInit(bool WithAppId)
        {
            Debug.Assert(null != options);
            return " window.fbAsyncInit = function() { \n" +
                        " FB.init({ \n" +
                        options.GetInitParameters(WithAppId) +
                        "}); \n" +
                        " if (typeof PostFBInit == 'function') { PostFBInit();}  \n" + 
                        " }; \n";
        }
        /***
        // additional initialization code here \n" +
        // Raise a JQuery event so that initialization code can be defined that subscribes to the event \n" +
        // $(\"head\").trigger('FBInitComplete'); \n" +
        // if (typeof PostFBInit == 'function') { PostFBInit();} \n" +
         * ***/

        #endregion
    }
}

