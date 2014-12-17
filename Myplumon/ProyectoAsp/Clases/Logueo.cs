using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;

namespace ProyectoAsp.Clases
{
    public class Logueo : System.Web.UI.Page 
    {

        private string usr = null;
        private string pass = null;

        private Conexion Conexion;
       
        public Logueo(string usr, string pass)
        {
            this.usr = usr;
            this.pass = pass;
            Conexion = new Conexion();
            Conexion.IniciarConexion();
        }

        public bool Loguear()
        {

            object[] data = null;
            List<string> comparadores_user = new List<string>();
            comparadores_user.Add("log.user");
            comparadores_user.Add("user.alias");
            comparadores_user.Add("user.email");

            for (int i = 0; i < comparadores_user.Count; i++ )
            {
                string mysql_create = "SELECT log.id_user , log.user , user.nombre , user.apellido , user.alias , user.perfil , user.institucion , user.email , user.imagen , log.estado , user.sexo " +
                   " FROM log  LEFT OUTER JOIN user ON log.id_user = user.id_user WHERE " + comparadores_user[i] + " LIKE '" + this.usr + "' AND log.password LIKE'" + this.pass + "'";

                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(mysql_create, Conexion.GetConexion);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DataTable tabla = ds.Tables[0];


                    foreach (DataRow rows in tabla.Rows)
                    {
                        data = rows.ItemArray;
                        break;
                    }
                }
                catch {
                    break;
                }
        
            }

            if (data != null)
            {
                bool ok = IniciarSesion(data);
                if (!ok)
                    return false;
                else
                    return true;
            }

            return false;
            
        }

        public bool CerrarSesion()
        {
            try
            {
                if (Session.Count >= 1)
                    Session.RemoveAll();
                else
                    return true;
            }
            catch (Exception ex)
            {
                Log.Set_Log_Error(ex.Message, "Login Cerrar sesion");
                return false;
            }

            return true;
        }

        private bool IniciarSesion( object[] data_sesion)
        {

            try
            {
                if (data_sesion == null) return false;

                Session.Add("id_user", data_sesion[0].ToString());
                Session.Add("usuario", data_sesion[1].ToString());
                Session.Add("nombre", data_sesion[2].ToString());
                Session.Add("apellido", data_sesion[3].ToString());
                Session.Add("alias", data_sesion[4].ToString());
                Session.Add("perfil", data_sesion[5].ToString());
                Session.Add("institucion", data_sesion[6].ToString());
                Session.Add("email", data_sesion[7].ToString());
                Session.Add("imagen", data_sesion[8].ToString());
                Session.Add("estado", data_sesion[9].ToString());
                Session.Add("sexo", data_sesion[10].ToString());
            }
            catch(Exception ex)
            {
                Log.Set_Log_Error(ex.Message, "Login inicio de sesion");
                return true;
            }
            return true;
        }



    }
}