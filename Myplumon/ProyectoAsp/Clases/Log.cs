using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ProyectoAsp.Clases
{
    public class Log
    {

        private static List<string> TempLog = new List<string>();

        /// <summary>
        /// guarda cualquier error producido en algun proceso del programa
        /// </summary>
        /// <param name="error">descripcion del error</param>
        /// <param name="sector">sector donde se produjo</param>
        /// <param name="id_user">uaurio a quien se le produjo (opcional)</param>
        public static void Set_Log_Error( string error, string sector, string id_user = null)
        {

            string fecha = null;
            fecha = Seguridad.FormatoFecha(DateTime.Now.Year.ToString()
                , DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString());

            try
            {
                Conexion conn = new Conexion();
                conn.IniciarConexion();
                if (conn == null)
                           return;

                if (id_user == null) id_user = "NULL";
                string mysql = "INSERT INTO log_ (id_user , error , sector , fecha) VALUES ('" + id_user + "','" + error + "','" + sector + "','" + fecha + "')";
                MySqlCommand cmd = new MySqlCommand(mysql, conn.GetConexion);
                MySqlDataReader read = cmd.ExecuteReader();
                if(read.RecordsAffected < 1)
                    TempLog.Add(error + "," + sector + "," + id_user + "," + fecha);
                cmd.Dispose();
                read.Dispose();
                conn.CerrarConexion();
            }
            catch
            {
                TempLog.Add(error + "," + sector + "," + id_user + "," + fecha);
            }
        }

        /// <summary>
        /// obtiene el numero de Log o registros de error que han quedado pendientes a "registrar"
        /// </summary>
        public static int CountTempLog {
            get { 
               return TempLog.Count;
            } 
        }


    }
}