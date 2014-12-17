<%@ Page Title="" Language="C#" MasterPageFile="~/Login_out.Master" AutoEventWireup="true" CodeBehind="ExitoRegistro.aspx.cs" Inherits="ProyectoAsp.Formulario_web17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        <br />
    </p>
    <p align="center">
        &nbsp;</p>
    <p align="center" class="warning-box">
        U<b >SUARIO REGISTRADO CON EXITO</b></p>
    <p align="center">
        &nbsp;</p>
    <p align="center">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Regresar al menu Principal" />
    </p>
</asp:Content>
