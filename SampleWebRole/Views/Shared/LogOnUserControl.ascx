<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        <div id="LogOff">
        [ <%: Html.ActionLink("Log Off", "LogOff", "Facebook") %> ]
        </div>
<%
    }
    else {
%> 
        <div id="LogOn">
        [ <%: Html.ActionLink("Log On", "LogOn", "Facebook") %> ]
        </div>
<%
    }
%>
