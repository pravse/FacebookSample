<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Register</h2>
    <script type="text/javascript">
        if (null == <%: this.ViewData["SignedRequest"] %>) { this.AlreadyRegistered.disabled = true; this.RegistrationOptions.disabled = false; }
        else { this.AlreadyRegistered.disabled = false; this.RegistrationOptions.disabled = true; }
    </script>
    <p>
    Instead of creating a user account for this app, you simply register this app with your facebook account. This allows the app to avoid user account management, and also allows the user to avoid keeping track of yet another definition of identity.

    If you have come to this page, it means you have not registered this app yet. So go ahead and register for this app via Facebook (using either of the controls below)
    </p>

    <table id="AlreadyRegistered">
        <tr>
            <td>
            Welcome. Here is the signed request received for your registration ... <%: this.ViewData["SignedRequest"] %>
            </td>
        </tr>
    </table>

    <table id="RegistrationOptions">
        <tr>
            <td>
            In an IFrame ....    
             <%= this.ViewData["FBRegistrationIFrame"] %>
            </td>
            <td>
            Or via a HTML5 control ....     
            <%= this.ViewData["FBRegistrationHtml5"] %>
            </td>
        </tr>
    </table>

</asp:Content>
