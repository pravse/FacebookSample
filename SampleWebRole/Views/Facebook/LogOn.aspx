<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="OpenGraphTagsContent" ContentPlaceHolderID="OpenGraphTags" runat="server">
    <%=this.ViewData["OpenGraphTags"]%>
</asp:Content>

<asp:Content ID="JQueryInclude" ContentPlaceHolderID="JQuery" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript">

        function PostFBAuth(event, params) {
                if (FBIsAuthenticated) {
                    $('#LoggedIn')[0].style.display = "";
                    $('#NotLoggedIn')[0].style.display = "none";
                    $('#LoggedIn')[0].innerHTML = 'Welcome ' + params.userName + '!. You are already logged into Facebook already.';
                }
                else {
                    $('#LoggedIn')[0].style.display = "none";
                    $('#NotLoggedIn')[0].style.display = "";
                }
            };


            $(function () {
                $('#LoggedIn')[0].style.display = "none";
                $('#NotLoggedIn')[0].style.display = "";
                $("#fb-root").bind("authsuccess authfailure", PostFBAuth);
            });

    </script>
</asp:Content>


<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.ViewData["FBRoot"] %>
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
