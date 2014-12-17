using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoAsp.Clases;



namespace ProyectoAsp
{
    public partial class Formulario_web114 : System.Web.UI.Page
    {
        string id_perfil = "";
        string id_usuario = "";
        static string mail = null;
        static string alias = null;
        static bool correo_ok = false;
        static bool alias_ok = false;

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

                    lbl_advertencia_alias.Visible = false;
                    lbl_advertencia_alias0.Visible = false;
                    lblerror.Visible = false;

                    nombreperfil.InnerHtml = "<b>Codigo de seguridad: " + Session["id_user"] + "</b>";
                    id_perfil = Session["id_user"].ToString();
                    id_usuario = id_perfil;
                    Configuracion_master();


                    for (int i = 1930; i <= 2005; i++)
                        dyear.Items.Add(i.ToString());
                    for (int k = 1; k <= 12; k++)
                        dmonth.Items.Add(k.ToString());
                    for (int j = 1; j <= 31; j++)
                        ddate.Items.Add(j.ToString());

                    comboInstitucion.Items.Add("Universidad Don bosco");
                    comboInstitucion.Items.Add("Universidad De El Salvador");
                    comboInstitucion.Items.Add("Universidad Centroamericana (UCA)");
                    comboInstitucion.Items.Add("Universidad Tecnologica El salvador");
                    comboInstitucion.Items.Add("Colegio Don bosco");
                    comboInstitucion.Items.Add("Instituto Tecnico Ricaldone");
                    comboInstitucion.Items.Add("Colegio Santa Cecilia");

