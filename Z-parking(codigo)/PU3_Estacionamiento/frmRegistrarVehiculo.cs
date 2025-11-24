using PU3_Estacionamiento.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PU3_Estacionamiento
{
    public partial class frmRegistrarVehiculo : Form
    {
        public frmRegistrarVehiculo()
        {
            InitializeComponent();
        }

        private void frmRegistrarVehiculo_Load(object sender, EventArgs e)
        {
          
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtPlaca.Text) || string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe completar al menos la Placa y el Nombre.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conexion = ConexionSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Conductor(Nombre,DNI,Telefono,Correo) OUTPUT INSERTED.IdConductor VALUES(@n,@d,@t,@c)", conexion);
                    cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@d", txtDNI.Text);
                    cmd.Parameters.AddWithValue("@t", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@c", txtCorreo.Text);
                    int idConductor = (int)cmd.ExecuteScalar();

                   
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO Vehiculo(Placa,Modelo,Color,IdConductor,IdEspacio,HoraEntrada) VALUES(@p,@m,@col,@idc,NULL,GETDATE())", conexion);
                    cmd2.Parameters.AddWithValue("@p", txtPlaca.Text);
                    cmd2.Parameters.AddWithValue("@m", txtModelo.Text);
                    cmd2.Parameters.AddWithValue("@col", txtColor.Text);
                    cmd2.Parameters.AddWithValue("@idc", idConductor);
                    // (Ya no pasamos @ide)
                    cmd2.ExecuteNonQuery();

                   
                }

                MessageBox.Show("Vehículo registrado. Pida al cliente que ingrese y se estacione en un lugar VERDE.");

              
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
            }
        }
    }
}