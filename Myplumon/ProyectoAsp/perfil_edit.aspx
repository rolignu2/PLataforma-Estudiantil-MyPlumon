<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="perfil_edit.aspx.cs" Inherits="ProyectoAsp.Formulario_web114" TraceMode="SortByCategory" Debug="true" %>
<%@ MasterType VirtualPath="~/Principal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <p>
        <br />
    </p>
    
    	<div class="page-full-width cf">

    	<div class="content-module-heading cf">
					
						<h3 class="fl">(EDITA TU PERFIL)       </h3> <h3 runat="server" id="nombreperfil"></h3>
					</div> <!-- end content-module-heading -->
					
					
					<div class="content-module-main cf" id="cmd_">
				
						<div class="half-size-column fl">
					
							
								<fieldset>
								
									<p>
										<label for="simple-input">Nombre de usuario</label>
                                        <asp:TextBox ID="txtnombre" runat="server" CssClass="round default-width-input"></asp:TextBox>
									</p>
									
									<p>
										<label for="full-width-input">Apellido</label>
                                        <asp:TextBox ID="txtapellido" runat="server" CssClass="round default-width-input"></asp:TextBox>
										<em id="Notificacion_usuario">Tu nombre y apellido</em>								
									</p>
	
									<p>
										&nbsp;<label for="another-simple-input" >Tu alias (apodo)</label></p>
                                    <p>
                                            <asp:TextBox ID="txtalias" runat="server" 
                                            CssClass="round default-width-input" AutoPostBack="True" 
                                                ontextchanged="txtalias_TextChanged" ></asp:TextBox>
                                            </p>
	
									<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_advertencia_alias" runat="server" CssClass="error-box" 
                                                Text="Advertencia"></asp:Label>
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="txtalias" EventName="TextChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <p>
										<em>Tu alias es unico por lo tanto no debe estar registrado</em>								
									</p>
	
									<p >
										<label for="another-simple-input">Correo Electronico (E-mail)</label></p>
                                    <p >

                                            <asp:TextBox ID="txtcorreo" runat="server" 
                                            CssClass="round default-width-input" 
                                            ontextchanged="txtcorreo_TextChanged" AutoPostBack="True" ></asp:TextBox>
                                            </p>
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
         
                                        <ContentTemplate>
                                            <asp:Label ID="lbl_advertencia_alias0" runat="server" CssClass="error-box" 
                                                Text="Advertencia"></asp:Label>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                ControlToValidate="txtcorreo" CssClass="error-box" 
                                                ErrorMessage="Correo invalido" 
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="txtcorreo" EventName="TextChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <p>
										<em>Cuando te registras tienes un correo, en dado caso deseas cambiarlo que no este registrado</em>								
									</p>

                                    	<p>
									<label>Fecha de cumpleaños</label>
&nbsp;&nbsp; Año<asp:DropDownList ID="dyear" runat="server" 
            CssClass="default-width-input" Height="32px" Width="70px">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
