<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="M17AB_TrabalhoModelo_2022_23.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Módulo 17AB</h1>
    <!--Login-->
    <div runat="server" id="divLogin">
        Email:<asp:TextBox runat="server" ID="tb_Email"></asp:TextBox><br />
        Password:<asp:TextBox runat="server" ID="tb_Password" TextMode="Password"></asp:TextBox><br />
        <asp:Label runat="server" ID="lb_erro"></asp:Label><br />
        <asp:Button runat="server" ID="bt_login" Text="Login" />
        <asp:Button runat="server" ID="bt_recuperar" Text="Recuperar password" OnClick="bt_recuperar_Click" />
    </div>
    <!--Pesquisa-->
    
    <!--Lista dos livros-->

</asp:Content>
