<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>

<asp:Content ID="NoJSContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        The Facebook "plugin" controls on this page do not require the FB Javascript SDK or an AppId. They do not use XFBML/HTML5. 
        Instead, they are all hosted in IFrames. This makes it very simple to add FB plugins to any web page.
        The downside is that the rest of the page cannot interact with the plugins and the user activity in those plugins.
        Also note that the login/authentication (top right of the page) doesn't work because without the AppId, Facebook does not permit user authentication.
    </p>
    <table>
        <tr>
            <td>
                <p>
        Here is some general content with a Like button.
                </p>
        <%= ViewData["LikeIFrame"]%>
            </td>
            <td>
                <p>
        Here is an Activity Feed (for the www.huffingtonpost.com and news.yahoo.com domains). 
                </p>
        <%= ViewData["ActivityFeedIFrame"] %>
            </td>
        </tr>
        <tr>
            <td>
                <p>
        Here is a Like Facepile (photos of people who like this page). This will be empty if no users currently like this page.
                </p>
        <%= ViewData["LikeFacepileIFrame"] %>
            </td>
            <td>
                <p>
        Here is an App Facepile (photos of people who signed up for this Facebook app). This will be empty if no users currently are signed up for this app.
                </p>
        <%= ViewData["AppFacepileIFrame"] %>
            </td>
        </tr>
    </table>
</asp:Content>


