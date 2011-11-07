using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;

namespace FacebookIntegration
{
    public partial class CodeGenerator
    {
        public string Comments(
            CodeStyle   Style,
            string      HRef, 
            int         NumComments=10,
            int         PluginWidth=300)
        {
            string returnHTML = "<div> </div>";
            Debug.Assert(null != HRef);
            if (CodeStyle.HTML5 == Style)
            {
                returnHTML = "<div class=\"fb-comments\" " +
                                            "data-width=\"" + PluginWidth + "\" " +
                                            "data-num-posts=\"" + NumComments + "\" " +
                                            "data-href=\"" + HRef + "\"" + 
                                            "\"></div>";
            }
            else if (CodeStyle.IFRAME == Style)
            {
                Debug.Assert(false, "IFRAME not supported for Comments box");
            }
            return returnHTML;
        }
    }
}
