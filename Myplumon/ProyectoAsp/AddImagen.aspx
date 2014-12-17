<%@ Page Title="" Language="C#" MasterPageFile="~/Login_out.Master" AutoEventWireup="true" CodeBehind="AddImagen.aspx.cs" Inherits="ProyectoAsp.Formulario_web18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


         <script type="text/javascript" src="Scripts/jquery-1.4.1.js" />

        <script type="text/javascript">

         
            $(window)._load(function () {

                $(function () {
                    $('#cmdarchivo').change(function (e) {
                        addImage(e);
                    });

                    function addImage(e) {
                        var file = e.target.files[0], imageType = /image.*/;

                        if (!file.type.match(imageType))
                            return;

                        var reader = new FileReader();
                        reader.onload = fileOnload;
                        reader.readAsDataURL(file);
                    }

                    function fileOnload(e) {
                        var result = e.target.result;
                        $('#img1').attr("src", result);
                    }
                });
            });
   
    </script>

    <p align="center" class="alt-label">
        &nbsp;</p>
    <p align="center" class="alt-label">
        &nbsp;</p>
    <p align="center" class="alt-label">
        &nbsp;</p>
    <p align="center" class="warning-box">
        <b >ESTAMOS VIENDO QUE NO TIENES UNA IMAGEN O AVATAR </b>
    </p>

    <p align="center" class="dark">
        AGREGA UNA IMAGEN O PRESIONA MAS TARDE PARA CONTINUAR</p>
            <p align="center" class="alt-label" __designer:mapid="3a">
                &nbsp;</p>
    <p align="center" class="blue" __designer:mapid="3e">
        SELECCIONA UNA IMAGEN <asp:FileUpload ID="archivoImagen" runat="server" Width="351px" 
            onprerender="archivoImagen_PreRender" BorderColor="#663300" 
            CssClass="ic-add" Height="18px" />
    </p>
    <p align="center" class="active-tab">
        <asp:Image ID="imgvista" runat="server" BorderColor="#663300" 
            BorderStyle="Ridge" />
         </p>
    <p align="center" class="small-button">
        <asp:Button ID="cmdguardar" runat="server" onclick="cmdguardar_Click" 
            Text="Guardar Imagen" Width="156px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="cmdlate" runat="server" onclick="cmdlate_Click" 
            Text="Mas tarde" Width="156px" />
    </p>
    <p align="center" class="small-button">
        &nbsp;</p>
    <br />


</asp:Content>
