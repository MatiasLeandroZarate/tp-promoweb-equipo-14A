<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="Page3.aspx.cs" Inherits="tp_promoweb_equipo_14A.Page3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%--CONTENIDO DE LA PANTALLA --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div class="container">
            <div class="col-md-2">
                <label for="validationCumtom01" class="form-label">DNI </label>
                <input type="number" class="form-control" id="validationCustom" value="" required="">
                <div class="valid-feedback">Ok!</div>
            </div>

            <div class="col-md-3">
                <label for="validationCustom02" class="form-label">Nombre</label>
                <input type="text" class="form-control" id="validationCustom01" value="Mark" required="">
                <div class="valid-feedback">
                    Ok!
                </div>
            </div>
            <div class="col-md-3">
                <label for="validationCustom03" class="form-label">Apellido</label>
                <input type="text" class="form-control" id="validationCustom02" value="Otto" required="">
                <div class="valid-feedback">
                    Ok!
                </div>
            </div>
            <div class="col-md-3">
                <label for="validationCustomUsername" class="form-label">Email</label>
                <div class="input-group has-validation">
                    <span class="input-group-text" id="inputGroupPrepend">@</span>
                    <input type="text" class="form-control" id="validationCustomUsername" aria-describedby="inputGroupPrepend" required="">
                    <div class="invalid-feedback">
                        Por favor, ingresar el Email.
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <label for="validationCustom03" class="form-label">Dirección</label>
                <input type="text" class="form-control" id="validationCustom03" required="">
                <div class="invalid-feedback">
                    Por favor, ingresar la Dirección.
                </div>
            </div>
            <div class="col-md-3">
                <label for="validationCustom04" class="form-label">Ciudad</label>
                <input type="text" class="form-control" id="validationCustom04" required="">

                <div class="invalid-feedback">
                    Por favor, ingresar la Ciudad.
                </div>
            </div>
            <div class="col-md-3">
                <label for="validationCustom05" class="form-label">CP</label>
                <input type="text" class="form-control" id="validationCustom05" required="">
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
