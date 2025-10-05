<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="tp_promoweb_equipo_14A.Page2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h1>LISTADO DE PROMOCIONES!</h1>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="Repetidor">
            <ItemTemplate>

     
        <div class="col">
            <div class="card">
                <%if("ImagenUrl" == null || "ImagenUrl" == "")
                    { %>
                        <img src="https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png" class="card-img-top" alt="...">
                    <% }
                    else
                    { %>
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                    <% } %>
                <div class="card-body">
                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                    <p class="card-text"><%#Eval("Descripcion") %></p>
                    <a href="Page3.aspx">Siguiente</a>
                    <%-- 
                    <asp:button text="Siguiente" CssClass="btn btn-primary" ID="btnSiguiente" runat="server"   CommandArgument='<%# Eval("IdArticulo")%>' commandName="ArticuloId"  OnClick="btnSiguiente_Click" />
                        --%> 

                </div>
            </div>
        </div>

            </ItemTemplate>
        </asp:Repeater>
       
        </div>
</asp:Content>

<%--  FALTA ARMAR EL CAROUSEL 
    <div id="carouselExample" class="carousel slide">
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="..." class="d-block w-100" alt="...">
    </div>
    <div class="carousel-item">
      <img src="..." class="d-block w-100" alt="...">
    </div>
    <div class="carousel-item">
      <img src="..." class="d-block w-100" alt="...">
    </div>
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
    --%>