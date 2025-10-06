<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="Page3.aspx.cs" Inherits="tp_promoweb_equipo_14A.Page3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%--CONTENIDO DE LA PANTALLA --%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" CausesValidation="false">


    <h1>COMPLETE LOS DATOS!</h1>
    <%--<asp:Button Text="Atras" ID="Button1" CssClass="btn btn-primary" OnClick="btnAtras_Click" runat="server" CausesValidation="false" />--%>

    <div class="container">
        <hr />
        <div class="col-md-2">
            <label for="txtDNI" class="form-label">DNI </label>
            <%--<asp:TextBox runat="server" ID="txtDNI" TextMode="Number" CssClass="form-control" required="" />--%>
            <asp:TextBox runat="server" ID="txtDNI" CssClass="form-control" MaxLength="10" TextMode="Number" AutoPostBack="true" OnTextChanged="txtDNI_TextChanged" />
        </div>

        <div class="col-md-3">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />

        </div>
        <div class="col-md-3">
            <label for="txtApellido" class="form-label">Apellido</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" />

        </div>
        <div class="col-md-3">
            <label for="txtEmail" class="form-label">Email</label>
            <div class="input-group has-validation">
                <span class="input-group-text" id="inputGroupPrepend">@</span>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />

            </div>
        </div>
        <div class="col-md-6">
            <label for="txtDireccion" class="form-label">Dirección</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtDireccion" />
        </div>

        <div class="col-md-3">
            <label for="txtCiudad" class="form-label">Ciudad</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtCiudad" />

            <div class="invalid-feedback">
                Por favor, ingresar la Ciudad.
            </div>
        </div>
        <div class="col-md-3">
            <label for="txtCP" class="form-label">CP</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtCP" TextMode="Number" />

            <div class="invalid-feedback">
                Por davor, ingresar el Código Postal
            </div>
        </div>
        <div class="col-12">
            <div class="form-check">
                <%--<input class="form-check-input" type="checkbox" value="" id="invalidCheck" required="">--%>
                <%--<input class="form-check-input" type="checkbox" value="" id="invalidCheck">--%>
                <asp:CheckBox ID="chkTerminos" runat="server" CssClass="form-check-input" />
                <label class="form-check-label" for="<%= chkTerminos.ClientID %>">
                    Acepto los Términos y Condiciones.
                </label>
                <div class="invalid-feedback">
                    Debes aceptar los Términos y Condiciones.
                </div>
            </div>
        </div>
        <div class="col-12">

            <asp:Button Text="Enviar!" CssClass="btn btn-primary" ID="btnEnviar" OnClick="btnEnviar_Click" runat="server" />
        </div>
    </div>

    <!-- Example Code End -->
</asp:Content>