                    if (!IsPostBack)
                        CargandoDatos();
                    else
                    {
                        mail = txtcorreo.Text;
                        alias = txtalias.Text;
                    }

            }
            catch { }

        }

        protected void txtcorreo_TextChanged(object sender, EventArgs e)
        {


            if (mail == "")
            {
                lbl_advertencia_alias0.CssClass = new Cssclass().error;
                lbl_advertencia_alias0.Visible = true;
                lbl_advertencia_alias0.Text = "Esta en blanco!!";
                return;
            }
            if(mail == Session["email"].ToString())
            {
                lbl_advertencia_alias0.CssClass = new Cssclass().advertencia;
                lbl_advertencia_alias0.Visible = true;
                lbl_advertencia_alias0.Text = "Este es tu correo...";
                return;
            }

            bool ok = Seguridad.VerificarCorreo_enBDD(mail);
            if (ok)
            {
                lbl_advertencia_alias0.CssClass = new Cssclass().error;
                lbl_advertencia_alias0.Visible = true;
                lbl_advertencia_alias0.Text = "No Disponible";
            }
            else
            {
                lbl_advertencia_alias0.CssClass = new Cssclass().confirmacion;
                lbl_advertencia_alias0.Visible = true;
                lbl_advertencia_alias0.Text = "!Si¡ Disponible";
                correo_ok = true;
            }
        }


        protected void txtalias_TextChanged(object sender, EventArgs e)
        {

            if (alias == "")
            {
                lbl_advertencia_alias.CssClass = new Cssclass().error;
                lbl_advertencia_alias.Visible = true;
                lbl_advertencia_alias.Text = "Esta en blanco!!";
                return;
            }
            if (alias == Session["alias"].ToString())
            {
                lbl_advertencia_alias0.CssClass = new Cssclass().advertencia;
                lbl_advertencia_alias0.Visible = true;
                lbl_advertencia_alias0.Text = "Tu alias...";
                return;
            }

            bool ok = usuario.Existe_alias(alias);
            if (ok)
            {
                lbl_advertencia_alias.CssClass = new Cssclass().error;
                lbl_advertencia_alias.Visible = true;
                lbl_advertencia_alias.Text = "No Disponible";
            }
            else
            {
                lbl_advertencia_alias.CssClass = new Cssclass().confirmacion;
                lbl_advertencia_alias.Visible = true;
                lbl_advertencia_alias.Text = "!Si¡ Disponible";
                alias_ok= true;
            }
        }

 
        private void CargandoDatos()
        {
         
            try
            {
                txtnombre.Text = Session["nombre"].ToString();
                txtapellido.Text = Session["apellido"].ToString();
                txtalias.Text = Session["alias"].ToString();
                comboInstitucion.Text = Session["institucion"].ToString();
                combo_sexo.Text = Session["sexo"].ToString();
                txtcorreo.Text = Session["email"].ToString();

                Conexion conn = new Conexion();
                conn.IniciarConexion();
                string sql = "SELECT nacimiento , facebook , twitter, pais FROM user WHERE id_user like '" + id_usuario + "'";
                List<object> data = conn.Get_Consulta(sql);
                object[] obj = (object[])data[0];
                DateTime date = (DateTime) obj[0];
                string facebook = obj[1].ToString();
                string twitter = obj[2].ToString();

                if (facebook == "" || facebook == null)
                    em_fcebook.InnerHtml = "No dispones de un facebook registrado.  <a href='http://facebook.com'>Registrate</a> o agrega uno ya registrado";
                else
                {
                    em_fcebook.InnerText = "¿Deseas cambiar tu facebook?";
                    txtfacebook.Text = facebook;
                }

                if (twitter == "" || twitter == null)
                    em_twitter.InnerHtml = "No dispones de un twitter registrado. <a href='http://twitter.com'>Registrate</a> o agrega uno ya registrado";
                else
                {
                    em_twitter.InnerText = "¿Deseas cambiar tu twitter?";
                    txttwitter.Text = twitter;
                }

                ddate.Text = date.Day.ToString();
                dmonth.Text = date.Month.ToString();
                dyear.Text = date.Year.ToString();

                combopais.Text = obj[3].ToString();

            }
            catch (Exception ex)
            {
                try
                {
                    Log.Set_Log_Error(ex.Message, "editar perfil", id_perfil);
                }
                catch { }
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

        protected void cmd_imagen_Click(object sender, EventArgs e)
        {
            
        }

        protected void CmdGuardar_Click(object sender, EventArgs e)
        {

            Conexion conn = new Conexion();
            conn.IniciarConexion();
            try
            {
               
                string[] data_row = new string[10];
                string[] columnas = new string[10];
                data_row[0] = txtnombre.Text;
                data_row[1] = txtapellido.Text;
                if (Session["alias"].ToString() != alias)
                    if (alias_ok != true)
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Error en el alias , ya esta ocupado";
                        return;
                    }

                data_row[2] = txtalias.Text;
                if (Session["email"].ToString() != mail)
                    if (correo_ok != true)
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Error en el Correo , este ya esta asignado";
                        return;
                    }

                data_row[3] = txtcorreo.Text;
                string fecha = Seguridad.FormatoFecha(dyear.Text, dmonth.Text, ddate.Text);
                data_row[4] = fecha;
                data_row[5] = txtfacebook.Text;
                data_row[6] = txttwitter.Text;
                data_row[7] = comboInstitucion.Text;
                data_row[8] = combo_sexo.Text;
                data_row[9] = combopais.Text;

                columnas[0] = "nombre";
                columnas[1] = "apellido";
                columnas[2] = "alias";
                columnas[3] = "email";
                columnas[4] = "nacimiento";
                columnas[5] = "facebook";
                columnas[6] = "twitter";
                columnas[7] = "institucion";
                columnas[8] = "sexo";
                columnas[9] = "pais";

                bool IsOk = conn.ActualizarTabla_Conpatrones(columnas, data_row, "user", "id_user", id_usuario);
                if (IsOk)
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Datos alterados con exito";
                }
                conn.CerrarConexion();
            }
            catch (Exception ex)
            {
                try
                {
                    Log.Set_Log_Error(ex.Message, "editar perfil", Session["id_user"].ToString());
                    conn.CerrarConexion();
                }
                catch
                {

                }
            }
        }

      

    
     




        


    }
}