&nbsp;Mes<asp:DropDownList ID="dmonth" runat="server" Height="32px" Width="71px">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
&nbsp;Dia<asp:DropDownList ID="ddate" runat="server" Height="32px" Width="72px">
            <asp:ListItem></asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lblfecha" runat="server"></asp:Label>
        <em>En dado caso te equivocastes en tu cumpleaños puedes correjirlo</em>
									</p>
									
								</fieldset>
							
					
						
						</div> <!-- end half-size-column -->
						
						<div class="half-size-column fr">
						
							
								<fieldset>

									<p>
										<label>Facebook</label>
										<asp:TextBox ID="txtfacebook" runat="server" CssClass="round default-width-input"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                            ControlToValidate="txtfacebook" CssClass="error-box" 
                                            ErrorMessage="Link Invalido" 
                                            ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                                        <em id="em_fcebook" runat="server">.....................................</em>
									</p>
	
									<p>
										<label>Twitter</label>
										<asp:TextBox ID="txttwitter" runat="server" 
                                            CssClass="round default-width-input"></asp:TextBox>
                                        <em id="em_twitter" runat="server">.....................................</em>
									</p>
	
									<p class="form-error-input">
										<label for="dropdown-actions">Institucion</label>
	                                     <asp:DropDownList ID="comboInstitucion" runat="server" Height="21px"  Width="206px"></asp:DropDownList>
                                         <em>Puedes cambiar tu institucion, en dado caso sea necesario</em>	
									</p>

                                    <p class="form-error-input">
										<label for="dropdown-actions">Sexo</label>
	                                     <asp:DropDownList ID="combo_sexo" runat="server" Height="21px"  Width="206px">
                                             <asp:ListItem>Masculino</asp:ListItem>
                                             <asp:ListItem>Femenino</asp:ListItem>
                                        </asp:DropDownList>
                                         <em>Si te has cambiado de genero en fin puedes cambiarlo tambien de tu perfil</em></p>
                                    <p class="dropdown-actions">
										PAIS</p>
                                    <p class="form-error-input">
        <asp:DropDownList ID="combopais" runat="server" Height="21px" 
            Width="206px">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>El salvador</asp:ListItem>
            <asp:ListItem>Guatemala</asp:ListItem>
            <asp:ListItem>Honduras</asp:ListItem>
            <asp:ListItem>Nicaragua</asp:ListItem>
        </asp:DropDownList>
        &nbsp;</p>
	
	
									<div class="stripe-separator"><!--  --></div>
                                    <p>
                                            <asp:Button ID="CmdGuardar" runat="server" Text="Guardar Cambios"  
                                                CssClass="round blue ic-right-arrow" onclick="CmdGuardar_Click" 
                                                ValidationGroup="CmdGuardar"  />
                                    </p>
                                    <p align="center">
                                            <asp:Label ID="lblerror" runat="server" CssClass="error-box" Text="Label"></asp:Label>
                                    </p>
                                    <p>
                                            &nbsp;</p>
								</fieldset>

						</div> <!-- end half-size-column -->
				
					</div> <!-- end content-module-main -->
					
	
				<div class="half-size-column fl">
	
					<div class="content-module">
					
						<div class="content-module-heading cf">
						
							&nbsp;
						
						</div> <!-- end content-module-heading -->
						
						
						<div class="content-module-main">
					
							<div class="warning-box round">
                                <label>Cambia Tu imagen o avatar o avatar</label>
                                <asp:Image ID="Image1" runat="server" Height="147px" Width="174px" />
                                <asp:FileUpload ID="FileUpload1" runat="server" Height="26px" Width="274px" />
                            </div>
                          
					
						</div> <!-- end content-module-main -->
					
					</div> <!-- end content-module -->
	
				</div>

				<div class="half-size-column fr">


				<div class="content-module">
				
					<div class="content-module-heading cf">
					
						&nbsp;
					
					</div> <!-- end content-module-heading -->
					
					
					<div class="content-module-main cf">
                    <label>Cambia tu contraseña de forma rapida</label>

                     <p>
										<label>Contraseña Actual</label>
										<asp:TextBox ID="txtcontra_actual" runat="server" 
                                            CssClass="round default-width-input" TextMode="Password"></asp:TextBox>
									    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtcontra_actual" CssClass="error-box" 
                                            ErrorMessage="Se encesita este campo"></asp:RequiredFieldValidator>
									</p>
				            <p>
										<label>Nueva Contraseña</label>
										<asp:TextBox ID="txtcontra" runat="server" CssClass="round default-width-input" 
                                            TextMode="Password"></asp:TextBox>
									    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="txtcontra" CssClass="error-box" 
                                            ErrorMessage="Se encesita este campo"></asp:RequiredFieldValidator>
									</p>
	
									<p>
										<label>Repetir Contraseña</label>
										<asp:TextBox ID="txtrep_contra" runat="server" 
                                            CssClass="round default-width-input" TextMode="Password"></asp:TextBox>
									    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="txtrep_contra" CssClass="error-box" 
                                            ErrorMessage="Se encesita este campo"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                            ControlToCompare="txtcontra" ControlToValidate="txtrep_contra" 
                                            CssClass="error-box" ErrorMessage="Nueva contraseña incorrecta"></asp:CompareValidator>
									</p>

				          <p align="center">
                                <asp:Button ID="cmd_imagen" runat="server" Text="Guardar Contraseña" 
                                    CssClass="round blue ic-right-arrow" onclick="cmd_imagen_Click" />
                            </p>
                        <p align="center">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtcontra" CssClass="warning-box" 
                                    ErrorMessage="debe contener 2 digitos ; 8 caracteres minimo" 
                                    ValidationExpression="^(?=(?:.*?\d){2})(?=(?:.*?[A-Za-z]){2})\w{8,}$"></asp:RegularExpressionValidator>
                            </p>
					</div> <!-- end content-module-main -->
				</div> <!-- end content-module -->
              
			</div>

		
			</div> <!-- end side-content -->
</asp:Content>
