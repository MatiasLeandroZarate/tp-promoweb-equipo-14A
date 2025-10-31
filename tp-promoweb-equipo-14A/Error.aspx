<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="tp_promoweb_equipo_14A.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Ocurrio un Error</h3>
    <asp:label text="text" id="lblError" runat="server"/>
    <br />
    <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-primary" runat="server" Onclick="btnVolver_Click"/>
</asp:Content>
