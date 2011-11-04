<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= ViewData["FBRoot"] %>
    <script type="text/javascript">

        // callback invoked from FB.init delegate
        function PostFBAuth(event, params) {
            if ("connected" == params.authStatus) {
                $('#AuthConnected')[0].style.display = "";
                $('#AuthConnected')[0].innerHTML = "You (userID = " + params.userId + ") are logged in with access token " + params.accessToken;
                $('#AuthNotConnected')[0].style.display = "none";
                $('#AuthUnknown')[0].style.display = "none";
                /***
                $('#AuthConnected')[0].show();
                $('#AuthNotConnected')[0].hide();
                $('#AuthUnknown')[0].hide();
                ***/
            }
            else if ("not_authorized" == params.authStatus) {
                $('#AuthConnected')[0].style.display = "none";
                $('#AuthNotConnected')[0].style.display = "";
                $('#AuthUnknown')[0].style.display = "none";
            }
            else {
                $('#AuthConnected')[0].style.display = "none";
                $('#AuthNotConnected')[0].style.display = "none";
                $('#AuthUnknown')[0].style.display = "";
            }
        };

        // callback invoked from JQuery document.ready delegate
        function PageInit(event) {
            $('#LoggedIn')[0].style.display = "none";
            $('#NotLoggedIn')[0].style.display = "";
        };
        $("#header").bind("docready", PageInit);

    </script>

    <div id="AuthConnected"  style="display:block">
        You are logged into Facebook already.
    </div>

    <div id="AuthNotConnected"  style="display:block">
        <p> You are logged into Facebook, but have not authorized this app. Please do so now. </p>
        <%= this.ViewData["FBLoginHtml5"] %>
    </div>

    <div id="AuthUnknown"  style="display:block">
        <p> You are not logged into Facebook. Please do so now. If you have not authorized this app, you will also be asked to do so. </p>
        <%= this.ViewData["FBLoginHtml5"] %>        
    </div>

    <div id="Registration"  style="display:none">
        <p> User this only if the app needs an explicit registration system where it needs to ask the user for information that isn't in FB, or it needs to enable users to create new FB accounts</p>
        <%= this.ViewData["FBRegisterOrLoginHtml5"] %>        
    </div>


    <p>
    To understand how Facebook registration and login works, follow <a href="http://developers.facebook.com/docs/user_registration/flows/">this</a> link. 
    </p>

</asp:Content>
