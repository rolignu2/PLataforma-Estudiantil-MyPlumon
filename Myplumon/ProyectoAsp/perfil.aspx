<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="ProyectoAsp.Formulario_web113" %>
<%@ MasterType VirtualPath="~/Principal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <p>
        <br />
    </p>


    	<div class="page-full-width cf">

    	<div class="content-module-heading cf">
					
						<h3 class="fl">PERFIL </h3> <h3 runat="server" id="nombreperfil"> </h3>
					</div> <!-- end content-module-heading -->
					
					
					<div class="content-module-main cf">
				
						<div class="half-size-column fl">
						
							<form action="#">
							
								<fieldset>
								
									
								</fieldset>
							
							</form>
						
						</div> 
						
						<div class="half-size-column fr">
						
							<form action="#">
							
								<fieldset>
								
								
									
								</fieldset>
							
							</form>
							
						</div> 
				
					</div> 
					
	
				<div class="half-size-column fl">
	
					<div class="content-module">
					
						<div class="content-module-heading cf">
						
							<h3 class="fl">DATOS PERSONALES</h3>
						 <a class="button" id="editar_perfil" runat="server" href="perfil_edit.aspx"></a>
                         <a class="button" id="enviar_mensaje" runat="server" href="mensaje.aspx"></a>
						</div> <!-- end content-module-heading -->
						
						
						<div class="content-module-main" runat="server" id="datospersonales_formulario" >
					
					
					
						</div> <!-- end content-module-main -->
					
					</div> <!-- end content-module -->
	
				</div>

				<div class="half-size-column fr">

				<div class="content-module">
				
					<div class="content-module-heading cf">
					
						<h3 class="fl">DATOS SOCIALES</h3>
					
					</div> <!-- end content-module-heading -->
					
					
					<div class="content-module-main cf" runat="server" id="FormularioSocial" >


					</div> <!-- end content-module-main -->
				
				</div> <!-- end content-module -->
     


			</div>

		

	
	

</asp:Content>
