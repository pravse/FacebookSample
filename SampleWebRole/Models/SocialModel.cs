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
        public bool HasCurrentResponse = false;

        public string AddFriendResponse = ""; 
        public bool   AddFriendResponseValid = false;

        public void ResetAllResponses()
        {
            HasCurrentResponse = false;
            AddFriendResponseValid = false;
        }
    }

    #endregion

    #region Services

    public interface ISocialService
    {
        void ResetAllResponses();
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

            FBModel.HasCurrentResponse = true;
        }

        public SocialModel Model { get { return FBModel; } }

        public void ResetAllResponses() { FBModel.ResetAllResponses(); }
    }
    #endregion

}
