<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="periodo.aspx.cs" Inherits="ProyectoAsp.Formulario_web111" %>
<%@ MasterType VirtualPath="~/Principal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <div class="page-full-width cf">
    	<div class="content-module-main" align="center">
						
							<h1>Creacion de un periodo ...</h1>
							<p>un periodo es la forma mas simple de llevar tus datos ordenadamente...</p>
							
							<div class="stripe-separator"><!-- --></div>
						
							<h3>Datos basicos ...</h3>
                            <br />
                            <h4>Nombre del periodo:   </h4>  
                            <asp:TextBox ID="txtnombre" runat="server" 
                                    class="round default-width-input" Height="18px" Width="200px" 
                                MaxLength="40"></asp:TextBox>

                            <h4>Estado del periodo :   </h4>  

							<div class="stripe-separator"><!-- -->
                                <asp:CheckBox ID="txtactivo" runat="server" 
                                    Text="Activado/Desactivado" />
                            </div>

							<div class="stripe-separator"><!-- --></div>
							
							<asp:Button ID="cmdcrear" runat="server" Text="Crear Periodo" 
                                onclick="cmdcrear_Click" />
							
						    <br />
                            <br />
                            <div align="center" class="warning-box">
							<p><b runat="server" id="lblerror" ></b></p>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="Se necesita un nombre de periodo" ControlToValidate="txtnombre"></asp:RequiredFieldValidator>
                                 <br />
                            </div>
						</div> 
    
       
					</div> 
                    </div>
				</div> 
</asp:Content>
