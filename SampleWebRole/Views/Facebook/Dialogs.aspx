<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SampleWebRole.Models.SocialModel>" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>
<asp:Content ID="NoJSTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Interacting via Dialogs
</asp:Content>

<asp:Content ID="NoJSContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.ViewData["FBRoot"] %>
    <script type="text/javascript">
        
        // page=specific callback invoked from JQuery document.ready delegate
        function PageInit(event) {
            if (true == <%= this.Model.AddFriendResponseValid.ToString().ToLower()%>) {
                alert("Received message from action: " + "<%= this.Model.AddFriendResponse%>");
            }
        };

        function DeleteAPost() {
            FB.api('/674675628_168537363238450', 'delete', function(response) {
                    alert("Got a response to the delete request: " + response);
                });
        };

    </script>

    <h2>Dialogs</h2>
    <p>
        The Facebook "dialog" controls do not require any authentication to have occurred. 
        However, they all do need a Facebook App Id that is specified as a parameter to each dialog. 
        Each dialog can be open (via href) as a whole page (hosted by Facebook) or can run inside an IFrame on this page.
        If using IFrames, there does need to be an authentication token --- i.e. you need to have logged in to Facebook and the user needs to have authenticated the app. 
        See the docs for more details on this. NOTE: so far, I have been unable to get the IFrame examples to work --- get error 191 saying that the redirect_uri is not approved for this app.
    </p>
    <table>
        <tr>
            <td>
                <h2> Friends Dialog</h2>
                <p>
        <a href="<%= ViewData["FriendsDialogUriPage"]%>">Here</a> is a link to a dialog (on a separate page) to add Satya Nadella as your friend.
                </p>
                <p>
        <a href="<%= ViewData["FriendsDialogUriIFrame"]%>">Here</a> is a link to a dialog (in an IFrame) to add Satya Nadella as your friend. 
                </p>
            </td>
            <td>
                <h2> Feed Dialog</h2>
                <p>
        <a href="<%= ViewData["FeedDialogUriPage"]%>">Here</a> is a link to a dialog (on a separate page) to post a feed about this page
                </p>
                <p>
        <a href="<%= ViewData["FeedDialogUriIFrame"]%>">Here</a> is a link to a dialog (in an IFrame) to post a feed about this page
                </p>
            </td>
            <td>
                <h2> Send Dialog</h2>
                <p>
        <a href="<%= ViewData["SendDialogUriPage"]%>">Here</a> is a link to a dialog (on a separate page) to send a message.
                </p>
                <p>
        <a href="<%= ViewData["SendDialogUriIFrame"]%>">Here</a> is a link to a dialog (in an IFrame) to send a message.
                </p>
            </td>
        </tr>
    </table>
    <button type="button" onclick="DeleteAPost()">Delete a Post</button>
</asp:Content>


