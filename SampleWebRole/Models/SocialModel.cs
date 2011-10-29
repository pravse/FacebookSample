using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SampleWebRole.Models
{

    #region Models
    public class SocialModel
    {
        public string AddFriendResponse = null; 
        public bool   AddFriendResponseValid = false;

    }

    #endregion

    #region Services

    public interface ISocialService
    {
        void AddFriendResponse(string responseAction);
        SocialModel Model { get;}
    }

    public class FacebookService : ISocialService
    {
        public SocialModel FBModel = new SocialModel();
        public void AddFriendResponse(string responseAction)
        {
            FBModel.AddFriendResponseValid = true;
            FBModel.AddFriendResponse = responseAction;
        }
        public SocialModel Model { get { return FBModel; } }
    }
    #endregion

}
