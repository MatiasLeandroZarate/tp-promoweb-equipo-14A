<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="tp_promoweb_equipo_14A.Page2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <h1>LISTADO DE PROMOCIONES!</h1>
    </div>
    <asp:Button Text="Atras" ID="btnAtras" CssClass="btn btn-primary" OnClick="btnAtras_Click" runat="server" />
    <div class="container text-center">
        <div class="row row-cols-1 row-cols-md-3 g-4">

            <asp:Repeater runat="server" ID="Repetidor">
                <ItemTemplate>



                    <div class="col">

                        <div class="card">
                            <%if ("ImagenUrl" == null || "ImagenUrl" == "")
                                { %>
                            <img src="https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png" class="card-img-top">
                            <% }
                                else
                                { %>
                            <div class="d-flex justify-content-center">
                                <img src='<%# Eval("ImagenUrl") %>' class="card-img-top" style="width: 200px; height: 200px; object-fit: contain;" />
                            </div>

                            <% } %>
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text"><%#Eval("Descripcion") %></p>

                                <asp:Button Text="Siguiente" ID="btnSiguiente" CssClass="btn btn-primary" OnClick="btnSiguiente_Click" runat="server" CommandArgument='<%# Eval("Id")%>' CommandName="IdArticulo" />

                            </div>
                        </div>
                    </div>



                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
</asp:Content>
