<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EleccionPremio.aspx.cs" Inherits="tp4.EleccionPremio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <h3>Elegi tu premio</h3>
    <div class="row row-cols-1 row-cols-md-6">
<%--    <%
        foreach (dominio.Articulo articulo in listaArticulo)
        {
        %>
        <div class="col">
            <div class="card">
              <img class="card-img-top fix-img" src="<%:articulo.Imagenes[0] %>" alt="Card image cap">
              <div class="card-body">
                <h5 class="card-title"><%: articulo.Nombre %></h5>
                <p class="card-text"><%: articulo.Descripcion %></p>
                <asp:Button runat="server" ID="btnAgregar" CssClass="btn btn-primary" Text="Seleccionar" OnClick="btnAgregar_Click" CommandArgument="<%: articulo.Id %>" />
              </div>
            </div>
        </div>
    <%
        }%>--%>

        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                      <img class="card-img-top fix-img" src="<%#Eval("Imagenes") %>" alt="Card image cap">
                      <div class="card-body">
                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                        <p class="card-text"><%#Eval("Descripcion") %></p>
                        <asp:Button runat="server" ID="btnAgregar" CssClass="btn btn-primary" Text="Seleccionar" OnClick="btnAgregar_Click" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo"/>
                      </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
