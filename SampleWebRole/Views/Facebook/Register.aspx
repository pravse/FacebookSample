<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="registerTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>

<asp:Content ID="JQueryInclude" ContentPlaceHolderID="JQuery" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript">

        function PostFBAuth() {
        };

        $(function () {
            // any jquery stuff you want to add
        });
    </script>
</asp:Content>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.ViewData["FBRoot"] %>
    <h2>Register</h2>

    <script type="text/javascript">
        if (null == <%: this.ViewData["SignedRequest"] %>) { 
            this.AlreadyRegistered.style.display = "none"; 
            this.RegistrationOptions.style.display = ""; 
            }
        else { 
            this.AlreadyRegistered.style.display = ""; 
            this.RegistrationOptions.style.display = "none"; 
            }
    </script>

    <p>
    Instead of creating a user account for this app, you simply register this app with your facebook account. This allows the app to avoid user account management, and also allows the user to avoid keeping track of yet another definition of identity.

    If you have come to this page, it means you have not registered this app yet. So go ahead and register for this app via Facebook (using either of the controls below)
    </p>

    <table id="AlreadyRegistered" style="display:none">
        <tr>
            <td>
            Welcome. Here is the signed request received for your registration ... <%: this.ViewData["SignedRequest"] %>
            </td>
        </tr>
    </table>

    <table id="RegistrationOptions" style="display:block">
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
