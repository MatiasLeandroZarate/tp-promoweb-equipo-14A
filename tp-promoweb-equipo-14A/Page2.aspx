<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="tp_promoweb_equipo_14A.Page2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card .img-area {
            height: 400px;
            overflow: hidden;
            display: flex;
            align-items: center;
            justify-content: center;
            background: #ffffff; 

        }
        
            .card .img-area img,
            .carousel .img-area img {
                width: 100%;
                height: 90%;
                object-fit: contain;
                display: block;
            }

        .card {
            height: 100%;
            display: flex;
            flex-direction: column;
        }

        .card-body {
            flex: 1 1 auto;
        }

        .row .col {
            display: flex;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1>LISTADO DE PROMOCIONES!</h1>
    </div>
    <asp:Button Text="Atras" ID="btnAtras" CssClass="btn btn-primary" OnClick="btnAtras_Click" runat="server" />
    <div class="container text-center">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater runat="server" ID="Repetidor" OnItemDataBound="Repetidor_ItemDataBound">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">

                            <div id='carouselExampleDark_<%# Eval("Articulo.Id") %>' class="carousel carousel-dark slide">
                                <div class="carousel-inner">
                                    <asp:Repeater runat="server" ID="rptImagenes">
                                        <ItemTemplate>
                                            <div class='<%# (Container.ItemIndex == 0) ? "carousel-item active" : "carousel-item" %>'>
                                                <div class="img-area">
                                                    <%--<img src='<%# Container.DataItem %>' class="d-block w-100" alt="Imagen" /> --%>
                                                    <img src='<%# String.IsNullOrEmpty(Convert.ToString(Container.DataItem)) ? "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png" : Convert.ToString(Container.DataItem) %>' class="d-block w-100" alt="Imagen" />
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleDark_<%# Eval("Articulo.Id") %>" data-bs-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Previous</span>
                                </button>
                                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleDark_<%# Eval("Articulo.Id") %>" data-bs-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Next</span>
                                </button>
                            </div>

                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Articulo.Nombre") %></h5>
                                <p class="card-text"><%# Eval("Articulo.Descripcion") %></p>

                                <asp:Button Text="Siguiente" ID="btnSiguiente" CssClass="btn btn-primary" OnClick="btnSiguiente_Click" runat="server" CommandArgument='<%# Eval("Articulo.Id") %>' CommandName="IdArticulo" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
