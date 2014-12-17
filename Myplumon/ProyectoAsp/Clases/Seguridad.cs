using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ProyectoAsp.Clases;


namespace ProyectoAsp.Clases
{
    public static class Seguridad
    {

     
        public static bool UsuarioActivo(int estado)
        {
            switch (estado)
            {
                case 0:
                    return false;
                case 1:
                    return true;
                default:
                    return true;
            }

        }

        public static string FormatoFecha(string año, string mes, string dia)
        {
            return año + "-" + mes + "-" + dia;
        }

        public static string HttpUrl
        {
            get { return "http://" + HttpContext.Current.Request.Url.Authority ; }
        }

        public static string Id_cript_cadena(string cadena)
        {
            string[] cadena_dev = cadena.Split(' ');
            string reconstruir = null;

            if (cadena_dev.Length >= 1)
            {
                for (int i = 0; i < cadena_dev.Length; i++)
                {
                    if (!(cadena_dev.Length == i + 1))
                        reconstruir += cadena_dev[i] + "+";
                    else
                        reconstruir += cadena_dev[i];
                }
            }
            else
                reconstruir = cadena;

            return reconstruir;
        }

        public static bool VerificarCorreo_enBDD(string correo)
        {

            try
            {
                Conexion conn = new Conexion();
                conn.IniciarConexion();
                string consulta = "SELECT Count(email) From user where email like '" + correo + "'";
                List<object> data = conn.Get_Consulta(consulta);
                conn.CerrarConexion();

                object[] obj = (object[])data[0];
                if (obj[0] == null || Convert.ToInt32(obj[0]) == 0)
                    return false;
                else
                    return true;

            }
            catch(Exception ex)
            {
                Log.Set_Log_Error(ex.Message, "Seguridad correo verificar", null);
            }

            return false;
        }

    }



    public class Cssclass
    {
        public string informacion = "information-box round";
        public string confirmacion = "confirmation-box round";
        public string error = "error-box round";
        public string advertencia = "warning-box round";

        public string aleatorio()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            List<string> clases = new List<string>();
            string retorno = "";
            clases.Add(informacion);
            clases.Add(confirmacion);
            clases.Add(error);
            clases.Add(advertencia);
            return retorno = clases[r.Next(0, 3)];

        }

    }
}