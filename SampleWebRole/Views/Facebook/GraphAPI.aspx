<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>

<asp:Content ID="NoJSContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.ViewData["FBRoot"] %>
    <p>
        This page demonstrates the use of a variety of FB GraphAPI calls to retrieve information of interest directly from the FB graph.
    </p>
    <table>
        <tr>
            <td>
                <p><button type="button" onclick="GraphAPIData('me');">All about me</button></p>
            </td>
            <td>
                <p><button type="button" onclick="GraphAPIData('4');">All about Zuck</button></p>
            </td>
            <td>
                <p><button type="button" onclick="GraphAPIData('me/posts');">My posts (most recent 3)</button></p>
            </td>
            <td>
                <p><button type="button" onclick="GraphAPIData('me/friends');">My friends (limit 3)</button></p>
            </td>
            <td>
                <p><button type="button" onclick="GraphAPIData('me/home');">My news feed (limit 3)</button></p>
            </td>
            <td>
                <p><button type="button" onclick="GraphAPIData('me?metadata=1&fields=name');">All my connections</button></p>
            </td>
        </tr>
    </table>
</asp:Content>


