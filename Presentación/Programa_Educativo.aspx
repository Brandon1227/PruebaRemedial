<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Programa_Educativo.aspx.cs" Inherits="Presentación.Programa_Educativo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CRUD - Programa Educativo</title>
</head>
<body>
    <center><h1 style="font-family:Broadway; color:darkgreen">Programa Educativo</h1></center>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Carrera.aspx">Carrera</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Cuatrimestre.aspx">Cuatrimestre</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/Grupo_Cuatrimestre.aspx">Grupo Cuatrimestre</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/Materia.aspx">Materia</asp:LinkButton>
        </div>
        <div>
            <center><h3 style="font-family:'Bookman Old Style'; color:darkgreen">Insertar</h3></center>
            <asp:Label ID="Label1" runat="server" Text="Programa Educativo: "></asp:Label>
            <asp:TextBox ID="txtProgra" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Carrera: "></asp:Label>
            <asp:TextBox ID="txtCarrera" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Extra: "></asp:Label>
            <asp:TextBox ID="txtExtra" runat="server"></asp:TextBox>
            <br />
            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Carrera" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
            <br />
            <asp:Button ID="btnInsert" runat="server" Text="Insertar" OnClick="btnInsert_Click" />
        &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbResp" runat="server" Text="Label"></asp:Label>
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
            <asp:Label ID="Label4" runat="server" Text="ID a Eliminar: "></asp:Label>
            <asp:TextBox ID="txtEliminar" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Button ID="btEliminar" runat="server" Text="Eliminar" OnClick="Button1_Click" />
        </div>
        <div>
            <center><h3 style="font-family:'Bookman Old Style'; color:gold">Actualizar</h3></center>
            <asp:Label ID="Label5" runat="server" Text="ID a Actualizar: "></asp:Label>
            <asp:TextBox ID="txtActID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Programa a Actualizar: "></asp:Label>
            <asp:TextBox ID="txtActProg" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Extra a Actualizar: "></asp:Label>
            <asp:TextBox ID="txtActExtra" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
        </div>
    </form>
</body>
</html>
