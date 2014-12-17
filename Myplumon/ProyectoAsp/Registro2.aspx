<%@ Page Title="" Language="C#" MasterPageFile="~/Login_out.Master" AutoEventWireup="true" CodeBehind="Registro2.aspx.cs" Inherits="ProyectoAsp.Formulario_web14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p align="center">
        &nbsp;</p>
    <p align="center">
        &nbsp;</p>
    <p class="blue" 
    style="font-size: medium; font-weight: bold; color: #FFFFFF; height: 23px;">
        Paso 2 (Elije tu nombre de usuario y contraseña)<br />
</p>
    <p align="center">
    <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="#003300" 
        Text="Usuario: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtuser" runat="server" CssClass="round full-width-input" 
        Height="16px" Width="195px" ontextchanged="txtuser_TextChanged"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtuser" ErrorMessage="*"></asp:RequiredFieldValidator>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="100" ontick="Timer1_Tick">
    </asp:Timer>
</p>
<p align="center">
    <asp:Label ID="Label2" runat="server" Font-Size="Medium" ForeColor="#003300" 
        Text="Contraseña:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtpass" runat="server" CssClass="round full-width-input" 
        Height="16px" Width="195px" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtpass" ErrorMessage="*"></asp:RequiredFieldValidator>
</p>
<p align="center">
    <asp:Label ID="Label3" runat="server" Font-Size="Medium" ForeColor="#003300" 
        Text="Repetir Contra:"></asp:Label>
&nbsp;&nbsp;
    <asp:TextBox ID="txtpass2" runat="server" CssClass="round full-width-input" 
        Height="16px" Width="195px" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtpass2" ErrorMessage="*"></asp:RequiredFieldValidator>
</p>
<p align="center">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" CssClass="button" Text="Guardar Datos" 
            Width="170px" onclick="Button1_Click" />
</p>
    <p align="center">
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="txtpass" ControlToValidate="txtpass2" 
            ErrorMessage="Comparacion de contraseñas INCORRECTA"></asp:CompareValidator>
</p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
  <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
</Triggers>
        <ContentTemplate>
            &nbsp;<br /> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblverificar_u" runat="server"></asp:Label>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
