<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="curso.aspx.cs" Inherits="ProyectoAsp.Formulario_web19" %>
<%@ MasterType VirtualPath="~/Principal.Master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
   <div class="page-full-width cf">

			<div class="side-menu fl" runat="server" id="MenuContenido">
				
				<h3>Opciones del tutor</h3>
				<ul>
					<li><a href="#">menu1</a></li>
					<li><a href="#" >menu2</a></li>
					<li><a href="#" >menu3</a></li>
					<li><a href="#" >menu4</a></li>
				</ul>

                <br />
                <h3>Opciones del tutor</h3>
				<ul>
					<li><a href="#">menu1</a></li>
					<li><a href="#" >menu2</a></li>
					<li><a href="#" >menu3</a></li>
					<li><a href="#" >menu4</a></li>
				</ul>
				
			</div> <!-- end side-menu -->
			
			<div class="side-content fr">
			
				<div class="half-size-column fl">
				
					<div class="content-module">
					
						<div class="content-module-heading cf">
						
							<h3 class="fl" runat="server" id="titulo_periodo" >....</h3>
							<span class="fr expand-collapse-text" runat="server" id="estado_periodo" >...</span>
                             <asp:LinkButton ID="linkeliminar" ToolTip="Eliminar periodo" 
                                CssClass="fr button blue text-upper small-button" runat="server" 
                                onclick="linkeliminar_Click">Eliminar</asp:LinkButton>
						</div> <!-- end content-module-heading -->
						
						
						<div class="content-module-main" runat="server" id="tablon_periodo">
						
						
							
						</div> <!-- end content-module-main -->
					
					</div> <!-- end content-module -->
				
				</div> <!--end half-size-column-->

				<div class="half-size-column fr">
				
					<div class="content-module">
					
						<div class="content-module-heading cf">
						
							<h3 class="fl">DEL LADO DEL TUTOR IRAN UNAS COSITAS :3</h3>
							<span class="fr expand-collapse-text">FALTA</span>
							<span class="fr expand-collapse-text initial-expand">FALTA</span>
						
						</div> <!-- end content-module-heading -->
						
						
						<div class="content-module-main cf">
					
							<div class="half-size-column fl">
						
								<h2 class="text-upper">Lista de orden simple</h2>
								
								<ol>
									<li>R</li>
									<li>MY PIZARRON</li>
									<li>CHINO GAY</li>
									<li>HOLA</li>
								</ol>
						
							</div>
							
							<div class="half-size-column fr">
								
								<h2 class="text-upper">PROGRAMANDO ESPERE ....</h2>
								
								<ol>
									<li><a href="#">LI</a></li>
									<li><a href="#">L2</a></li>
									<li><a href="#">L1255544</a></li>
								</ol>
							
							</div>
							
						</div> <!-- end content-module-main -->
						
					</div> <!-- end content-module -->

					<div class="content-module">
					
						<div class="content-module-heading cf">
						
							<h3 class="fl">LISTA SIN ORDEN ALGUNO</h3>
							<span class="fr expand-collapse-text">Programan.do</span>
							<span class="fr expand-collapse-text initial-expand">hola</span>
						
						</div> <!-- end content-module-heading -->
						
						
						<div class="content-module-main cf">
					
							<div class="half-size-column fl">
						
								<h2 class="text-upper">........</h2>
								
								<ul class="regular-ul">
									<li>........</li>
									<li>........</li>
									<li>........</li>
									<li>........</li>
								</ul>
								
								<p>especificar <code>class="regular-ul"</code> yo</p>
								
							</div>
							
							<div class="half-size-column fr">
								
								<h2 class="text-upper">..........</h2>
								
								<ul class="custom-ul">
									<li><a href="#">........</a></li>
									<li><a href="#">........</a></li>
									<li><a href="#">........</a></li>
								</ul>

								<p>........<code>class="custom-ul"</code> ........</p>

							</div>
							
						</div> <!-- end content-module-main -->
						
					</div> <!-- end content-module -->

				</div> <!--end half-size-column-->
	
			</div> <!-- end side-content -->
		
		</div> <!-- end full-width -->
			

	
	

</asp:Content>
