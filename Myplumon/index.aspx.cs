using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoAsp.Clases;
using MySql.Data.MySqlClient;
using System.Threading;

namespace ProyectoAsp
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Session["id_user"];
            if (id == null)
            {
                Response.Redirect("Login.aspx", true);
                return;
            }
           
            string estado = Session["estado"].ToString();
            bool estatus = Seguridad.UsuarioActivo(Convert.ToInt32(estado));
            if (estatus == false)
                Response.Redirect("Inactivo.aspx" , true);

            string p = Session["perfil"].ToString();
            int perfil = Convert.ToInt32(p);
            switch (perfil)
            {
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }

        }
    }
}