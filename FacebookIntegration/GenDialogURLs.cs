using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;

namespace FacebookIntegration
{
    public partial class CodeGenerator
    {
#region private
        static private string friendDialogUri = "http://www.facebook.com/dialog/friends";
        static private string feedDialogUri = "http://www.facebook.com/dialog/feed";
        static private string sendDialogUri = "http://www.facebook.com/dialog/send";
        static private string oauthDialogUri = "http://www.facebook.com/dialog/oauth";
#endregion

        public string FriendDialogUri(
            string FriendId, 
            string RedirectUri,
            bool   ShowInIFrame = true,
            bool   ShowError = true)
        {
            return  friendDialogUri + "/?" +
                "id=" + FriendId + "&" +
                "app_id=" + this.FBAppId + "&" +
                "redirect_uri=" + RedirectUri + "&" +
                "display=" + ((false == ShowInIFrame) ? "page" : "iframe") + "&" +
                ((true == ShowInIFrame) ? "access_token=ACCESS_TOKEN_STUB&" : "") +
                "show_error=" + ((false == ShowError) ? "false" : "true");
        }

        public string FeedDialogUri(
            string RedirectUri,
            string LinkUri,
            string LinkName,
            string LinkCaption,
            string LinkDescription,
            string PictureUri,
            bool ShowInIFrame = true,
            bool ShowError = true)
        {
            return feedDialogUri + "/?" +
                "app_id=" + this.FBAppId + "&" +
                "redirect_uri=" + RedirectUri + "&" +
                "link=" + LinkUri + "&" +
                "name=" + LinkName + "&" +
                "caption=" + LinkCaption + "&" +
                "description=" + LinkDescription + "&" +
                "picture=" + PictureUri + "&" +
                "display=" + ((false == ShowInIFrame) ? "page" : "iframe") + "&" +
                ((true == ShowInIFrame) ? "access_token=ACCESS_TOKEN_STUB&" : "") +
                "show_error=" + ((false == ShowError) ? "false" : "true");
        }

        public string SendDialogUri(
            string SendTo,
            string RedirectUri,
            string LinkUri,
            string LinkName,
            string LinkCaption,
            string LinkDescription,
            string PictureUri,
            bool ShowInIFrame = true,
            bool ShowError = true)
        {
            return sendDialogUri + "/?" +
                "app_id=" + this.FBAppId + "&" +
                "redirect_uri=" + RedirectUri + "&" +
                "to=" + SendTo + "&" + 
                "link=" + LinkUri + "&" +
                "name=" + LinkName + "&" +
                "caption=" + LinkCaption + "&" +
                "description=" + LinkDescription + "&" +
                "picture=" + PictureUri + "&" +
                "display=" + ((false == ShowInIFrame) ? "page" : "iframe") + "&" +
                ((true == ShowInIFrame) ? "access_token=ACCESS_TOKEN_STUB&" : "") +
                "show_error=" + ((false == ShowError) ? "false" : "true");
        }


        public enum OAuthResponseType
        {
            TOKEN
        }

        public string OAuthDialogUri(FBPermissions Permissions, OAuthResponseType ResponseType, string ClientId, string RedirectUri)
        {
            return oauthDialogUri + "/?" + 
                "scope=" + "" + "&" +
                "client_id=" + ClientId + "&" +
                "redirect_uri=" + RedirectUri + "&" +
                "response_type=" + Enum.GetName(typeof(OAuthResponseType), ResponseType).ToLower();
                ; 
        }


    }
}

