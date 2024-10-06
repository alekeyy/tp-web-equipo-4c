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
                        
                                <div id="carouselDeImagenes" class="carousel slide" data-bs-ride="carousel">
                                    <div class="carousel-inner">
                                    
                                        <asp:Repeater runat="server" ID="repImagenes" DataSource='<%#Eval("Imagenes") %>'>
                                            <ItemTemplate>

                                                <%-- 
                                                    container.itemIndex devuelve el indice del elemento actual en el repeater
                                                    si el elemento es el primero, se le asigna activo, para que inicie la muestra.
                                                    sino no se le agrega, ya que si todos los items tienen active, 
                                                    se muestran todas las imagenes al mismo tiempo.
                                                    --%>
                                                <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>"> 
                                                    <img src="<%#Eval("ImagenUrl")%>" class="d-block w-100">
                                                </div> 

                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </div>
                                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Previous</span>
                                    </button>
                                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Next</span>
                                    </button>
                                </div>

                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <asp:Button runat="server" ID="btnAgregar" CssClass="btn btn-primary" Text="Seleccionar" OnClick="btnAgregar_Click" CommandArgument='<%#Eval("Id") %>' CommandName="IdArticulo" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
