<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Clientes_NV.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="id_cliente" HeaderText="id_cliente" InsertVisible="False" ReadOnly="True" SortExpression="id_cliente" />
                    <asp:BoundField DataField="identificacion" HeaderText="identificacion" SortExpression="identificacion" />
                    <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />
                    <asp:BoundField DataField="apellido" HeaderText="apellido" SortExpression="apellido" />
                    <asp:BoundField DataField="fecha_nacimiento" HeaderText="fecha_nacimiento" SortExpression="fecha_nacimiento" />
                    <asp:CheckBoxField DataField="estado" HeaderText="estado" SortExpression="estado" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db_clientesConnectionString %>" SelectCommand="SELECT * FROM [tbl_cliente]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
