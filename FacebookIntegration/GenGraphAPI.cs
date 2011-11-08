using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;

namespace FacebookIntegration
{
    public partial class CodeGenerator
    {
        public string MyPictureUri()
        {
            return "http://graph.facebook.com/me/picture";
        }

        public string FQLMyFriends()
        {
            return "SELECT uid2 FROM friend WHERE uid=me()";
        }
    }
}

