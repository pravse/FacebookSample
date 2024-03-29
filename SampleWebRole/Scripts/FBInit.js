﻿(function (d) {
   var js, id = 'facebook-jssdk';  
   if (d.getElementById(id)) { return; } 
   js = d.createElement('script'); js.id = id; js.async = true; 
   js.src = "//connect.facebook.net/en_US/all.js"; 
   d.getElementsByTagName('head')[0].appendChild(js); 
  } (document));


function AuthStatusDelegate(response) {
    var FBUserId = "";
    var FBAccessToken = "";
    var FBStatus = response.status;

    if (response.authResponse) {
            FBUserId = response.authResponse.userID;
            FBAccessToken = response.authResponse.accessToken;
            $("a").each(function () {
                if (null != this.href.match("ACCESS_TOKEN_STUB")) {
                    this.href = this.href.replace("ACCESS_TOKEN_STUB", FBAccessToken);
                }
            });

            FB.api('/me', function (response1) {
                var FBUserName = response1.name
                // now check that the user actually provided the desired permissions
                FB.api('/me/permissions', function (response2) {
                    var EventName = "authConnected";

                    $("#fb-root").trigger(EventName, { userId: FBUserId,
                                                        userName: FBUserName,
                                                        accessToken: FBAccessToken,
                                                        authStatus: FBStatus,
                                                        authPerms: response2.data[0]
                                                      });
                });
            });
        }
        else {
            FBUserId = "";
            FBAccessToken = "";
            var EventName;
            if (response.status == 'not_authorized') {
                EventName = "authNotConnected";
            }
            else {
                EventName = "authUnknown";
            }
            $("#fb-root").trigger(EventName, {  userId: FBUserId,
                                                userName: "",
                                                accessToken: FBAccessToken,
                                                authStatus: FBStatus,
                                                authPerms : null });
        }
    };


// this function will be invoked right after the asynchronous initialization of the FB object
function PostFBInit() {
    // alert("Got to PostFBInit");
    FB.getLoginStatus(AuthStatusDelegate);

    //subscribe for any further status changes
    FB.Event.subscribe('auth.authResponseChange', AuthStatusDelegate);
};

function AdequatePerms(authPerms, expectedPerms) {
    var adequatePerms = true;
    for (prop in expectedPerms) {
        if (null == authPerms[prop]) {
            adequatePerms = false;
            // alert("Missing perm :" + prop);
            break;
        }
    }
    return adequatePerms;
};


