﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FacebookIntegration
{
    public enum FBUserOrFriends
    {
        USER,
        FRIENDS
    }
    public enum FBUserAndFriendPermissions {
        ABOUT_ME,
        ACTIVITIES,
        BIRTHDAY,
        CHECKINS,
        EDUCATION_HISTORY,
        EVENTS,
        GROUPS,
        HOMETOWN,
        INTERESTS,
        LIKES,
        LOCATION,
        NOTES,
        ONLINE_PRESENCE,
        PHOTOS,
        RELATIONSHIPS,
        RELATIONSHIP_DETAILS,
        RELIGION_POLITICS,
        STATUS,
        VIDEOS,
        WEBSITE,
        WORK_HISTORY,
        EMAIL   // note : email is not a valid Friends permission
    }
    
    public enum FBExtendedPermissions {
        READ_FRIENDLISTS,
        READ_INSIGHTS,
        READ_MAILBOX,
        READ_REQUESTS,
        READ_STREAM,
        XMPP_LOGIN,
        ADS_MANAGEMENT,
        CREATE_EVENT,
        MANAGE_FRIENDLISTS,
        MANAGE_NOTIFICATIONS,
        OFFLINE_ACCESS,
        PUBLISH_CHECKINS,
        PUBLISH_STREAM,
        RSVP_EVENT,
        SMS,
        PUBLISH_ACTIONS
    }

    public class FBPermissions
    {
        public FBPermissions()
        {
            userPermissions = new List<FBUserAndFriendPermissions>();
            friendsPermissions = new List<FBUserAndFriendPermissions>();
            extendedPermissions = new List<FBExtendedPermissions>();
        }

        public void AddUserPermission(FBUserAndFriendPermissions Perm)
        {
            userPermissions.Add(Perm);
        }

        public void AddFriendsPermission(FBUserAndFriendPermissions Perm)
        {
            Debug.Assert(FBUserAndFriendPermissions.EMAIL != Perm);
            friendsPermissions.Add(Perm);
        }

        public void AddExtendedPermission(FBExtendedPermissions Perm)
        {
            extendedPermissions.Add(Perm);
        }

        #region private
        private IList<FBUserAndFriendPermissions> userPermissions;
        private IList<FBUserAndFriendPermissions> friendsPermissions;
        private IList<FBExtendedPermissions> extendedPermissions;

        private string PermissionPrefix(FBUserOrFriends ForWhom)
        {
            return ((FBUserOrFriends.USER == ForWhom) ? "user_" : "friends_");
        }

        private string GetPermissionString(FBUserOrFriends ForWhom, FBUserAndFriendPermissions Perm)
        {
            return PermissionPrefix(ForWhom) + System.Enum.GetName(typeof(FBUserAndFriendPermissions), Perm).ToLower();
        }

        private string GetPermissionString(FBExtendedPermissions Perm)
        {
            return System.Enum.GetName(typeof(FBExtendedPermissions), Perm).ToLower();
        }

        #endregion

        // returns a comma-separated list
        public string GetPermissionList()
        {
            string returnList = "";
            int permCount = 0;

            foreach (FBUserAndFriendPermissions Perm in userPermissions)
            {
                if (permCount > 0) { returnList += ","; }
                returnList += GetPermissionString(FBUserOrFriends.USER, Perm);
                permCount++;
            }

            foreach (FBUserAndFriendPermissions Perm in friendsPermissions)
            {
                if (permCount > 0) { returnList += ","; }
                returnList += GetPermissionString(FBUserOrFriends.FRIENDS, Perm);
                permCount++;
            }

            foreach (FBExtendedPermissions Perm in extendedPermissions)
            {
                if (permCount > 0) { returnList += ","; }
                returnList += GetPermissionString(Perm);
                permCount++;
            }

            return returnList;
        }
    }
}
