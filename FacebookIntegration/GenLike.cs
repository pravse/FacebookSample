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
        /// Creates a Like (and Send) button ---- most common control
        /// </summary>
        /// <param name="Style"></param>
        /// <param name="Ref"></param>
        /// <param name="HRef"></param>
        /// <param name="AddSendButton"></param>
        /// <param name="ShowFaces"></param>
        /// <param name="PluginWidth"></param>
        /// <returns></returns>
        public string Like(
            CodeStyle   Style,
            string      Ref,    // always pass a unique Ref for all FB plugins --- any clickbacks have this passed as a fb_ref parameter
            string      HRef, 
            bool        AddSendButton = false,
            bool        ShowFaces=true, 
            int         PluginWidth=200)
        {
            string returnHTML = "<div> </div>";
            if (CodeStyle.HTML5 == Style)
            {
                returnHTML = "<div class=\"fb-like\" " +
                                            "data-show-faces=\"" + ((true == ShowFaces) ? "true" : "false") + "\" " +
                                            "data-send=\"" + ((true == AddSendButton) ? "true" : "false") + "\" " +
                                            "data-width=\"" + PluginWidth + "\" " +
                                            ((null != HRef)? ("data-href=\"" + HRef + "\"") : "") + 
                                            ((null != Ref)? ("data-ref=\"" + Ref + "\"") : "") + 
                                            "></div>";
            }
            else if (CodeStyle.IFRAME == Style)
            {
                // TODO: for now, require HRef and ignore Ref for the IFrame implementation....
                Debug.Assert(null != HRef);
                Debug.Assert((false == AddSendButton), "Send button not supported with IFRAME");

                returnHTML = "<iframe src=\"http://www.facebook.com/plugins/like.php?href=" + HRef + "\"" +
                                "scrolling=\"no\" frameborder=\"0\"" +
                                "style=\"border:none; width:" + PluginWidth + "px; height:80px\"></iframe>";
            }
            return returnHTML;
        }


        /// <summary>
        /// Generates a control to allow the user to like a specific Facebook page (without having to go there).
        /// This works for Facebook "pages" only (i.e. owned by commercial businesses) not consumer facebook pages
        /// </summary>
        /// <param name="Style"></param>
        /// <param name="HRef"></param>
        /// <param name="ShowFaces"></param>
        /// <param name="ShowStream"></param>
        /// <param name="ShowHeader"></param>
        /// <param name="PluginWidth"></param>
        /// <returns></returns>
        public string LikeBox(
            CodeStyle Style,
            string HRef,
            bool ShowFaces = true,
            bool ShowStream = true,
            bool ShowHeader = false,
            int PluginWidth = 300)
        {
            string returnHTML = "<div> </div>";
            if (CodeStyle.HTML5 == Style)
            {
                returnHTML = "<div class=\"fb-like-box\" " +
                                            "data-show-faces=\"" + ((true == ShowFaces) ? "true" : "false") + "\" " +
                                            "data-stream=\"" + ((true == ShowStream) ? "true" : "false") + "\" " +
                                            "data-header=\"" + ((true == ShowHeader) ? "true" : "false") + "\" " +
                                            "data-width=\"" + PluginWidth + "\" " +
                                            ((null != HRef) ? ("data-href=\"" + HRef + "\"") : "") +
                                            "></div>";
            }
            else if (CodeStyle.IFRAME == Style)
            {
                Debug.Assert(false, "IFRAME is supported for LikeBox, but not yet implemented here");
            }
            return returnHTML;
        }
    
    }
}

