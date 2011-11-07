using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;

namespace FacebookIntegration
{
    public partial class CodeGenerator
    {
        public string ActivityFeed(
            CodeStyle   Style,                                 
            string      Ref,    // always pass a unique Ref for all FB plugins --- any clickbacks have this passed as a fb_ref parameter
            string      Sites,  // comma-separated list of domains to show activity for
            bool        ShowHeader = false, 
            bool        ShowRecos = true,
            int         PluginWidth = 300,
            int         PluginHeight = 300)
        {
            string returnHTML = "<div> </div>";
            Debug.Assert(null != Sites);
            Debug.Assert(null != Ref);
            if (CodeStyle.HTML5 == Style)
            {
                returnHTML = "<div class=\"fb-activity\" " +
                                            "data-site=\"" + Sites + "\"" +
                                            "data-header=\"" + ((true == ShowHeader) ? "true" : "false") + "\" " +
                                            "data-recommendations=\"" + ((true == ShowRecos) ? "true" : "false") + "\" " +
                                            "data-width=\"" + PluginWidth + "\" " +
                                            "data-height=\"" + PluginHeight + "\" " +
                                            "data-ref=\"" + Ref + "\"" + 
                                            "\"></div>";
            }
            else if (CodeStyle.IFRAME == Style)
            {
                returnHTML = "<iframe src=\"http://www.facebook.com/plugins/activity.php?" +
                                 "site=" + Sites + "&amp;" +
                                 "width=" + PluginWidth + "&amp;" +
                                 "height=" + PluginHeight + "&amp;" +
                                 "header=" + ((true == ShowHeader)?"true":"false") + "&amp;" +
                                 "recommendations=" + ((true == ShowRecos)?"true":"false") + "\"" +
                                "scrolling=\"no\" frameborder=\"0\"" +
                                "style=\"border:none; width:" + PluginWidth + "px; height:" + PluginHeight + "px;\">" +
                                "</iframe>";
            }
            return returnHTML;
        }
    }
}


