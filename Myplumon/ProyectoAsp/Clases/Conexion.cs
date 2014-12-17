using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ProyectoAsp.Clases
{
    public class Conexion
    {

        private static string CnStr = "Server=localhost;Database=myplumon;User=root;Password=;";

        private MySqlConnection MyConn = null;


        /// <summary>
        /// inicia la conexion 
        /// </summary>
        /// <returns> retorna la conexion iniciada</returns>
        public MySqlConnection IniciarConexion()
        {
            try
            {
                if (MyConn == null)
                {
                    MyConn = new MySqlConnection(CnStr);
                    MyConn.Open();
                }
                else
                {
                    bool Isclose = CerrarConexion();
                    if (Isclose)
                    {
                        MyConn = new MySqlConnection(CnStr);
                        MyConn.Open();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }

            return MyConn;
        }


        /// <summary>
        /// cierra la conexion del objeto 
        /// </summary>
        /// <returns></returns>
        public bool CerrarConexion()
        {
            if (MyConn != null)
            {
                if (MyConn.State == System.Data.ConnectionState.Open)
                    MyConn.Close();

                if (MyConn.State == System.Data.ConnectionState.Closed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// cambia el tipo de conexion del string 
        /// </summary>
        public static string ConexionString
        {
            get
            { 
                return CnStr;
            }
            set
            {
                CnStr = ConexionString;
            }
        }


        /// <summary>
        /// obtiene la conexion abierta
        /// </summary>
        public MySqlConnection GetConexion
        {
            get
            {
                return this.MyConn;
            }
        }


        /// <summary>
        /// obtiene una consulta de tipo sql .. donde existe un valor o mas valores devuletos
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>retorna una lista 
        /// <example> list(object) ArrayItem = object[] </example>
        /// <value>donde el valor es un object[] por cada lista</value>
        /// </returns>
        public List<object> Get_Consulta(string sql)
        {
            try
            {
                List<object> Lista = new List<object>();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, this.MyConn);
                System.Data.DataSet ds = new System.Data.DataSet();
                adapter.Fill(ds);
                System.Data.DataTable tabla = new System.Data.DataTable();
                tabla = ds.Tables[0];
                foreach (System.Data.DataRow rows in tabla.Rows)
                {
                    Lista.Add(rows.ItemArray);
                }

                return Lista;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///  obtiene un resultado si la consulta creada es un exito ... solo para consulta con una respuesta boolena si o no
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>un booleano cierto , si existe una tabla afectada ; falso si ninguna tabla afecto</returns>
        public bool Get_Consulta_booleana(string sql)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, this.MyConn);
                MySqlDataReader lector = cmd.ExecuteReader();
                if (lector.RecordsAffected >= 1)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }


        /// <summary>
        /// funcion update table o actualziar tabla por medio de patrones dados 
        /// </summary>
        /// <param name="columnas">arreglo de columnas a actualizar</param>
        /// <param name="datos_rows">datos de las columnas a actualizar</param>
        /// <param name="tabla_name">nombre de la tabla a actualizar</param>
        /// <param name="condicion_campo">campo de la tabla a formar la condicion</param>
        /// <param name="condicion_id"> id de la condicion formada </param>
        /// <returns> true , si es correco , false sino</returns>
        public bool ActualizarTabla_Conpatrones(string[] columnas, string[] datos_rows, string tabla_name , string condicion_campo , string condicion_id)
        {

            int ColCount = columnas.Length;
            int DataCount = columnas.Length;
            string SqlDataArgumento = "";
            MySqlCommand Cmd;

            if (ColCount != DataCount) return false;

            try
            {
                 int salida = 0;
                for (int i = 0; i < ColCount; i++){

                    bool EsNumero = int.TryParse(datos_rows[i], out salida);
                    if (i != (ColCount - 1))
                    {
                        if (EsNumero)
                            SqlDataArgumento += columnas[i] + "= " + datos_rows[i] + " ,";
                        else
                            SqlDataArgumento += columnas[i] + "= '" + datos_rows[i] + "' ,";
                    }
                    else
                    {
                        if (EsNumero)
                            SqlDataArgumento += columnas[i] + "= " + datos_rows[i] + "";
                        else
                            SqlDataArgumento += columnas[i] + "= '" + datos_rows[i] + "'";
                    }
                }

                
                string sql = "UPDATE " + tabla_name
                    + " SET " + SqlDataArgumento + " WHERE " + condicion_campo +  " LIKE '" + condicion_id + "'";

                Cmd = new MySqlCommand(sql , this.GetConexion);
                MySqlDataReader reader = Cmd.ExecuteReader();
                if (reader.RecordsAffected >= 1)
                    return true;
            }
            catch
            {
                return false;
            }

            return false;
        }

      

    }
}