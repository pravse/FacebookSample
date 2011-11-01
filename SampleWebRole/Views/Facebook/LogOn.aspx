<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="OpenGraphTagsContent" ContentPlaceHolderID="OpenGraphTags" runat="server">
    <%=this.ViewData["OpenGraphTags"]%>
</asp:Content>


<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.ViewData["FBRoot"] %>
    <script type="text/javascript">

        // callback invoked from FB.init delegate
        function PostFBAuth(event, params) {
            if (params.isAuthenticated) {
                $('#LoggedIn')[0].style.display = "";
                $('#NotLoggedIn')[0].style.display = "none";
                $('#LoggedIn')[0].innerHTML = 'Welcome ' + params.userName + '!. You are already logged into Facebook already.';
            }
            else {
                $('#LoggedIn')[0].style.display = "none";
                $('#NotLoggedIn')[0].style.display = "";
            }
        };

        // callback invoked from JQuery document.ready delegate
        function PageInit(event) {
            $('#LoggedIn')[0].style.display = "none";
            $('#NotLoggedIn')[0].style.display = "";
        };


    </script>

    <h2>Log On and Registration</h2>

    <div id="LoggedIn"  style="display:block">
        You are logged into Facebook already.
    </div>

    <div id="NotLoggedIn"  style="display:block">
        <p> Simplest way to do this is via the FB Register+Login button</p>
        <%= this.ViewData["FBRegisterOrLoginHtml5"] %>



        <p> Or if you already have registered this app, just log in now via Facebook</p>
        <%= this.ViewData["FBLoginHtml5"] %>
        
    </div>



    <p>
    To understand how Facebook registration and login works, follow <a href="http://developers.facebook.com/docs/user_registration/flows/">this</a> link. 
    </p>

</asp:Content>
