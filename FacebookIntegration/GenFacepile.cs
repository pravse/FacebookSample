using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;

namespace FacebookIntegration
{
    public partial class CodeGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Style"></param>
        /// <param name="HRef"></param>
        /// <param name="PluginWidth"></param>
        /// <returns></returns>
        public string GenerateLikeFacepile(
            CodeStyle Style,
            string HRef,
            int PluginWidth = 200)
        {
            string returnHTML = "<div> </div>";
            if (CodeStyle.HTML5 == Style)
            {
                returnHTML = "<div class=\"fb-facepile\" " +
                                            "data-width=\"" + PluginWidth + "\" " +
                                            ((null != HRef) ? ("data-href=\"" + HRef + "\"") : "") +
                                            "></div>";
            }
            else if (CodeStyle.IFRAME == Style)
            {
                returnHTML = "<iframe src=\"http://www.facebook.com/plugins/facepile.php?href=" + HRef + "&amp;" +
                                "width=" + PluginWidth + "\"" +
                                "scrolling=\"no\" frameborder=\"0\"" +
                                "style=\"border:none; width:" + PluginWidth + "px; height:80px\"></iframe>";

            }
            return returnHTML;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Style"></param>
        /// <param name="PluginWidth"></param>
        /// <returns></returns>
        public string GenerateAppFacepile(
            CodeStyle Style,
            int PluginWidth = 200)
        {
            string returnHTML = "<div> </div>";
            if (CodeStyle.HTML5 == Style)
            {
                //pass in the app id when calling FB.init
                returnHTML = "<div class=\"fb-facepile\" " +
                                            "data-width=\"" + PluginWidth + "\" " +
                                            "></div>";
            }
            else if (CodeStyle.IFRAME == Style)
            {
                returnHTML = "<iframe src=\"http://www.facebook.com/plugins/facepile.php?app_id=" + this.FBAppId + "&amp;" +
                                "width=" + PluginWidth + "\"" +
                                "scrolling=\"no\" frameborder=\"0\"" +
                                "style=\"border:none; width:" + PluginWidth + "px; height:80px\"></iframe>";

            }
            return returnHTML;
        }

    }
}

