<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.ViewData["FBRoot"] %>

    <script type="text/javascript">

        // page=specific callback invoked from FB.init delegate
        function PostFBAuth(event, params) {
            if (params.isAuthenticated) {
                $('#AlreadyRegistered')[0].style.display = "";
                $('#RegistrationOptions')[0].style.display = "none";
                $('#AlreadyRegisteredMessage')[0].innerHTML = 'Welcome ' + params.userName + '!. You are already registered already.';
            }
            else {
                $('#AlreadyRegistered')[0].style.display = "none";
                $('#RegistrationOptions')[0].style.display = "";
            }
        };

        // page=specific callback invoked from JQuery document.ready delegate
        function PageInit(event) {
            $('#AlreadyRegistered')[0].style.display = "none";
            $('#RegistrationOptions')[0].style.display = "";
        };

    </script>

    <table id="AlreadyRegistered" style="display:none">
        <tr>
            <td id="AlreadyRegisteredMessage">
            Welcome. Here is the signed request received for your registration ... <%: this.ViewData["SignedRequest"] %>
            </td>
        </tr>
    </table>

    <table id="RegistrationOptions" style="display:block">
        <tr>
            <td>
            Instead of creating a user account for this app, you simply register this app with your facebook account. This allows the app to avoid user account management, and also allows the user to avoid keeping track of yet another definition of identity.

            If you have come to this page, it means you have not registered this app yet. So go ahead and register for this app via Facebook (using either of the controls below)
            </td>
        </tr>
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
