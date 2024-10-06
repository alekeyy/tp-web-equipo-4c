<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Datos.aspx.cs" Inherits="tp4.Datos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <h3>Ingresa tus datos</h3>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Label Text="COMPLETE TODOS LOS CAMPOS" runat="server" ID="lblAnuncio"/>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="row row-cols-1 row-cols-md-6">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="col">
                    <asp:Label Text="DNI:" runat="server" ID="lblDni"/>
                    <asp:TextBox ID="textBoxDni" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="textBoxDni_TextChanged"></asp:TextBox>
                    <asp:Label Text="" runat="server" ID="lblSoloNumerosDNI"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <div class="row row-cols-1 row-cols-md-6">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="col">
                    <asp:Label Text="Nombre:" runat="server" ID="lblNombre"/>
                    <asp:TextBox ID="textBoxNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="col">
                    <asp:Label Text="Apellido:" runat="server" ID="lblApellido"/>
                    <asp:TextBox ID="textBoxApellido" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="col">
                    <asp:Label Text="Email:" runat="server" ID="lblEmail"/>
                    <asp:TextBox ID="textBoxEmail" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="textBoxEmail_TextChanged"></asp:TextBox>
                    <asp:Label Text="" runat="server" ID="lblFormatoMail"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <div class="row row-cols-1 row-cols-md-6">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="col">
                    <asp:Label Text="Direccion:" runat="server" ID="lblDireccion"/>
                    <asp:TextBox ID="textBoxDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="col">
                    <asp:Label Text="Ciudad" runat="server" ID="lblCiudad"/>
                    <asp:TextBox ID="textBoxCiudad" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="col">
                    <asp:Label Text="CP:" runat="server" ID="lblCP"/>
                    <asp:TextBox ID="textBoxCodigoPostal" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="textBoxCodigoPostal_TextChanged"></asp:TextBox>
                    <asp:Label Text="" runat="server" ID="lblSoloNumerosCP"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="col">
                <asp:CheckBox ID="checkBoxTerminos" runat="server"/>
                <asp:Label Text="Acepto los terminos y condiciones" runat="server" ID="lblTermsCond"/>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:Button runat="server" Text="Participar" CssClass="btn btn-primary" ID="btnAgregar" OnClick="btnAgregar_Click"/>
</asp:Content>
