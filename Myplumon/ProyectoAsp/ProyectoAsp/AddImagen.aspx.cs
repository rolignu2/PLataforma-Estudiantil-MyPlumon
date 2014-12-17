using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ProyectoAsp.Clases;


namespace ProyectoAsp
{
    public partial class Formulario_web18 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string directorio = "~/images/user.jpg";
                imagenavatar.ImageUrl = directorio;
            }
            catch
            {
            }
        }

        protected void cmdlate_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx", true);
        }

        protected void cmdguardar_Click(object sender, EventArgs e)
        {
            if (archivoImagen.PostedFile != null && archivoImagen.PostedFile.ContentLength > 0)
            {
                String username = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                HttpPostedFile ImgFile = archivoImagen.PostedFile;
                ImgFile.SaveAs(Server.MapPath(@"~/App_Data/avatar"));

                    //Response.Write("<SCRIPT>alert('Hubo un error en el servidor al momento de subir una imagen');</SCRIPT>");
                
                Response.Redirect("index.aspx");
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            
        }

        protected void archivoImagen_PreRender(object sender, EventArgs e)
        {
           
        }

    }
}