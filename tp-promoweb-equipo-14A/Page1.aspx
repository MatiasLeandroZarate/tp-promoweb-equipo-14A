<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="tp_promoweb_equipo_14A.Page11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class=" col-3"></div>
        <div class="col">

            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Ingrese el Codigo!!!</label>

                <asp:TextBox  ID="txtCodigo" CssClass="form-control" runat="server" MaxLength="15" />

               <hr />
                <br />
                <asp:Button Text="Siguiente" ID="btnSiguiente" CssClass="btn btn-primary" OnClick="btnSiguiente_Click" runat="server" />

            </div>
        </div>
        <div class=" col-5"></div>

    </div>




</asp:Content>
