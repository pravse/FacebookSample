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
            $("a").each(function () {
                if (null != this.href.match("ACCESS_TOKEN_STUB")) {
                    this.href = this.href.replace("ACCESS_TOKEN_STUB", FBAccessToken);
                }
            });

            alert("Got to this point");
            FB.api('/me', function (response) {
                alert("Got the user : " + response.name);
                FBUserName = response.name;
                $("#fb-root").trigger("authsuccess", { userId: FBUserId, userName: FBUserName, accessToken: FBAccessToken } );
            });
        }
        else {
            FBIsAuthenticated = false;
            FBUserId = "";
            FBAccessToken = "";
            $("#fb-root").trigger("authfailure");
        }
    };


// this function will be invoked right after the asynchronous initialization of the FB object
function PostFBInit() {
    FB.getLoginStatus(AuthStatusDelegate);

    //subscribe for any further status changes
    FB.Event.subscribe('auth.authResponseChange', AuthStatusDelegate);
};

