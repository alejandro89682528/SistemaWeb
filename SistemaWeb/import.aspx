<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="import.aspx.cs" Inherits="SistemaWeb.import" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        Importar datos<br />
        <br />
        Departamento&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="cod_dpto">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [cod_dpto], [nombre] FROM [dpto]"></asp:SqlDataSource>
       <br />
        <br />
        Semestre&nbsp;
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem Value="1">Semestre 1</asp:ListItem>
            <asp:ListItem Value="2">Semestre 2</asp:ListItem>
        </asp:DropDownList>
        
        <br />
        <asp:Button ID="Button1" runat="server" Text="Mostrar" OnClick="Button1_Click" />
        <br />

        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
    </form>
</body>
</html>

