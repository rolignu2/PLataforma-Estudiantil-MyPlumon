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

        static string id_usuario = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //verificamos la sesion si esta activa en dado caso no exista ira al inicio (LOGIN)
                id_usuario = Session["id_user"].ToString();
                if (id_usuario == null || id_usuario == "")
                {
                    Response.Redirect("Login.aspx", true);
                    return;
                }

                //verificamos el estado por seguridad , si esta activo o no  0 inactivo , 1 activo en dado caso este inactivo redirecciona a otra pagina
                string estado = Session["estado"].ToString();
                bool estatus = Seguridad.UsuarioActivo(Convert.ToInt32(estado));
                if (estatus == false)
                    Response.Redirect("Inactivo.aspx", true);

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
                        Master.SetEstudiante();
                        Master.SetMensajeria_estudiante("", "");
                        Get_Registro();
                        break;
                    case 1:
                        ((Label)Master.FindControl("lbltab1")).Text = "NULL";
                        ((Label)Master.FindControl("lbltab2")).Text = "Crear Nuevo Cuso";
                        ((Label)Master.FindControl("lbltab3")).Text = "Ver Mas";
                        Master.SetUsuario_data();
                        Get_Tutor_cursos();
                        //verificacion del registro del usuario ... vista del registro
                        Get_Registro(1);
                        break;
                    case 2:
                        break;
                    default:
                        break;
                } //fin codigo verificacion perfil
                //bienvenida al usuario
                Get_user();
                Get_mensaje();
            }
            catch
            {
                Response.Redirect("login.aspx");
            }

        }

        //registro
        private void Get_Registro( int i = 0)
        {
            string T = DatosEstaticos.Hora;
            string F = DatosEstaticos.Fecha;
            lblfecha.InnerText = "Sesion iniciada el: " + F;
            lblhora.InnerText = "En la hora de: " + T;
            if (i == 0)
            {
                rango.InnerText = "Estado: usuario";
            }
            else if (i == 1)
            {
                rango.InnerText = "Estado : Tutor";
            }

            modulo.InnerText = "Acceso: " + Session.SessionID;
        }

        //si es un tutor podra ver las clases que esta impartiendo
        private void Get_Tutor_cursos()
        {
            Tutor TUTOR = new Tutor();
            List<object> tutorias_creadas = TUTOR.Get_Cursos(id_usuario);
            if (tutorias_creadas == null)
            {
                div_tabla.InnerHtml = "<div class='warning-box' ><p align='center' >Lo sentimos no se pudieron cargar los cursos </p>"
                    + "</ br><p align='center'>puede que la conexion este saturada; intentar mas tarde</p>";
            }
            else if (tutorias_creadas.Count >= 1)
            {

                div_tabla.InnerHtml = "<table><thead><tr><th></th>"
                                    + "<th>Codigo</th>"
                                    + "<th>Nombre</th>"
                                    + "<th>Estado</th>"
                                    + "<th>Link</th></tr></thead><tbody>";

                for (int i = 0; i < tutorias_creadas.Count; i++)
                {
                    object A = tutorias_creadas[i];
                    object[] B = (object[])A;
                    string[] Datos_cursos = Array.ConvertAll(B, p => (p ?? String.Empty).ToString());
                    div_tabla.InnerHtml += "<tr>";
                    string url_imagen = Seguridad.HttpUrl + "/images/cursos/" + Datos_cursos[3];
                    div_tabla.InnerHtml += "<td><img src='" + url_imagen + "' width='60' height='60' /></td>";
                    div_tabla.InnerHtml += "<td>" + Datos_cursos[0].ToString() + "</td>";
                    div_tabla.InnerHtml += "<td>" + Datos_cursos[1].ToString() + "</td>";
                    int activo = Convert.ToInt32(Datos_cursos[2].ToString());
                    if (activo == 1)
                        div_tabla.InnerHtml += "<td>Activo</td>";
                    else
                        div_tabla.InnerHtml += "<td>Inactivo</td>";
                    string encrypt = Encriptador.Encriptar_Md5(Datos_cursos[0]);
                    div_tabla.InnerHtml += "<td><a href='curso.aspx?id=" + encrypt + "'>Ir al curso</a></td>";
                    div_tabla.InnerHtml += "</tr>";
                }
                div_tabla.InnerHtml += "<tbody></table>";
            }
            else
            {
            }
        }

        private void Get_Usuario_Cursos()
        {

        }

        private void Get_user()
        {
            if (Session["sexo"].ToString() == "Masculino")
                lblbienvenida.Text = "Bienvenido ¡" + Session["nombre"] + " " + Session["apellido"] + "!";
            else
                lblbienvenida.Text = "Bienvenida ¡" + Session["nombre"] + " " + Session["apellido"] + "!";
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
                object[] obj = (object[]) Numero_mensaje[0];
                Master.SetMensajeria_estudiante(obj[0].ToString(), "mensajeria.aspx?id=" + id_usuario);
            }
            catch (Exception ex)
            {
                Log.Set_Log_Error(ex.Message, "INDEX.ASPX", id_usuario);
            }
        }

        #endregion
    }

}