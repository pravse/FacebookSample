﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="OpenGraphTagsContent" ContentPlaceHolderID="OpenGraphTags" runat="server">
    <%=this.ViewData["OpenGraphTags"]%>
</asp:Content>

<asp:Content ID="JQueryInclude" ContentPlaceHolderID="JQuery" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript">

        function PostFBInit() {
            FB.getLoginStatus(function (response) {
                if (response.authResponse) {
                    $('#LoggedIn')[0].style.display = "";
                    $('#NotLoggedIn')[0].style.display = "none";
                }
                else {
                    $('#LoggedIn')[0].style.display = "none";
                    $('#NotLoggedIn')[0].style.display = "";
                }
                $('#Junk')[0].style.display = "none";
            });
        }

        $(function () {
            $('#LoggedIn')[0].style.display = "none";
        });

    </script>
</asp:Content>


<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.ViewData["FBRoot"] %>
    <h2>Log On and Registration</h2>

    <div id="Junk" style="display:block">
        Junk content. Should not show
    </div>


    <div id="LoggedIn"  style="display:block">
        Welcome fair user!
    </div>

    <div id="NotLoggedIn"  style="display:block">
        <p> Simplest way to do this is via the FB Register+Login button</p>
        <%= this.ViewData["FBRegisterOrLoginHtml5"] %>



        <p>Or if you already have registered this app, just log in now via Facebook</p>
        <%= this.ViewData["FBLoginIFrame"] %>
        
    </div>



    <p>
    To understand how Facebook registration and login works, follow <a href="http://developers.facebook.com/docs/user_registration/flows/">this</a> link. 
    </p>

</asp:Content>
