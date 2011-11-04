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
        }

        public void AddFriendResponse(string responseAction)
        {
            sharedFBModel.AddFriendResponseValid = true;
            sharedFBModel.AddFriendResponse = responseAction;

            sharedFBModel.HasCurrentResponse = true;
        }

        public SocialModel Model { get { return sharedFBModel; } }

        public FBPermissions Permissions { get { return permissions; } }

        public void ResetAllResponses() { sharedFBModel.ResetAllResponses(); }
    }
    #endregion

}
