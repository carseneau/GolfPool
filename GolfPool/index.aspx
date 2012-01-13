<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="GolfPool.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnUpdateAllTournaments" runat="server" onclick="btnUpdateAllTournaments_Click" Text="Button" />
    
       <table border="1">
    <thead>
        <tr>
            <%foreach (System.Data.DataColumn col in dt.columns) { %>
                <th><%=col.Caption %></th>
            <%} %>
        </tr>
    </thead>
    <tbody>
    <% foreach(System.Data.DataRow row in dt.Rows) { %>
        <tr>
            <% foreach (var cell in row.ItemArray) {%>
                <td><%=cell.ToString() %></td>
            <%} %>
        </tr>
    <%} %>         
    </tbody>
</table>
        
    
    </div>
    </form>
</body>
</html>
