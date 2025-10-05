<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="Page3.aspx.cs" Inherits="tp_promoweb_equipo_14A.Page3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%--CONTENIDO DE LA PANTALLA --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div class="container">
            <hr />
            <div class="col-md-2">
                <label for="txtDNI" class="form-label">DNI </label>
                <asp:TextBox runat="server" id="txtDNI" TextMode="Number" CssClass="form-control" required=""/>
               
            </div>

            <div class="col-md-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" id="txtNombre" CssClass="form-control" required="" />
                
            </div>
            <div class="col-md-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" id="txtApellido" required=""/>
                
            </div>
            <div class="col-md-3">
                <label for="txtEmail" class="form-label">Email</label>
                <div class="input-group has-validation">
                    <span class="input-group-text" id="inputGroupPrepend">@</span>
                    <asp:TextBox runat="server" CssClass="form-control" id="txtEmail" required=""/>
                    
                </div>
            </div>
            <div class="col-md-6">
                <label for="txtDireccion" class="form-label">Dirección</label>
              <asp:TextBox runat="server" CssClass="form-control" id="txtDireccion" required=""/>
            </div>

            <div class="col-md-3">
                <label for="txtCiudad" class="form-label">Ciudad</label>
              <asp:TextBox runat="server" CssClass="form-control" id="txtCiudad" required=""/>

                <div class="invalid-feedback">
                    Por favor, ingresar la Ciudad.
                </div>
            </div>
            <div class="col-md-3">
                <label for="txtCP" class="form-label">CP</label>
              <asp:TextBox runat="server" CssClass="form-control" id="txtCP" TextMode="Number" required=""/>

                <div class="invalid-feedback">
                    Por davor, ingresar el Código Postal
                </div>
            </div>
            <div class="col-12">
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="invalidCheck" required="">
                    <label class="form-check-label" for="invalidCheck">
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
