<%@ Page Title="" Language="C#" MasterPageFile="~/GolfPool.Master" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="GolfPool.Default2" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="Content1">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Standings
    </h2>
    <div class="articles">

        <br />

        <telerik:RadGrid ID="RadGrid1" runat="server">
        </telerik:RadGrid>

</div>
</asp:Content>