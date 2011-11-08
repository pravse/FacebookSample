<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>

<asp:Content ID="NoJSContent" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.ViewData["FBRoot"] %>
    <p>
        This page demonstrates the use of queries over the FB graph. The <a href="https://developers.facebook.com/docs/reference/fql/"></a>FB documentation for FQL</a> lists about 20 different tables each of which has a different schema. 
        Some of the fields of each table are "indexable" and are allowed to be used in WHERE conditions. So far, I am unable to find a schema or catalog that can be reflected on to construct a query builder. So I've added a few sample queries 
        but do not exhaustively cover all available tables. JOIN queries are not supported, but uncorrelated IN subqueries are supported, allowing simple "membership" joins to be executed.
    </p>
    <table>
        <tr>
            <td>
                <p><button type="button" onclick="GraphAPIData('fql?q=<%:ViewData["FQLMyFriends"]%>');">My friends</button></p>
            </td>
        </tr>
    </table>
</asp:Content>


