<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= ViewData["FBRoot"] %>
    <script type="text/javascript">
        // page=specific callback invoked from JQuery document.ready delegate
        function PageInit(event) {             
            if (null != <%= ViewData["RequestIds"] %>) {
                alert('user received requests ids : <%= ViewData["RequestIds"] %> ');
                for (requestId in <%= ViewData["RequestIds"] %>)
                {
                    // TODO: process the request appropriately

                    alert('deleting request Id : ' + requestId);
                    FB.api(requestId, 'delete', function(response) { console.log(response); });
                }
            }
        };
        $("#header").bind("docready", PageInit);

    
    </script>
    <p>
        This sample application demonstrates how to integrate Facebook controls into a Windows Azure application.
    </p>
</asp:Content>
