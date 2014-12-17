using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ProyectoAsp.Clases
{
    public class Conexion
    {

        private static string CnStr = "Server=localhost;Database=mypizarron;User=root;Password=;";

        private MySqlConnection MyConn = null;


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

        public MySqlConnection GetConexion
        {
            get
            {
                return this.MyConn;
            }
        }

    }
}