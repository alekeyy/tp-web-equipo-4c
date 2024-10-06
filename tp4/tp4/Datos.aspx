<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Datos.aspx.cs" Inherits="tp4.Datos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <h3>Ingresa tus datos</h3>
    <div class="row row-cols-1 row-cols-md-6">
        <div class="col">
            <label for="textBoxDni">DNI</label>
            <asp:TextBox ID="textBoxDni" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="textBoxDni_TextChanged"></asp:TextBox>
        </div>
    </div>
    <div class="row row-cols-1 row-cols-md-6">
        <div class="col">
            <label for="textBoxNombre">Nombre</label>
            <asp:TextBox ID="textBoxNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col">
            <label for="textBoxApellido">Apellido</label>
            <asp:TextBox ID="textBoxApellido" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col">
            <label for="textBoxEmail">Email</label>
            <asp:TextBox ID="textBoxEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row row-cols-1 row-cols-md-6">
        <div class="col">
            <label for="textBoxDireccion">Direccion</label>
            <asp:TextBox ID="textBoxDireccion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col">
            <label for="textBoxCiudad">Ciudad</label>
            <asp:TextBox ID="textBoxCiudad" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col">
            <label for="textBoxCodigoPostal">CP</label>
            <asp:TextBox ID="textBoxCodigoPostal" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="col">
        <asp:CheckBox ID="checkBoxTerminos" runat="server"/>
        <label for="checkBoxTerminos">Acepto los terminos y condiciones</label>
    </div>
    <asp:Button runat="server" Text="Participar" CssClass="btn btn-primary" ID="btnAgregar" OnClick="btnAgregar_Click"/>
</asp:Content>
