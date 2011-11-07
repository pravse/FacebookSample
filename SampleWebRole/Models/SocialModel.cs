using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FacebookIntegration;

namespace SampleWebRole.Models
{

    #region Models
    public class SocialModel
    {
        public bool HasCurrentResponse = false;

        public string AddFriendResponse = ""; 
        public bool   AddFriendResponseValid = false;
        public string SendMessageResponse = "";
        public bool SendMessageResponseValid = false;
        public string PostToFeedResponse = "";
        public bool PostToFeedResponseValid = false;

        public bool ResetAllResponses()
        {
            HasCurrentResponse = false;

            AddFriendResponseValid = false;
            PostToFeedResponseValid = false;
            SendMessageResponseValid = false;

            return HasCurrentResponse;
        }
    }

    #endregion

    #region Services

    public interface ISocialService
    {
        bool ResetAllResponses();
        void AddFriendResponse(string responseAction);
        void PostToFeedResponse(string postId);
        void SendMessageResponse(string responseAction);
        SocialModel Model { get; }
        FBPermissions Permissions { get; }
    }

    public class FacebookService : ISocialService
    {
        private SocialModel   sharedFBModel;
        private FBPermissions permissions;

        public FacebookService()
        {
            sharedFBModel = new SocialModel();
            permissions = new FBPermissions();

            // a set of permissions for use by the app
            permissions.AddUserPermission(FBUserAndFriendPermissions.ABOUT_ME);
            permissions.AddUserPermission(FBUserAndFriendPermissions.BIRTHDAY);
            permissions.AddUserPermission(FBUserAndFriendPermissions.EMAIL);
            permissions.AddFriendsPermission(FBUserAndFriendPermissions.ABOUT_ME);
            permissions.AddExtendedPermission(FBExtendedPermissions.READ_MAILBOX);
            permissions.AddExtendedPermission(FBExtendedPermissions.OFFLINE_ACCESS);
            permissions.AddExtendedPermission(FBExtendedPermissions.READ_STREAM);
        }

        public void AddFriendResponse(string responseAction)
        {
            sharedFBModel.AddFriendResponseValid = true;
            sharedFBModel.AddFriendResponse = responseAction;

            sharedFBModel.HasCurrentResponse = true;
        }

        public void PostToFeedResponse(string postId)
        {
            sharedFBModel.PostToFeedResponseValid = true;
            sharedFBModel.PostToFeedResponse = postId;

            sharedFBModel.HasCurrentResponse = true;
        }

        public void SendMessageResponse(string responseAction)
        {
            sharedFBModel.SendMessageResponseValid = true;
            sharedFBModel.SendMessageResponse = responseAction;

            sharedFBModel.HasCurrentResponse = true;
        }

        public SocialModel Model { get { return sharedFBModel; } }

        public FBPermissions Permissions { get { return permissions; } }

        public bool ResetAllResponses() { return sharedFBModel.ResetAllResponses(); }
    }
    #endregion

}
