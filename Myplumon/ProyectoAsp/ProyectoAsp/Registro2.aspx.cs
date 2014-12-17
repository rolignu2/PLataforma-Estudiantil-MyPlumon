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
    public partial class Formulario_web14 : System.Web.UI.Page
    {

        //verifica si existe el usuario 
        static bool UsuarioExito = false;
        //obtiene los datos de una variable global
        List<string> Datos;

        protected void Page_Load(object sender, EventArgs e)
        {
            //verificamos antes de continuar si el registro 1 esta bien completado
            Datos = (List<string>)VariableIndependiente.GetDataLogin;
            if (Datos == null)
                Response.Redirect("Registro.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

                //variables globales y estaticas que obtenemos despues del registro 1
                var nombre = Datos[0];
                var apellido = Datos[1];
                var alias = Datos[2];
                var mail = Datos[3];
                var fecha = Datos[4];
                var fb = Datos[5];
                var tw = Datos[6];
                var institucion = Datos[7];
                var sexo = Datos[8];
                var pais = Datos[9];
                var user = txtuser.Text;
                var pass = txtpass.Text;
                

            try
            {
                //luego del timer verificamos denuevo si el usuario se ha cambiado (existe) para continuar con el proceso de guardado
                if (UsuarioExito == true)
                {

                    /*obtenemos los ID'S del usuario y login 
                     * verificamos que no se pasen de 255 caracteres la encriptacion de 256 bits 
                     en dado caso se pasa nos dara otro id por medio de numeros aleatorios (por cuestiones de seguridad) */
                    Random rnd = new Random(DateTime.Now.Millisecond);
                    string id_user = "";
                     string id_log = "";
                    while (true)
                    {
                         id_user = Encriptador.encriptar(user + nombre + rnd.Next(999, 9999));
                         id_log = Encriptador.encriptar(rnd.Next(1000, 9000) + user + apellido);
                        if (id_user.Length <= 200)
                        {
                            if (id_log.Length <= 200)
                            {
                                break;
                            }
                        }
                    }
                    //comencemos a guardar lo datos
                    string mysql_insert = "INSERT INTO log (id_log , id_user , user , password , estado) VALUES ( '"
                        + id_log + "','" + id_user + "','" + user + "','" + pass + "', 1)";
                    Conexion conn = new Conexion();
                    conn.IniciarConexion();
                    MySqlCommand comando_ = new MySqlCommand(mysql_insert, conn.GetConexion);
                    MySqlDataReader lector = comando_.ExecuteReader();
                    if (lector.RecordsAffected >=1)
                    {
                        lector.Close();
                        comando_.Dispose();
                        mysql_insert = "INSERT INTO user(id_user , nombre , apellido , alias , email ,nacimiento ,facebook , twitter , institucion , sexo , pais , perfil , imagen , fecha_inicio) VALUES('";
                        mysql_insert += id_user + "','" + nombre + "','" + apellido + "','" + alias + "','" + mail + "','" + fecha;
                        mysql_insert += "','" + fb + "','" + tw + "','" + institucion + "','" + sexo + "','" + pais + "','";
                        mysql_insert += "0" + "',' NULL" + "','" + Seguridad.FormatoFecha( DateTime.Now.Year.ToString() , DateTime.Now.Month.ToString() , DateTime.Now.Day.ToString()) + "')" ;
                        MySqlCommand comando_2 = new MySqlCommand(mysql_insert, conn.GetConexion);
                        MySqlDataReader reader = comando_2.ExecuteReader();
                        if (reader.RecordsAffected >= 1)
                        {
                            conn.CerrarConexion();
                            Response.Redirect("ExitoRegistro.aspx", true);
                        }
                        else
                        {
                            try
                            {
                                comando_2 = new MySqlCommand("DELETE FROM log WHERE id_log ='" + id_log + "'", conn.GetConexion);
                                comando_2.ExecuteReader();
                            }
                            catch { }
                        }
                    }

                    Datos = null;
                    VariableIndependiente.GetDataLogin = null;
                }
                else
                {
                    lblverificar_u.Text = "ESTE USUARIO YA ESTA OCUPADO";
                    return;
                }
            }
            catch { }
          
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            bool existe = false;
            string mysql = "SELECT user FROM log";
            Conexion conn = new Conexion();
            conn.IniciarConexion();
            MySqlDataAdapter adapter = new MySqlDataAdapter(mysql, conn.GetConexion);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable tabla = new DataTable();
            tabla = ds.Tables[0];
            foreach (DataRow rows in tabla.Rows) 
            {
                string valor = rows.Field<string>("user", DataRowVersion.Default);
                if (valor == txtuser.Text)
                {
                    existe = true;
                    break;
                }
                else
                    existe = false;
            }

            if (txtuser.Text != "")
            {
                if (txtuser.Text.Length >= 6 && existe == false)
                {
                    lblverificar_u.Text = "Este usuario se puede utilizar";
                    lblverificar_u.ForeColor = System.Drawing.Color.Blue;
                    UsuarioExito = true;
                }
                else if (existe == true)
                {
                    lblverificar_u.Text = "Este usuario ya existe. seleccionar otro";
                    lblverificar_u.ForeColor = System.Drawing.Color.Red;
                }
                else if (txtuser.Text.Length < 6 && existe == false)
                {
                    lblverificar_u.Text = "Nombre de usuario tiene que ser mayor a 6 caracteres";
                    lblverificar_u.ForeColor = System.Drawing.Color.Green;
                }
              

            }

                  
            conn.CerrarConexion();
        }

        protected void txtuser_TextChanged(object sender, EventArgs e)
        {
          
        }

     
    }
}