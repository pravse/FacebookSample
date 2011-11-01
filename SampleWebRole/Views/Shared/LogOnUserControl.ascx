<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
        <div id="LogOn">
<%
    if (Request.IsAuthenticated) {
       Html.ActionLink("Log Off", "LogOff", "Facebook") ;
    }
    else {
        Html.ActionLink("Log On", "LogOn", "Facebook") ;
    }
%>
        </div>
