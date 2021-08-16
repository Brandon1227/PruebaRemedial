<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrera.aspx.cs" Inherits="Presentación.Carrera" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CRUD - Carrera</title>
</head>
<body>
    <center><h1 style="font-family:Broadway; color:darkgreen">Carrera</h1></center>
    
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" PostBackUrl="~/Cuatrimestre.aspx">Cuatrimestre</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Grupo_Cuatrimestre.aspx">Grupo Cuatrimestre</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/Materia.aspx">Materia</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/Programa_Educativo.aspx">Programa Educativo</asp:LinkButton>
            </div>
            <center><h3 style="font-family:'Bookman Old Style'; color:darkgreen">Insertar</h3></center>
            <asp:Label ID="Label1" runat="server" Text="Nombre de la carrera: "></asp:Label>
            <asp:TextBox ID="txtInsert" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" />
        &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbResp" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
        <div>
            <center><h3 style="font-family:'Bookman Old Style'; color:deepskyblue">Lista</h3></center>
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
        <div>
            <center><h3 style="font-family:'Bookman Old Style'; color:red">Eliminar</h3></center>
            <asp:Label ID="Label2" runat="server" Text="ID a eliminar: "></asp:Label>
            <asp:TextBox ID="txtEliminar" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        </div>
        <div>
            <center><h3 style="font-family:'Bookman Old Style'; color:gold">Actualizar</h3></center>
        </div>
        <asp:Label ID="Label3" runat="server" Text="Id a modificar: "></asp:Label>
        <asp:TextBox ID="txtIdAct" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Modifique nombre de la Carrera: "></asp:Label>
        <asp:TextBox ID="txtActCarr" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnActualiza" runat="server" Text="Actualizar" OnClick="btnActualiza_Click" />
    </form>
</body>
</html>
