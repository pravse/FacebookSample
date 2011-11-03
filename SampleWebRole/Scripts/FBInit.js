(function (d) {
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

            // alert("Got to this point");
            FB.api('/me', function (response) {
                var eventName = "authConnected";
                $("#fb-root").trigger(eventName,  { userId: FBUserId,
                                                    userName: response.name,
                                                    accessToken: FBAccessToken,
                                                    authStatus: FBStatus });
            });
        }
        else {
            FBUserId = "";
            FBAccessToken = "";
            var eventName;
            if (response.status == 'notConnected') {
                eventName = "authNotConnected";
            }
            else {
                eventName = "authUnknown";
            }
            $("#fb-root").trigger(eventName, {  userId: FBUserId,
                                                userName: "",
                                                accessToken: FBAccessToken,
                                                authStatus: FBStatus });
        }
    };


// this function will be invoked right after the asynchronous initialization of the FB object
function PostFBInit() {
    // alert("Got to PostFBInit");
    FB.getLoginStatus(AuthStatusDelegate);

    //subscribe for any further status changes
    FB.Event.subscribe('auth.authResponseChange', AuthStatusDelegate);
};

