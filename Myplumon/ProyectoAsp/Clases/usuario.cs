using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using ProyectoAsp.Clases;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAsp.Clases
{
    public class usuario
    {

        /// <summary>
        ///  cambia la imagen del usuario con los parametros nombre de la nueva imagen 
        ///  el id del usuario a cambiar y la direccion de la imagen ya guardada para eliminar anterior
        /// </summary>
        /// <param name="imagen"></param>
        /// <param name="id_user"></param>
        /// <param name="server_path"></param>
        /// <returns> regresa el nombre de la imagen en caso todo salio bien , regresa null en caso de que hubo un problema</returns>
        public string CambiarImagen(string imagen , string id_user , string server_path)
        {
            try
            {
                string imagen_anterior = null;
                Conexion conn = new Conexion();
                conn.IniciarConexion();
                if (conn.GetConexion == null) return null;
                string sql = "select imagen from user where id_user like '" + id_user + "'";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(sql, conn.GetConexion);
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                DataTable tabla = ds.Tables[0];
                foreach (DataRow rows in tabla.Rows)
                {
                    imagen_anterior = rows.Field<string>("imagen", DataRowVersion.Default);
                }
                adaptador.Dispose();
                ds.Dispose();
                tabla.Dispose();
                sql = "Update user set imagen = '" + imagen + "' where id_user like '" + id_user + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn.GetConexion);
                MySqlDataReader read = cmd.ExecuteReader();
                if (read.RecordsAffected >= 1)
                {
                    if (imagen_anterior != " NULL" 
                        || imagen_anterior != "NULL" 
                        || imagen_anterior != "" 
                        || imagen_anterior != " ")
                    {

                        string ruta = System.IO.Path.Combine(server_path, imagen_anterior);
                        System.IO.File.Delete(ruta);
                    }
                    conn.CerrarConexion();
                    return imagen;
                }
                else
                {
                    conn.CerrarConexion();
                    return null;
                }
            }
            catch 
            {
                return null;
            }

           
        }

        /// <summary>
        ///  obtenemos el periodo por medio de dos parametros independientes que son el id periodo o id curso
        /// </summary>
        /// <param name="id_periodo"></param>
        /// <param name="id_curso"></param>
        /// <returns> objetos en lista donde estan los periodos en forma de array object </returns>
        public List<object> Get_Periodo_Name(string id_periodo , string id_curso = null )
        {
            List<object> lista_periodo = new List<object>();
            string sql = "";
            if (id_curso == null)
            {
                id_periodo = Seguridad.Id_cript_cadena(id_periodo);
                sql = "SELECT id_periodo ,  nombre , estado FROM periodo_curso Where id_periodo like '" + id_periodo + "'";
            }
            else

                sql = "SELECT id_periodo ,  nombre , estado FROM periodo_curso Where id_curso like '" + id_curso + "'";

            try
            {
                Conexion conn = new Conexion();
                conn.IniciarConexion();
                if (conn == null)
                {
                    return null;
                }
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn.GetConexion);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable tabla = ds.Tables[0];
                if (id_curso == null)
                {
                    foreach (DataRow filas in tabla.Rows)
                    {
                        object[] obj = filas.ItemArray;
                        lista_periodo.Add(obj);
                    }
                }
                else
                {
                    DataRow filas = tabla.Rows[0];
                    lista_periodo.Add(filas.ItemArray);
                }
                adapter.Dispose();
                ds.Dispose();
                tabla.Dispose();
                conn.CerrarConexion();

                return lista_periodo;
            }
            catch (Exception ex)
            {
                Log.Set_Log_Error(ex.Message, "clase tutor ... get_periodo");
            }

            return null;
        }

        /// <summary>
        ///   obtiene los periodos del documento perfil usuario ... (perfil basico)
        /// </summary>
        /// <param name="id_periodo"></param>
        /// <returns></returns>
        public List<object> Get_Periodo_Documentos(string id_periodo)
        {
            List<object> lista_periodo = new List<object>();
            string sql = "";

            try
            {
                Conexion conn = new Conexion();
                conn.IniciarConexion();
                if (conn == null)
                {
                    Log.Set_Log_Error("No hay conexion", "clase tutor ... get_periodo");
                    return null;
                }
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn.GetConexion);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable tabla = ds.Tables[0];

                    foreach (DataRow filas in tabla.Rows)
                    {
                        object[] obj = filas.ItemArray;
                        lista_periodo.Add(obj);
                    }

                adapter.Dispose();
                ds.Dispose();
                tabla.Dispose();
                conn.CerrarConexion();

                return lista_periodo;
            }
            catch (Exception ex)
            {
                Log.Set_Log_Error(ex.Message, "clase tutor ... get_periodo_documento");
            }

            return null;
        }


        /// <summary>
        /// Miembro estatico verificando si existe alias de un usuario
        /// </summary>
        /// <param name="alias">alias del usuario</param>
        /// <returns> retorna true ->si existe en dado caso false->sino existe</returns>
        public static bool Existe_alias(string alias)
        {
            try
            {
                Conexion conn = new Conexion();
                conn.IniciarConexion();
                string consulta = "SELECT count(alias) FROM user Where alias like '" + alias + "'";
                List<object> data = conn.Get_Consulta(consulta);
                object[] valor = (object[])data[0];
                conn.CerrarConexion();
                if ( Convert.ToInt32(valor[0].ToString()) != 0)
                    return true;
                else
                    return false;
            }
            catch
            {

            }
            return false;
        }
    }
}