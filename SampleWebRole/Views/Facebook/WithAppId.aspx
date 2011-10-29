<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>
<asp:Content ID="NoAppId" ContentPlaceHolderID="TitleContent" runat="server">
    Controls with an AppId
</asp:Content>
<asp:Content ID="OpenGraphTagsContent" ContentPlaceHolderID="OpenGraphTags" runat="server">
    <%=this.ViewData["OpenGraphTags"]%>
</asp:Content>

<asp:Content ID="JQueryInclude" ContentPlaceHolderID="JQuery" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript">
        $(function () {
            // any jquery stuff you want to add
        });
    </script>
</asp:Content>


<asp:Content ID="NoJSContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.ViewData["FBRootWithoutAppId"] %>
    <p>
        The Facebook controls on this page require the FB Javascript SDK and HTML5. This is identical to the "No AppId" page, except that the SDK is initialized with this applications Facebook AppId. This alters the behaviors of some of the controls.
    </p>
    <table>
        <tr>
            <td>
        Here is some general content with a Like Button. 
        <%= ViewData["LikeHtml5"] %>
            </td>
            <td>
        Add some comments to this page ...
        <%= ViewData["CommentsHtml5"] %>
            </td>
            <td>
         Here is an Activity Feed (for the www.huffingtonpost.com and news.yahoo.com 
        domains).
        <%= ViewData["ActivityFeedHtml5"] %> 
            </td>
        </tr>
        <tr>
            <td>
        Here is a like Facepile (photos of users who like this page). This will be empty if no users currently like this page.
        <%= ViewData["LikeFacepileHtml5"] %>

        Here is an App Facepile (photos of people who signed up for this Facebook app). This will be empty if no users currently are signed up for this app.
        <%= ViewData["AppFacepileHtml5"] %>
            </td>
            <td>
         LikeBox to like the CocaCola page (this only works for commercial FB pages, not user pages)
        <%= ViewData["LikeBoxHtml5"] %>
            </td>
       </tr>
    </table>
</asp:Content>


