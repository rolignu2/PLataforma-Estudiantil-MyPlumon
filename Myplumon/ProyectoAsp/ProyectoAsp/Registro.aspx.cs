using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoAsp.Clases;
using System.Threading;
using MySql.Data.MySqlClient;


namespace ProyectoAsp
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {

            VariableIndependiente.GetDataLogin = null;
            for (int i = 1930; i <= 2005; i++)
                dyear.Items.Add(i.ToString());
            for (int k = 1; k <= 12; k++)
                dmonth.Items.Add(k.ToString());
            for (int j = 1; j <= 31; j++)
                ddate.Items.Add(j.ToString());

            comboInstitucion.Items.Add("Universidad Don bosco");
            comboInstitucion.Items.Add("Universidad De El Salvador");
            comboInstitucion.Items.Add("Universidad Centroamericana (UCA)");
            comboInstitucion.Items.Add("Universidad Tecnologica El salvador");
            comboInstitucion.Items.Add("Colegio Don bosco");
            comboInstitucion.Items.Add("Instituto Tecnico Ricaldone");
            comboInstitucion.Items.Add("Colegio Santa Cecilia");



        }

  

        protected void Button1_Click(object sender, EventArgs e)
        {


            string fecha = dyear.Text + "-" + dmonth.Text + "-" + ddate.Text;
            lblfecha.Text = "";
            List<string> ValoresFormulario = new List<string>();
            ValoresFormulario.Add(txtnombre.Text);
            ValoresFormulario.Add(txtapellido.Text);
            ValoresFormulario.Add(txtalias.Text);
            ValoresFormulario.Add(txtmail.Text);
            ValoresFormulario.Add(fecha);
            ValoresFormulario.Add(txtfb.Text);
            ValoresFormulario.Add(txttwitter.Text);
            ValoresFormulario.Add(comboInstitucion.Text);
            ValoresFormulario.Add(combosexo.Text);
            ValoresFormulario.Add(combopais.Text);
            VariableIndependiente.GetDataLogin = ValoresFormulario;


            try
            {
                var mail = txtmail.Text;
                Conexion conn = new Clases.Conexion();
                conn.IniciarConexion();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE email like '" + mail + "'" , conn.GetConexion);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                }
                else
                {

                }
            
            }
            catch
            {
                Response.Redirect("Registro2.aspx");
            }

            Response.Redirect("Registro2.aspx");

        }
    }
}
