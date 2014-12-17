using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoAsp.Clases;

namespace ProyectoAsp
{
    public partial class Formulario_web113 : System.Web.UI.Page
    {

        string id_perfil = "";
        string id_usuario = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                var sesion_c = Session.Count;
                if (sesion_c <= 0)
                {
                    Response.Redirect("Login.aspx", true);
                    return;
                }
                if (Request.QueryString.Count == 0)
                {
                    nombreperfil.InnerHtml = "<b>" + Session["nombre"] + " " + Session["apellido"] + "</b>";
                    id_perfil = Session["id_user"].ToString();
                    MostrarPerfil(true);
                }
                else
                {
                    Conexion conn = new Conexion();

                    try
                    {
                        id_perfil = Request.QueryString["id_p"];
                        conn.IniciarConexion();
                        List<object> consulta = conn.Get_Consulta("select nombre , apellido from user where id_user like '" + id_perfil + "'");
                        object[] obj = (object[])consulta[0];
                        nombreperfil.InnerHtml = "<b>" + obj[0] + " " + obj[1] + "</b>";
                        conn.CerrarConexion();
                        MostrarPerfil(false);
                    }
                    catch(Exception ex)
                    {
                        conn.CerrarConexion();
                        Log.Set_Log_Error(ex.Message, "perfil", id_perfil);
                    }
                }
                id_usuario = id_perfil;
                Configuracion_master();
            }
            catch { }


        }

        private void MostrarPerfil(bool perfil_usuario)
        {

            Conexion conn = new Conexion();
            Cssclass cssclas = new Cssclass();
           
            conn.IniciarConexion();
            string sql = "Select * from user where id_user like '" + id_perfil + "'";

            try
            {
                List<object> lista_datos = conn.Get_Consulta(sql);

                //0 y 11 no
                //4 , 6 , 7 y 12 colocarlos en otro lado 12= imagen y 4 es correo : 6 y 7 son redes sociales
                if (lista_datos.Count >= 2)
                    goto fin;
                else if (lista_datos.Count == 0)
                    goto fin;

                object[] obj = (object[]) lista_datos[0];
                string[] labesl = new string[] { "" , "NOMBRE " 
                    , "APELLIDO " , "ALIAS " , "E-MAIL" , "FECHA DE CUMPLEAÑOS " 
                    , "" , "" , "INSTITUCION " ,  "SEXO " , "PAIS " , "" , "" , "INICIO EL "};

                datospersonales_formulario.InnerHtml = "";
                for(int i = 1 ; i <= obj.Length - 1 ; i++)
                {
                    if ( i == 6
                        || i == 7 || i == 12 || i == 11)
                    {
                        continue;
                    }
                    else
                    {
                        if (i == 5)
                        {
                            DateTime fecha_cumple = (DateTime) obj[i];
                            DateTime fecha_actual = DateTime.Now;
                            int edad = fecha_actual.Date.Year - fecha_cumple.Date.Year;
                           
                            datospersonales_formulario.InnerHtml += "<div class='" + cssclas.aleatorio() + "'> "
                            + labesl[i] + ": " + obj[i].ToString().ToUpper() + "        ( EDAD ACTUAL: " + edad + " AÑOS )" +  "</div>";
                        }
                        else
                        {
                            datospersonales_formulario.InnerHtml += "<div class='" + cssclas.aleatorio() + "'> "
                              + labesl[i] + ": " + obj[i].ToString().ToUpper() + "</div>";
                        }
                    }
                }

                string imagen_url = Seguridad.HttpUrl + "/images/avatar/" + obj[12];
                FormularioSocial.InnerHtml = "";
                FormularioSocial.InnerHtml += "<table><tr><td rowspan='4'> <img src='" + imagen_url + "' height='200' width='200'/></td>";
               
                if (obj[6].ToString() != null && obj[6].ToString() != "")
                {
                    FormularioSocial.InnerHtml += "<td><div class='fb-follow' data-href='"
                        + obj[6]
                        + "' data-width='The pixel width of the plugin' data-height='The pixel height of the plugin' data-colorscheme='light' data-layout='standard' data-show-faces='true'></div></td>";
                    FormularioSocial.InnerHtml += "<tr><td><div class='fb-like' data-href='" + obj[6]
                      + "' data-width='The pixel width of the plugin' data-height='The pixel height of the plugin' data-colorscheme='light' data-layout='standard' data-action='like' data-show-faces='true' data-send='false'></div></td></table>";

                    FormularioSocial.InnerHtml += "<div align='center' class='fb-comments' data-href='"
                       + obj[6].ToString() + "' data-colorscheme='00' data-numposts='5' data-width='500'></div></td>";

                }

                if (obj[7].ToString() != "" && obj[6].ToString() != "")
                {
                    var comilla = '"';
                    FormularioSocial.InnerHtml += "<div class='divspoiler'> <input type='button' value='Mostrar Tweets' onclick=" + comilla + "if (this.parentNode.nextSibling.childNodes[0].style.display != '') { this.parentNode.nextSibling.childNodes[0].style.display = ''; this.value = 'Ocultar Tweets'; } else { this.parentNode.nextSibling.childNodes[0].style.display = 'none'; this.value = 'Mostrar Tweets'; }" + comilla + " />"
                    + "</div><div><div class='spoiler' style='display: none;'>" 
                    + "<a href='https://twitter.com/intent/tweet?screen_name=" + obj[7].ToString() +  "' class='twitter-mention-button' data-lang='es' data-related='" + obj[7].ToString() + "'>Tweet to @" +  obj[7].ToString() + "</a><script>    !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } } (document, 'script', 'twitter-wjs');</script>"
                    +"</div></div>";
                }
                else if (obj[7].ToString() != "" && obj[6].ToString() == "")
                {
                    FormularioSocial.InnerHtml += "<tr><td><a href='https://twitter.com/intent/tweet?screen_name=" + obj[7].ToString() +  "' class='twitter-mention-button' data-lang='es' data-related='" + obj[7].ToString() + "'>Tweet to @" +  obj[7].ToString() + "</a><script>    !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } } (document, 'script', 'twitter-wjs');</script></td></table>";
                }

                if(obj[7].ToString() == "" && obj[6].ToString() == "")
                {
                    FormularioSocial.InnerHtml += "<td><div class='" + new Cssclass().advertencia + "'>Lamentamos no mostrarle los datos de la red social, pero al parecer no tiene afiliado facebook o twitter </div></td></tr></table>";
                }

                if (perfil_usuario == true)
                {
                    editar_perfil.InnerText = "Editar perfil";
                }
                else
                {
                    enviar_mensaje.InnerText = "Enviar un mensaje ";
                    enviar_mensaje.HRef = "mensaje.aspx?id=" + id_perfil; 
                }
                    

            }
            catch (Exception ex)
            {
                try
                {
                    Log.Set_Log_Error(ex.Message, "perfil", id_perfil);
                }
                catch { }
            }

        fin:
            conn.CerrarConexion();
            return;
        }

        //region de funciones estandares
        #region Funciones_Estandares

        private void Get_mensaje()
        {
            try
            {
                Conexion conn = new Conexion();
                conn.IniciarConexion();
                string sql = " SELECT COUNT(id_user) FROM mensajeria WHERE id_user like '" + id_usuario + "'  and leido=0";
                List<object> Numero_mensaje = conn.Get_Consulta(sql);
                conn.CerrarConexion();
                object[] obj = (object[])Numero_mensaje[0];
                Master.SetMensajeria_estudiante(obj[0].ToString(), "mensajeria.aspx?id=" + id_usuario);
            }
            catch (Exception ex)
            {
                Log.Set_Log_Error(ex.Message, "INDEX.ASPX", id_usuario);
            }
        }

        private void Configuracion_master()
        {

            string p = Session["perfil"].ToString();
            int perfil = Convert.ToInt32(p);
            switch (perfil)
            {
                case 0:
                    ((Label)Master.FindControl("lbltab1")).Text = "Cursos Activos";
                    ((Label)Master.FindControl("lbltab2")).Text = "Todos Los cursos";
                    ((Label)Master.FindControl("lbltab3")).Text = "Cursos Cerrados";
                    Master.SetEstudiante();
                    break;
                case 1:
                    ((Label)Master.FindControl("lbltab1")).Text = "NULL";
                    ((Label)Master.FindControl("lbltab2")).Text = "Crear Nuevo Cuso";
                    ((Label)Master.FindControl("lbltab3")).Text = "Ver Mas";
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            //muestra los periodos por medio de los perfiles 
            // ejemplo : si el perfil es el tutor muestra las herramientas del tutor por ese periodo 
            // si el perfil es estudiante  entonces muestra el periodo sin ninguna manipulacion
            Master.SetUsuario_data();
            Get_mensaje();
        }

        #endregion

    }
}