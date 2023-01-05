<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Emprestimos.aspx.cs" Inherits="M17AB_TrabalhoModelo_2022_23.Admin.Emprestimos.Emprestimos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Empréstimos</h2>
    <asp:CheckBox runat="server" ID="cb_livros_emprestados" />Só livros emprestados
    <asp:GridView runat="server" ID="gv_emprestimos"></asp:GridView>
    <h2>Registar novo empréstimo</h2>
    Livro: <asp:DropDownList runat="server" ID="dd_livro"></asp:DropDownList>
    <br />
    Leitor:<asp:DropDownList runat="server" ID="dd_leitor"></asp:DropDownList>
    <br />
    Data devolução:<asp:TextBox runat="server" ID="tb_data" TextMode="Date"></asp:TextBox>
    <br />
    <asp:Button runat="server" ID="bt_registar" Text="Emprestar" OnClick="bt_registar_Click" />
    <br />
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
</asp:Content>
