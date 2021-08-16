<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grupo_Cuatrimestre.aspx.cs" Inherits="Presentación.Grupo_Cuatrimestre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CRUD - Grupo Cuatrimestre</title>
</head>
<body>
    <center><h1 style="font-family:Broadway; color:darkgreen">Grupo Cuatrimestre</h1></center>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Carrera.aspx">Carrera</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Cuatrimestre.aspx">Cuatrimestre</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/Materia.aspx">Materia</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/Programa_Educativo.aspx">Programa Educativo</asp:LinkButton>
        </div>
        <div>
            <center><h3 style="font-family:'Bookman Old Style'; color:darkgreen">Insertar</h3></center>
            <asp:Label ID="Label1" runat="server" Text="Programa Educativo: "></asp:Label>
            <asp:TextBox ID="txtProg" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Grupo: "></asp:Label>
            <asp:TextBox ID="txtGrupo" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Cuatrimestre: "></asp:Label>
            <asp:TextBox ID="txtCuatri" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Turno: "></asp:Label>
            <asp:TextBox ID="txtTurno" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Modalidad: "></asp:Label>
            <asp:TextBox ID="txtModalidad" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Extra: "></asp:Label>
            <asp:TextBox ID="txtExtra" runat="server"></asp:TextBox>
            <br />
            <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField SelectText="Selecciona Salon" ShowSelectButton="True" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView3_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Programa" ShowSelectButton="True" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:GridView ID="GridView4" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GridView4_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Cuatrimestre" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                <SortedAscendingCellStyle BackColor="#FEFCEB" />
                <SortedAscendingHeaderStyle BackColor="#AF0101" />
                <SortedDescendingCellStyle BackColor="#F6F0C0" />
                <SortedDescendingHeaderStyle BackColor="#7E0000" />
            </asp:GridView>
            <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insertar" />
        &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lbResp" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <center><h3 style="font-family:'Bookman Old Style'; color:#33CCFF">Lista</h3></center>
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
        &nbsp;&nbsp;&nbsp;
        </div>
        <div>
            <center><h3 style="font-family:'Bookman Old Style'; color:#CC0000">Eliminar</h3></center>
            <asp:Label ID="Label2" runat="server" Text="ID a eliminar: "></asp:Label>
            <asp:TextBox ID="txtElimina" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        </div>
        <div>
            <center><h3 style="font-family:'Bookman Old Style'; color:gold">Actualizar</h3></center>
            <asp:Label ID="Label3" runat="server" Text="ID a Actualizar: "></asp:Label>
            <asp:TextBox ID="txtActID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Actualizar Turno: "></asp:Label>
            <asp:TextBox ID="txtActTurno" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label10" runat="server" Text="Actualizar Modalidad: "></asp:Label>
            <asp:TextBox ID="txtActModalidad" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Actualizar Extra: "></asp:Label>
            <asp:TextBox ID="txtActExtra" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
        </div>
    </form>
</body>
</html>
