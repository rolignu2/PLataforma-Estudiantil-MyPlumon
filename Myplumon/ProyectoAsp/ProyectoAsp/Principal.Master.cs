using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAsp
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        
        }


        /// <summary>
        /// Obtiene los datos del usuario con la sesion actual 
        /// no devuelve valor
        /// </summary>
        public void SetUsuario_data()
        {
            try
            {
                //obteniendo el nombre del usuario
                string Nombre = Session["nombre"].ToString() + " " + Session["apellido"].ToString();
                lblNombreUsuario.Text = Nombre;
                //obteniendo la imagen del susuario (claro que si existe)
                string Imagen = Session["imagen"].ToString();
                if (Imagen == null || Imagen == " NULL" || Imagen == "NULL")
                    ImgUser.Visible = false;
                else
                {
                    ImgUser.Visible = true;
                    ImgUser.ImageUrl = "~/";
                }
                //

            }
            catch { }
        }
  
    }
}