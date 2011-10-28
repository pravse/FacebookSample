﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>
<asp:Content ID="NoJSTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Interacting with Friends
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
    <h2>Dialogs</h2>
    <p>
        The Facebook "dialog" controls on this page do not require the FB Javascript SDK nor do they require any authentication to have occurred. 
        However, they all do need a Facebook App Id that is specified as a parameter to each dialog. 
        Each dialog can be open (via href) as a whole page (hosted by Facebook) or can run inside an IFrame on this page (which is the way this page is built).
        If using IFrames, there does need to be an authentication token. See the docs for more details on this.
    </p>
    <table>
        <tr>
            <td>
                <p>
        <a href="<%= ViewData["FriendsDialogUri"]%>">Here</a> is a link to a dialog to add Satya Nadella as your friend.
                </p>
            </td>
            <td>
                <p>
        <a href="<%= ViewData["FeedDialogUri"]%>">Here</a> is a link to a dialog to post a feed about this page
                </p>
            </td>
        </tr>
    </table>
</asp:Content>


