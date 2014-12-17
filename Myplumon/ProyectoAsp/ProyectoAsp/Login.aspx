<%@ Page Title="" Language="C#" MasterPageFile="~/Login_out.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoAsp.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="content" align = "center">
	
		

				<p>
					&nbsp;</p>
                <p>
					&nbsp;</p>
	
		

				<p>
					<label for="login-username">Usuario o Correo</label></p>
                <p>
					&nbsp;<asp:TextBox ID="txtuser" runat="server" 
                        CssClass="round full-width-input" Width="538px"></asp:TextBox>
				</p>

				<p>
					<label for="login-password">Contraseña</label>

					 <asp:TextBox ID="txtpass" TextMode="Password" runat="server" 
                        CssClass="round full-width-input" Width="538px"></asp:TextBox>
				</p>
				
				<p><a href="Recuperar.aspx">¿Olvido su contraseña?</a></p>
				
				<asp:Button ID="cmdEntrar" runat="server" Text="Entrar" 
                    CssClass="button round blue image-right ic-right-arrow" 
                    onclick="cmdEntrar_Click" Width="123px" />


			    <br />
                <br />


			<br/><div class="information-box round">
                    <asp:Label ID="lblnoticias" runat="server" Text="Noticias:"></asp:Label>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtuser" ErrorMessage="Usuario o E-mail Requeridos" 
                        ForeColor="#996600"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtpass" ErrorMessage="Contraseña Requerida" 
                        ForeColor="#996633"></asp:RequiredFieldValidator>
                </div>
		
	</div>
</asp:Content>
