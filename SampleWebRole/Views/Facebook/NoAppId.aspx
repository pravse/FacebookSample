<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>

<asp:Content ID="NoJSContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.ViewData["FBRootWithoutAppId"] %>
    <p>
        The Facebook controls on this page require the FB Javascript SDK and HTML5. However, they do not require that the app has registered itself with facebook (i.e. the app does not need an AppId).
        In general, these controls can integrate more richly with the rest of the web page (as compared to IFRAME-based plugins).
        If you serve this page on a site that isn't accessible by Facebook (eg: on your localhost for debugging), some of the control will not be fully functional because Facebook checks the calling site.
    </p>
    <table>
        <tr>
            <td>
        <p>Here is some general content with a Like Button. </p>
        <%= ViewData["LikeHtml5"] %>
            </td>
           <td>
        <p>Here is a like Facepile (photos of users who like this page). This will be empty if no users currently like this page.</p>
        <%= ViewData["LikeFacepileHtml5"] %>
            </td>
           <td>
        <p>Here is an App Facepile (photos of people who signed up for this Facebook app). This will be empty if no users currently are signed up for this app.</p>
        <%= ViewData["AppFacepileHtml5"] %>
            </td>
         </tr>
        <tr>
            <td>
        <p>Add some comments to this page ...</p>
        <%= ViewData["CommentsHtml5"] %>
            </td>
            <td>
         <p>Here is an Activity Feed (for the www.huffingtonpost.com and news.yahoo.com domains).</p>
        <%= ViewData["ActivityFeedHtml5"] %> 
            </td>
            <td>
         <p>LikeBox to like the CocaCola page (this only works for commercial FB pages, not user pages)</p>
        <%= ViewData["LikeBoxHtml5"] %>
            </td>
       </tr>
    </table>
</asp:Content>


