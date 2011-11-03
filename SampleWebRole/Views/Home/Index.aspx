<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= ViewData["FBRoot"] %>
    <p>
        This sample application demonstrates how to integrate Facebook controls into a Windows Azure application.
    </p>
</asp:Content>
