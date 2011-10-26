<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="OpenGraphTagsContent" ContentPlaceHolderID="OpenGraphTags" runat="server">
    <%=this.ViewData["OpenGraphTags"]%>
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.ViewData["FBRoot"] %>
    <h2>Log On and Registration</h2>

    <p> Simplest way to do this is via the FB Register+Login button</p>
        <%= this.ViewData["FBRegisterOrLoginHtml5"] %>



    <p>
        Or if you already have registered this app, just log in now via Facebook
        <%= this.ViewData["FBLoginIFrame"] %>
    </p>


    <p>
    To understand how Facebook registration and login works, follow <a href="http://developers.facebook.com/docs/user_registration/flows/">this</a> link. The content is also included in the iframe below.
    </p>

    <iframe src="http://developers.facebook.com/docs/user_registration/flows" />

</asp:Content>
