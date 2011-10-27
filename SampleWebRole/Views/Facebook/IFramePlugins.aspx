<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>
<asp:Content ID="NoJSTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Interacting with Friends
</asp:Content>
<asp:Content ID="OpenGraphTagsContent" ContentPlaceHolderID="OpenGraphTags" runat="server">
    <%=this.ViewData["OpenGraphTags"]%>
</asp:Content>

<asp:Content ID="NoJSContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>IFrame Plugins</h2>
    <p>
        The Facebook "plugin" controls on this page do not require the FB Javascript SDK. They do not use XFBML/HTML5. 
        Instead, they are all hosted in IFrames. This makes it very simple to add FB plugins to any web page.
        The downside is that the rest of the page cannot interact with the plugins and the user activity in those plugins.
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
        Here is a Like Facepile (photos of people who like this page). This will be empty if no users currently like this page.
        <%= ViewData["LikeFacepileIFrame"] %>
            </td>
            <td>
        Here is an App Facepile (photos of people who signed up for this Facebook app). This will be empty if no users currently are signed up for this app.
        <%= ViewData["AppFacepileIFrame"] %>
            </td>
        </tr>
    </table>
</asp:Content>


