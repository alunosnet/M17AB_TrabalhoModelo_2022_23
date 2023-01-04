<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="registo.aspx.cs" Inherits="M17AB_TrabalhoModelo_2022_23.registo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://www.google.com/recaptcha/api.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registo</h1>
    Nome:<asp:TextBox runat="server" ID="tb_nome"></asp:TextBox><br />
    Email:<asp:TextBox runat="server" ID="tb_email"></asp:TextBox><br />
    Morada:<asp:TextBox runat="server" ID="tb_morada"></asp:TextBox><br />
    Nif:<asp:TextBox runat="server" ID="tb_nif"></asp:TextBox><br />
    Password:<asp:TextBox runat="server" ID="tb_password" TextMode="Password"></asp:TextBox><br />
    <asp:Button runat="server" ID="bt_guardar" Text="Regitar" OnClick="bt_guardar_Click" /><br />
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
    <!--Recaptcha-->
    <div class="g-recaptcha" data-sitekey="6LepgmgdAAAAAEvfiS0Xdhh1S-i1Py8w8VBiuViE"></div>
</asp:Content>
