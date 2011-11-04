<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= ViewData["FBRoot"] %>
    <script type="text/javascript">

        // callback invoked from FB.init delegate
        function PostFBAuth(event, params) {
            var expectedPerms = '<%=this.ViewData["ExpectedPermissionsJSON"]%>';
            var adequatePermsGranted = false;
            if ("connected" == params.authStatus) { fullPermsGranted = AdequatePerms(params.authPerms, expectedPerms); }

            if (adequatePermsGranted) {
                $('#AuthConnected')[0].style.display = "";
                $('#AuthNotConnected')[0].style.display = "none";
                $('#AuthInadequatePerms')[0].style.display = "none";
                $('#AuthUnknown')[0].style.display = "none";
                $('#AuthConnected')[0].innerHTML = "You are logged in with access token " + params.accessToken;
            }
            else if ("connected" == params.authStatus) {
                $('#AuthConnected')[0].style.display = "none";
                $('#AuthNotConnected')[0].style.display = "none";
                $('#AuthInadequatePerms')[0].style.display = "";
                $('#AuthUnknown')[0].style.display = "none";
            }
            else if ("not_authorized" == params.authStatus) {
                $('#AuthConnected')[0].style.display = "none";
                $('#AuthNotConnected')[0].style.display = "";
                $('#AuthInadequatePerms')[0].style.display = "none";
                $('#AuthUnknown')[0].style.display = "none";
            }
            else {
                $('#AuthConnected')[0].style.display = "none";
                $('#AuthNotConnected')[0].style.display = "none";
                $('#AuthInadequatePerms')[0].style.display = "none";
                $('#AuthUnknown')[0].style.display = "";
            }
        };

        function FBOAuthDialog() {
            var expectedPerms = '<%=this.ViewData["ExpectedPermissionsCSV"]%>';
            // no need for a callback handler for FB.login because in any case, an authResponseChange event will be raised and there are already handlers for it
            FB.login(function (response) { }, { scope: expectedPerms });
        };

        // callback invoked from JQuery document.ready delegate
        function PageInit(event) {
            $('#AuthConnected')[0].style.display = "none";
            $('#AuthNotConnected')[0].style.display = "none";
            $('#AuthUnknown')[0].style.display = "";
        };
        $("#header").bind("docready", PageInit);

    </script>

    <div id="AuthConnected"  style="display:none">
        You are logged into Facebook already.
    </div>

    <div id="AuthNotConnected"  style="display:none">
        <p> You are logged into Facebook, but have not authorized this app. Please do so now. </p>
        <%= this.ViewData["FBLoginHtml5"] %>
    </div>

    <div id="AuthInadequatePerms"  style="display:none">
        <p> You are logged into Facebook and authorized this app, but without adequate permissions. Please do so now. </p>
        <button type="button" onclick="FBOAuthDialog()">Provide Permissions</button>
        <%= this.ViewData["FBLoginHtml5"] %>
    </div>

    <div id="AuthUnknown"  style="display:none">
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
