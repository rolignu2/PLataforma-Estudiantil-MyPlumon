using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoAsp.Clases;
using MySql.Data.MySqlClient;
using System.Data;


namespace ProyectoAsp
{
    public partial class Formulario_web19 : System.Web.UI.Page
    {

        private static string curso_id = "";
        private static string encript_curso_id = "";
        private static string periodo_id = "";
        private static string id_usuario = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Configuracion_master();
        }

    
        //ayuda html 

        /*<h3>Opciones del tutor</h3>
            <ul>
                <li><a href="#">menu1</a></li>
                <li><a href="#" >menu2</a></li>
                <li><a href="#" >menu3</a></li>
                <li><a href="#" >menu4</a></li>
            </ul> */
        private void Configuracion_Tutor()
        {
            try
            {
                Tutor tutor = new Tutor();
                MenuContenido.InnerHtml = "<h3>Opciones del tutor</h3>";
                MenuContenido.InnerHtml += "<ul>" + "<li><a href='periodo.aspx?id=" + Request.QueryString["id"].ToString() + "'>Agregar Periodo</a></li>"
                                + "<li><a href='editar_curso.aspx?id=" + Request.QueryString["id"].ToString() + "'>Editar Curso</a></li>"
                                + "<li><a href='eliminar_curso?id=" + Request.QueryString["id"].ToString() + "'>Eliminar Curso</a></li>"
                                + "<li><a href='periodo.aspx?" + Request.QueryString["id"].ToString() + "'></a></li>"
                                + "<li><a href='#'></a></li></ul><br />";
                List<object> lista_periodo = tutor.Get_Periodos(curso_id);
                if (lista_periodo.Count >= 1)
                    MenuContenido.InnerHtml += "<h3>Periodos</h3><ul>";
                else
                    MenuContenido.InnerHtml += "<h3>No existen periodos</h3><ul>";
                foreach (object lista in lista_periodo)
                {
                    object A = lista;
                    object[] B = (object[])A;
                    string[] Datos_periodo = Array.ConvertAll(B, p => (p ?? String.Empty).ToString());
                    if(Datos_periodo[2] == "1")
                         MenuContenido.InnerHtml += "<li><a href='curso.aspx?id="
                        + encript_curso_id + "&id_periodo=" + Datos_periodo[0].ToString() + "'>" + Datos_periodo[1] + "</a></li>";
                    else
                        MenuContenido.InnerHtml += "<li><a href='curso.aspx?id="
                        + encript_curso_id + "&id_periodo=" + Datos_periodo[0].ToString() + "'>" + Datos_periodo[1] + " (No activo) </a></li>";
                }
                MenuContenido.InnerHtml += "</ul>";
            }
            catch (Exception ex)
            {
                Log.Set_Log_Error(ex.Message, "Curso");
            }
            finally
            {
                
            }
        }



