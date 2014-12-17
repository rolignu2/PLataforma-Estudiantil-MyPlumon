<%@ Page Title="" Language="C#" MasterPageFile="~/Login_out.Master" AutoEventWireup="true" CodeBehind="AddImagen.aspx.cs" Inherits="ProyectoAsp.Formulario_web18" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center" class="dark">
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
                <asp:Image ID="imagenavatar" runat="server" BorderStyle="Dashed" 
            BorderWidth="2px" Height="168px" 
            Width="135px"  />
            </p>
    <p align="center" class="active-tab" __designer:mapid="3e">
        <asp:FileUpload ID="archivoImagen" runat="server" Width="285px" 
            onprerender="archivoImagen_PreRender" />
    </p>
    <p align="center" class="active-tab">
        &nbsp;</p>
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
