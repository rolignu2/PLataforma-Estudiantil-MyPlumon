<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProyectoAsp.Formulario_web11" %>
<%@ MasterType VirtualPath="~/Principal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
   
   <div class="page-full-width cf">
    <p>
        &nbsp;</p>
<p align="center">
    <asp:Label ID="lblbienvenida" runat="server" CssClass="alt-label" 
        Font-Bold="True" Font-Size="Larger" Text="BIENVENIDO  ! "></asp:Label>
    </p>
    <p align="center">
        &nbsp;</p>


     <div class="side-menu fl">
				
				<h3>Eventos del usuario</h3>
				<ul>
                    <li><a href="#" runat="server" id="lblfecha">.........</a></li>
					<li><a href="#" runat="server" id="lblhora">...........</a></li>
					<li><a href="#" runat="server" id="modulo">..............</a></li>
					<li><a href="#" runat="server" id="rango" >............</a></li>
				</ul>
				
			</div> <!-- final dentro -->

            <div class="side-content fr">
			
				<div class="content-module">
				
					<div class="content-module-heading cf">
					
						<h3 class="fl">My Plumon Plataforma virtual para el aprendizaje</h3>
						<span class="fr expand-collapse-text">Edicion Beta</span>
						<span class="fr expand-collapse-text initial-expand">version 0.1</span>
					
					</div> <!-- end content-module-heading -->
					
					
					<div class="content-module-main" runat="server" id="div_tabla">
					
						
					
					</div> <!-- end content-module-main -->
				
				</div> <!-- end content-module -->


             </div><!--final del full with-->
       
<p>
    <br />
</p>
</asp:Content>
