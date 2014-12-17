using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoAsp.Clases;

namespace ProyectoAsp
{
    public partial class Formulario_web111 : System.Web.UI.Page
    {

        static string curso_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            //verificamos la sesion si esta activa en dado caso no exista ira al inicio (LOGIN)
            try
            {
                var sesion_c = Session.Count;
                if (sesion_c <= 0)
                {
                    Response.Redirect("Login.aspx", true);
                    return;
                }
            }
            catch { }


            curso_id = Request.QueryString["id"].ToString();
            curso_id = Encriptador.Desencriptar_Md5(curso_id);
            string p = Session["perfil"].ToString();
            int perfil = Convert.ToInt32(p);

            if(!(perfil >= 1))
            {
                Response.Redirect("Index.aspx" ,true);
            }


        }

        protected void cmdcrear_Click(object sender, EventArgs e)
        {

            Tutor Tutor = new Tutor();
            bool ok = Tutor.CrearPeriodo(curso_id, txtnombre.Text, txtactivo.Checked);
            if (!ok)
            {
                lblerror.InnerText = "Error al procesar la solicitud de agregar periodo puede que el servidor este ocupado";
            }
            else
            {
                lblerror.InnerHtml = "periodo agregado con exito <br /><a href='curso.aspx?id=" + Request.QueryString["id"].ToString() + "'>Regresar al curso</a>";
            }
        }

    }
}