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
        private string fbRegistrationUri = "https://www.facebook.com/plugins/registration.php";
        private string fbRedirectUri = "https%3A%2F%2Fdevelopers.facebook.com%2Ftools%2Fecho%2F";

        private string getClientId()
        {
            return "client_id=" + this.FBAppId;
        }

        private string getSrcString(string url)
        {
            return "src=\"" + url + "\"";
        }

        private string getRedirectUri(string redirectUri)
        {
            return "redirect_uri=" + ((null == redirectUri) ? fbRedirectUri : redirectUri);
        }

        private string getFields()
        {
            return "name,birthday,gender,location,email";
        }

        private string getRegistrationOptions()
        {
            return "scrolling=\"auto\" frameborder=\"no\" style=\"border:none\" allowTransparency=\"true\" width=\"300\" height=\"330\"";
        }

        #endregion

        public string GenerateRegister(
            CodeStyle Style,
            string redirectUri)
        {
            Debug.Assert(null != redirectUri);

            string returnHTML = "<div> </div>";
            if (CodeStyle.HTML5 == Style)
            {
                // note ---- this only exists in XFBML right now. Cheat for now and return XFBML until FB fixes this
                returnHTML = "<fb:registration " +
                                            "redirect-uri=\"" + redirectUri + "\" " +
                                            "fields=\"" + getFields() + "\" " +
                                            "/>";
            }
            else if (CodeStyle.IFRAME == Style)
            {
                returnHTML = "<iframe " + getSrcString(fbRegistrationUri + "?" +
                                                            getClientId() + "&amp;" +
                                                            getRedirectUri(redirectUri) + "&amp;" +
                                                            "fields=" + getFields())
                                             + getRegistrationOptions() + "> </iframe>";
            }
            return returnHTML;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Style"></param>
        /// <param name="Permissions"></param>
        /// <param name="ShowFaces"></param>
        /// <param name="DataWidth"></param>
        /// <param name="MaxDataRows"></param>
        /// <returns></returns>
        public string GenerateLogin(
            CodeStyle       Style,
            FBPermissions   Permissions = null, 
            bool            ShowFaces=false, 
            int             DataWidth=200, 
            int             MaxDataRows=1)
        {
            string returnHTML = "<div> </div>";
            if (CodeStyle.HTML5 == Style)
            {
                returnHTML = "<div class=\"fb-login-button\" " +
                                            "data-show-faces=\"" + ((true == ShowFaces) ? "true" : "false") + "\" " +
                                            "data-width=\"" + DataWidth + "\" " +
                                            "data-max-rows=\"" + MaxDataRows + "\" " +
                                            ((null != Permissions) ? ("data-perms=\"" + Permissions.GetPermissionList() + "\"") : "") +
                                            "></div>";
            }
            else
            {
                Debug.Assert(false, "Only HTML5 supported for login button");
            }
            return returnHTML;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Style"></param>
        /// <param name="RegisterCallbackUri"></param>
        /// <returns></returns>
        public string GenerateRegisterOrLogin(
            CodeStyle       Style,
            string          RegisterCallbackUri,
            FBPermissions   Permissions = null)
        {
            string returnHTML = "<div> </div>";
            Debug.Assert(null != RegisterCallbackUri);
            if (CodeStyle.HTML5 == Style)
            {
                // note ---- this only exists in XFBML right now. Cheat for now and return XFBML until FB fixes this
                returnHTML = "<div><fb:login-button " +
                                            "registration-url=\"" + RegisterCallbackUri + "\" " +
                                            ((null != Permissions) ? ("perms=\"" + Permissions.GetPermissionList() + "\"") : "") +
                                            "/></div>";
            }
            else
            {
                Debug.Assert(false, "Only HTML5 supported for register/login button");
            }
            return returnHTML;
        }

    
    }
}