        //<div class="stripe-separator"><!-- --></div>
        /*<h2>This is an H2 heading</h2>
							<h3>This is an H3 heading</h3>
							<h4>This is an H4 heading</h4>
							<h5>This is an H5 heading</h5>

							<div class="stripe-separator"><!-- --></div>

							<p>The separator above has top and bottom margin set by default, so it will split the content accordingly without 
							any extra tweaks needed from you.</p>

							<div class="stripe-separator"><!-- --></div>
							
							<blockquote>This is a blockquote followed by a cite tag. And no matter how much text you put in this, it will automatically resize.</blockquote>
							<cite>- John</cite>*/
        private void Mostrar_periodos( int perfil )
        {

            usuario user = new usuario();
            List<object> periodo_nombre;
            var id_periodo = "";
            int estado = 0;
            try
            {
                id_periodo = Request.QueryString["id_periodo"];
                if (id_periodo == null || id_periodo == "")
                {
                    periodo_nombre = user.Get_Periodo_Name("", curso_id);
                }
                else
                {
                    periodo_nombre = user.Get_Periodo_Name(id_periodo, null);
                }
            }
            catch
            {
                periodo_nombre = user.Get_Periodo_Name("" , curso_id);
            }

            foreach (object periodo_n in periodo_nombre)
            {
                object A = periodo_n;
                object[] B = (object[])A;
                string[] Datos_periodo = Array.ConvertAll(B, p => (p ?? String.Empty).ToString());
                titulo_periodo.InnerText = "(" + Datos_periodo[1] + ")";
                if (Datos_periodo[2] == "1")
                    estado_periodo.InnerText = "Estado: Abierto ";
                else
                    estado_periodo.InnerText = "Estado: Cerrado ";
                estado = Convert.ToInt32(Datos_periodo[2]);
                id_periodo = Datos_periodo[0];
                periodo_id = id_periodo;
            }

            switch (perfil)
            {
                case 0:
                    break;
                case 1:
                    Tutor tutor = new Tutor();
                    linkeliminar.Visible = true;
                    tablon_periodo.InnerHtml += "<h1>Herramientas</h1>";
                    tablon_periodo.InnerHtml += "<a  id='company-branding-small' href='add_doc_periodo.aspx?id_periodo=" + id_periodo + "'>Agregar Nuevo documento</a>";

                    if (estado == 0)
                        tablon_periodo.InnerHtml += " <div align='right'><a  id='company-branding-small' href='activar_periodo.aspx?id_periodo=" + id_periodo + "'><img src='images/icons/flecha.gif' width='120' height='10' /><b>Activar_periodo</b></a></div>";

                    tablon_periodo.InnerHtml += "<div class='stripe-separator'><!-- --></div>";
                    List<object> lista_documentos_periodo = tutor.Get_Periodo_Documentos(id_periodo);

                    if (lista_documentos_periodo == null 
                        || lista_documentos_periodo.Count == 0)
                    {
                        tablon_periodo.InnerHtml += "<div align='center'><h1>¡No existen documentos!</h1></div><div class='stripe-separator'><!-- --></div>";
                        tablon_periodo.InnerHtml += "<blockquote>No tienes ningun documento agregado en este periodo. " +
                        " si tu deseas agregar un documento nuevo solo ve al link 'agregar documento nuevo' o en dado caso no deseas, puedes eliminar el periodo completo.</blockquote>"
                             + "<cite>Staff My PluMon </cite>";
                    }
                    else
                    {

                    }
                    break;
                case 2:
                    break;
            }


        }

        protected void linkeliminar_Click(object sender, EventArgs e)
        {
            Tutor tutor = new Tutor();
            
            bool ok = tutor.Eliminar_periodo(periodo_id);
            if (ok)
            {
                Response.Redirect(Request.RawUrl);
            }
        }

        //region de funciones estandares
        #region Funciones_Estandares

        private void Get_mensaje()
        {
            try
            {
                Conexion conn = new Conexion();
                conn.IniciarConexion();
                string sql = " SELECT COUNT(id_user) FROM mensajeria WHERE id_user like '" + id_usuario + "' and leido=0";
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

            //verificamos la sesion si esta activa en dado caso no exista ira al inicio (LOGIN)
            try
            {
                var sesion_c = Session.Count;
                if (sesion_c <= 0)
                {
                    Response.Redirect("Login.aspx", true);
                    return;
                }

                id_usuario = Session["id_user"].ToString();
            }
            catch { Log.Set_Log_Error("Error sesion", "curso"); }

            linkeliminar.Visible = false;
            curso_id = Request.QueryString["id"].ToString();
            encript_curso_id = curso_id;
            curso_id = Encriptador.Desencriptar_Md5(curso_id);
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
                    Configuracion_Tutor();
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            //muestra los periodos por medio de los perfiles 
            // ejemplo : si el perfil es el tutor muestra las herramientas del tutor por ese periodo 
            // si el perfil es estudiante  entonces muestra el periodo sin ninguna manipulacion
            Mostrar_periodos(perfil);
            Master.SetUsuario_data();
            Get_mensaje();
        }

        #endregion
    }
}