<%@ Page Title="" Language="C#" MasterPageFile="~/Login_out.Master" AutoEventWireup="true" CodeBehind="Recuperar.aspx.cs" Inherits="ProyectoAsp.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        &nbsp;</p>
    <p align="center">
    <p></p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txtmail" ErrorMessage="Email requerido "></asp:RequiredFieldValidator>
    </p>
    <p>
    </p>
    <p align="center">
        <asp:Label ID="Label4" runat="server" Font-Size="Medium" ForeColor="#003300" 
            Text="Correo electronico"></asp:Label>
        <asp:TextBox ID="txtmail" runat="server" CssClass="full-width-input" 
            Height="24px" TextMode="Email" Width="202px"></asp:TextBox>
        </p>
    <p align="center">
        <asp:Button ID="cmdrecuperar" runat="server" CssClass="button" Text="Recuperar " 
            Width="170px" onclick="cmdrecuperar_Click" />
    </p>
    <p align="center">
        &nbsp;</p>
    <p align="center">
        <br />
        <div id="exito" runat="server" >
        </div>
    </p>
</asp:Content>

