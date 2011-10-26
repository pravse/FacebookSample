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
                "show_error=" + ((false == ShowError) ? "false" : "true");
        }

        public enum OAuthResponseType {
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

