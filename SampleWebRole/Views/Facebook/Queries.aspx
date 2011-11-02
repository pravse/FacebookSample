<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>
<asp:Content ID="NoAppId" ContentPlaceHolderID="TitleContent" runat="server">
    Facebook Queries
</asp:Content>
<asp:Content ID="OpenGraphTagsContent" ContentPlaceHolderID="OpenGraphTags" runat="server">
    <%=this.ViewData["OpenGraphTags"]%>
</asp:Content>

<asp:Content ID="NoJSContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.ViewData["FBRootWithoutAppId"] %>
    <p>
        The Facebook controls on this page require the FB Javascript SDK and HTML5. However, they do not require that the app has registered itself with facebook (i.e. the app does not need an AppId).
        In general, these controls can integrate more richly with the rest of the web page (as compared to IFRAME-based plugins).
        If you serve this page on a site that isn't accessible by Facebook (eg: on your localhost for debugging), some of the control will not be fully functional because Facebook checks the calling site.
    </p>
    <table>
        <tr>
            <td width="200">
                <p>
        Here is an Activity Feed (for the www.huffingtonpost.com and news.yahoo.com 
        domains).
        <%= ViewData["ActivityFeedHtml5"] %> 
                </p>
            </td>
            <td width="200">
                <p>
        Here is some general content with a Like Button. 
        <%= ViewData["LikeHtml5"] %>

        Add some comments to this page ...
        <%= ViewData["CommentsHtml5"] %>
                </p>
            </td>
            <td width="200">
                <p>
        LikeBox to like my facebook page ...
        <%= ViewData["LikeBoxHtml5"] %>
                </p>
            </td>
        </tr>
    </table>
</asp:Content>


