using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Text;
using ProyectoAsp.Clases;
using System.Data;

namespace ProyectoAsp
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdrecuperar_Click(object sender, EventArgs e)
        {
            string correo = txtmail.Text;

            try
            {

                Conexion conn = new Conexion();
                conn.IniciarConexion();
                string sql = "select log.password from log inner join user on log.id_user = user.id_user where user.email like '" + correo + "'"; 
                string password = "";
                MySql.Data.MySqlClient.MySqlDataAdapter adapter = new MySql.Data.MySqlClient.MySqlDataAdapter(sql , conn.GetConexion);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable tabla = ds.Tables[0];
                foreach (DataRow dr in tabla.Rows)
                    password = dr.Field<string>("password", DataRowVersion.Default);

                conn.CerrarConexion();
                adapter.Dispose();
                ds.Dispose();
                tabla.Dispose();

                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("rolando_antonio_90@hotmail.com");
                mail.Subject = "My pisarron 2 Recuperar contraseña ";

                string Body = "Hola " + Environment.NewLine +
                              "su contraseña es <b>" + password + "</b>";

                mail.Body = Body;

                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.live.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("rolando_antonio_90@hotmail.com", "linux2012" );
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch(Exception ex)
            {
                Log.Set_Log_Error(ex.Message, "Recuperar contraseña");
                exito.InnerHtml = "<p><b>Ocurrio un error al momento de procesar su solicitud</b></p>";

            }
            exito.InnerHtml = "<p>Se le ha enviado un correo con su contraseña ... revisar  <b>" + correo + "</b></p>";

        }
    }
}