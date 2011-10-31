﻿(function (d) {
   var js, id = 'facebook-jssdk';  
   if (d.getElementById(id)) { return; } 
   js = d.createElement('script'); js.id = id; js.async = true; 
   js.src = "//connect.facebook.net/en_US/all.js"; 
   d.getElementsByTagName('head')[0].appendChild(js); 
  } (document));

var FBIsAuthenticated = false;
var FBUserId = "";
var FBUserName = "";
var FBAccessToken = "";

function AuthStatusDelegate(response) {
        if (response.authResponse) {
            FBIsAuthenticated = true;
            FBUserId = response.authResponse.userID;
            FBAccessToken = response.authResponse.accessToken;
            alert("Got to this point");
            FB.api('/me?access_token='+FBAccessToken, function (response) {
                FBUserName = response.Name;
                alert("Got the user name : " + FBUserName);
            });

            $("a").each(function () {
                if (null != this.href.match("ACCESS_TOKEN_STUB")) {
                    this.href = this.href.replace("ACCESS_TOKEN_STUB", FBAccessToken);
                }
            });
        }
        else {
            FBIsAuthenticated = false;
            FBUserId = "";
            FBAccessToken = "";
        }
        // poor man's eventing model ---- change to use JQuery custom events
        if (typeof PostFBAuth == 'function') { PostFBAuth(); }
    };


// this function will be invoked right after the asynchronous initialization of the FB object
function PostFBInit() {
    FB.getLoginStatus(AuthStatusDelegate);

    //subscribe for any further status changes
    FB.Event.subscribe('auth.authResponseChange', AuthStatusDelegate);
};

