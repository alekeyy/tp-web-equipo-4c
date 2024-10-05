<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerificacionVoucher.aspx.cs" Inherits="tp4.VerificacionVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2>Ingrese el codigo de su voucher</h2>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col">
                    <asp:TextBox runat="server" ID="txtVoucher" AutoPostBack="true" OnTextChanged="txtVoucher_TextChanged"/>
                    <asp:Label Text="" runat="server" ID="lblVerificacion"/>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Button Text="Continuar" runat="server" ID="btnContinuar" OnClick="btnContinuar_Click"/>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
