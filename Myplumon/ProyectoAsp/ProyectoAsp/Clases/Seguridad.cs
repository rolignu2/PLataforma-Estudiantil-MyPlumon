using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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


    }
}