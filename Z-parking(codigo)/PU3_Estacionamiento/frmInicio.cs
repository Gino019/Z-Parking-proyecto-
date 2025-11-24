using PU3_Estacionamiento.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PU3_Estacionamiento
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtClave.Text))
            {
                lblError.Text = "Debe ingresar usuario y clave.";
                lblError.Visible = true;
                return;
            }

            try
            {
                using (SqlConnection conexion = ConexionSQL.Conectar())
                {
                    string query = "SELECT COUNT(1) FROM Usuario WHERE NombreUsuario = @user AND Contrasena = @pass";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@user", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@pass", txtClave.Text);

                    int count = (int)cmd.ExecuteScalar(); 

                    if (count > 0)
                    {
              
                        frmPrincipal f = new frmPrincipal();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        lblError.Text = "Usuario o clave incorrectos.";
                        lblError.Visible = true;
                    }
                } 
            }
            catch (Exception ex)
            {
                lblError.Text = "Error de conexión: " + ex.Message;
                lblError.Visible = true;
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
