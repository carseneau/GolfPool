<%@ Page Title="" Language="C#" MasterPageFile="~/GolfPool.Master" AutoEventWireup="true"
    CodeBehind="Default2.aspx.cs" Inherits="GolfPool.Default2" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="Content1">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    <div class="articles">
        <br />
        <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None">
        </telerik:RadGrid>
    </div>
</asp:Content>
