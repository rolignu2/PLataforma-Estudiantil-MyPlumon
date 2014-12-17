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

            //verificamos la sesion si esta activa en dado caso no exista ira al inicio (LOGIN)
            var id = Session["id_user"];
            if (id == null)
            {
                Response.Redirect("Login.aspx", true);
                return;
            }
           
            //verificamos el estado por seguridad , si esta activo o no  0 inactivo , 1 activo en dado caso este inactivo redirecciona a otra pagina
            string estado = Session["estado"].ToString();
            bool estatus = Seguridad.UsuarioActivo(Convert.ToInt32(estado));
            if (estatus == false)
                Response.Redirect("Inactivo.aspx" , true);

            //verificamos los privilegios , este codigo es muy importante ya que aca separa del usuario , maestro o administrador
            string p = Session["perfil"].ToString();
            int perfil = Convert.ToInt32(p);
            switch (perfil)
            {
                case 0:
                    ((Label)Master.FindControl("lbltab1")).Text = "Cursos Activos";
                    ((Label)Master.FindControl("lbltab2")).Text = "Todos Los cursos";
                    ((Label)Master.FindControl("lbltab3")).Text = "Cursos Cerrados";
                    Master.SetUsuario_data();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            } //fin codigo verificacion perfil

        }
    }
}