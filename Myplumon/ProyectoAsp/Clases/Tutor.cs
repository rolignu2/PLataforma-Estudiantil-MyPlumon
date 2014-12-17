using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;


namespace ProyectoAsp.Clases
{
    public class Tutor
    {

        /// <summary>
        /// obtiene los cursos que se estan impartiendo por el tutor asignado 
        /// </summary>
        /// <param name="id_tutor">codigo del tutor</param>
        /// <returns></returns>
        public List<object> Get_Cursos(string id_tutor)
        {
            List<object> Listado_cursos = new List<object>();
            string sql = "SELECT cursos.id_curso , cursos.nombre , cursos.estado , cursos.imagen_curso FROM cursos ";
            sql += " WHERE cursos.id_docente LIKE '" + id_tutor + "'";

            try
            {
                Conexion conn = new Conexion();
                conn.IniciarConexion();
                if (conn == null)
                {
                    Log.Set_Log_Error("No hay conexion", "clase tutor", id_tutor);
                    return null;
                }
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn.GetConexion);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable tabla = ds.Tables[0];
                foreach (DataRow filas in tabla.Rows)
                {
                    object[] obj = filas.ItemArray;
                    Listado_cursos.Add(obj);
                }
                adapter.Dispose();
                ds.Dispose();
                tabla.Dispose();
                conn.CerrarConexion();

                return Listado_cursos;
            }
            catch (Exception ex)
            {
                Log.Set_Log_Error( ex.Message, "clase tutor", id_tutor);
            }

            return null;
          
        }

        /// <summary>
        /// crea un periodo (tutor)
        /// </summary>
        /// <param name="id_curso">codigo del curso </param>
        /// <param name="nombre"> nombre del curso</param>
        /// <param name="estado"> estado del curso activo/desactivo</param>
        /// <returns></returns>
        public bool CrearPeriodo(string id_curso, string nombre, bool estado)
        {
            try
            {

                string Id_Periodo = Encriptador.Encriptar_Md5(nombre +  "perido" + new Random().Next(100, 999));
                if (Id_Periodo.Length >= 255)
                {
                    Id_Periodo = Encriptador.Encriptar_Md5(nombre.Substring(0, nombre.Length / 2) + new Random().Next(0, 100));
                }
                int stado = 0;
                if (estado == true) stado = 1;
                Conexion conn = new Conexion();
                conn.IniciarConexion();
                string sql = "insert into periodo_curso (id_periodo , id_curso , nombre , estado) values ('"
                + Id_Periodo + "','" + id_curso + "','" + nombre + "'," + stado + ")";
                MySqlCommand comando = new MySqlCommand(sql, conn.GetConexion);
                MySqlDataReader reader = comando.ExecuteReader();
                conn.CerrarConexion();
                if (reader.RecordsAffected >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { Log.Set_Log_Error(ex.Message, "Tutor creacion de periodo"); }

            return false;
        }

        /// <summary>
        /// obtiene una lista de periodos del tutor en ese curso
        /// </summary>
        /// <param name="id_curso">codigo del curso</param>
        /// <returns></returns>
        public List<object> Get_Periodos(string id_curso)
        {
            List<object> lista_periodo = new List<object>();
            string sql = "SELECT id_periodo , nombre , estado FROM periodo_curso Where id_curso like '" + id_curso + "'";

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
                Log.Set_Log_Error(ex.Message, "clase tutor ... get_periodo");
            }

            return null;
        }


        /// <summary>
        /// obtiene documentos del periodo por medio del tutor... lo cambiante es que el tutor tiene privilegios extras
        /// </summary>
        /// <param name="id_periodo">codigo periodo</param>
        /// <returns>lista array objetos</returns>
        public List<object> Get_Periodo_Documentos(string id_periodo)
        {
            List<object> lista_periodo = new List<object>();
            string sql = "SELECT periodo_documentos.titulo , periodo_documentos.notas , periodo_documento.id_documento , periodo_docuemntos.id_foro ";
            sql += "FROM periodo_documentos WHERE periodo_documentos.id_periodo LIKE '" + id_periodo + "'";

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
        /// elimina periodos creados por el tutor .... esta funcion solo pide el identificador del periodo ya 
        /// ya que como no pide el identificador del tutor porque para habilitar el eliminar se encesita tener privilegios 
        /// 1 o 2 que es tutor y super usuario (root)
        /// </summary>
        /// <param name="id_periodo">codigo periodo</param>
        /// <returns>retorna true en caso que todo halla salido bien </returns>
        public bool Eliminar_periodo(string id_periodo)
        {
            string sql = "delete from periodo_curso where id_periodo like '" + id_periodo + "'";
            Conexion conn = new Conexion();
            conn.IniciarConexion();
            MySqlCommand cmd = new MySqlCommand(sql, conn.GetConexion);
            MySqlDataReader lector = cmd.ExecuteReader();
            try
            {
                if (lector.RecordsAffected >= 1)
                {
                    cmd.Dispose();
                    lector.Dispose();
                    sql = "SELECT COUNT(id_periodo) FROM periodo_documentos WHERE id_periodo LIKE '" + id_periodo + "'";
                    MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn.GetConexion);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count >= 1)
                    {
                        sql = "DELETE FROM periodo_documentos WHERE id_periodo LIKE '" + id_periodo + "'";
                        cmd = new MySqlCommand(sql, conn.GetConexion);
                        lector = cmd.ExecuteReader();
                        if (lector.RecordsAffected >= 1)
                        {
                            return true;
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Set_Log_Error(ex.Message, "TUTOR ELIMINAR PERIODO");
            }


            return false;
        }
        
        
    
    }
}