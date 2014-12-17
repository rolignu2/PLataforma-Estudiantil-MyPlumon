using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoAsp.Clases;

namespace ProyectoAsp
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var data_name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        }

        protected void cmdEntrar_Click(object sender, EventArgs e)
        {
            Logueo Log = new Logueo(txtuser.Text, txtpass.Text);
            bool Result = Log.Loguear();
            if (Result == true)
            {
                DatosEstaticos.Fecha = DateTime.Now.ToShortDateString();
                DatosEstaticos.Hora = DateTime.Now.ToShortTimeString();
                string imagen = Session["imagen"].ToString();
                if (imagen == "" || imagen == null || imagen == "NULL" || imagen == " NULL")
                {
                    Response.Redirect("AddImagen.aspx");
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
            else if (Result == false)
            {
                lblnoticias.ForeColor = System.Drawing.Color.Red;
                lblnoticias.Text = "Opps!! , Error al momento de iniciar sesion\nPuede que sea el usuario o contraseña incorrectas";
            }
            else
            {
                lblnoticias.ForeColor = System.Drawing.Color.Brown;
                lblnoticias.Text = "Opps!! , el servidor no responde";
            }

        }
    }
}