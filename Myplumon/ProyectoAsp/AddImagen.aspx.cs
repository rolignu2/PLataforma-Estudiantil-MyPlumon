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
            imgvista.Visible = false;
        }

        protected void cmdlate_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx", true);
        }

        protected void cmdguardar_Click(object sender, EventArgs e)
        {
            if (archivoImagen.PostedFile != null && archivoImagen.PostedFile.ContentLength > 0)
            {
                
                HttpPostedFile ImgFile = archivoImagen.PostedFile;

                if (ImgFile != null)
                {
                    int size = ImgFile.ContentLength;
                    if (size > 1000000)
                    {
                        Response.Write("<SCRIPT>alert('Hubo un error en el servidor al momento de subir una imagen pueda que la iamgen es mayor a 1 megabyte');</SCRIPT>");
                        return;
                    }
                    else
                    {
                        while (true)
                        {
                            try
                            {
                                string[] type = ImgFile.ContentType.Split('/');
                                string id_file = new Random(DateTime.Now.Millisecond).Next().ToString() + "_" + new Random(DateTime.Now.Millisecond).Next().ToString() + new Random(DateTime.Now.Millisecond).Next().ToString() + "." + type[1];
                                string save_file = Path.Combine(Server.MapPath(@"~/images/avatar"), id_file);
                                if (System.IO.File.Exists(save_file) == false)
                                {
                                    ImgFile.SaveAs(save_file);
                                    usuario user = new usuario();
                                    string resultado = user.CambiarImagen(id_file, Session["id_user"].ToString(), Server.MapPath(@"~/App_GlobalResources/avatar"));
                                    if (resultado != null)
                                        Session["imagen"] = resultado;
                                    break;
                                }
                              
                            }
                            catch (Exception ex)
                            {
                                //clase de log
                            }
                            finally
                            {
                                Response.Redirect("index.aspx");
                            }
                        }
                        
                    }
                }
                else
                {
                    Response.Write("<SCRIPT>alert('Hubo un error en el servidor al momento de subir una imagen');</SCRIPT>");
                    Response.Redirect("index.aspx");
                }
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