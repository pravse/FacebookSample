(function (d) {
   var js, id = 'facebook-jssdk';  
   if (d.getElementById(id)) { return; } 
   js = d.createElement('script'); js.id = id; js.async = true; 
   js.src = "//connect.facebook.net/en_US/all.js"; 
   d.getElementsByTagName('head')[0].appendChild(js); 
  } (document));

        private string generateFBInit(bool WithAppId)
        {
            Debug.Assert(null != options);
            return " window.fbAsyncInit = function() { \n" +
                        " FB.init({ \n" +
                        options.GetInitParameters(WithAppId) +
                        "}); \n" +
                        " PostFBInit(); \n" + 
                        " }; \n";
