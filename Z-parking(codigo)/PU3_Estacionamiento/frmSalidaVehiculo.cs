using PU3_Estacionamiento.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PU3_Estacionamiento
{
    public partial class frmSalidaVehiculo : Form
    {

        Boleta boletaTemporal = new Boleta();

        public frmSalidaVehiculo()
        {
            InitializeComponent();
        }

        private void frmSalidaVehiculo_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT V.IdVehiculo, V.IdEspacio, V.HoraEntrada, V.Placa, C.Nombre, C.Correo
                FROM Vehiculo V
                JOIN Conductor C ON V.IdConductor = C.IdConductor
                WHERE V.Placa = @p";

       
            try
            {
                using (SqlConnection conexion = ConexionSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@p", txtPlaca.Text);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            
                            boletaTemporal.IdVehiculo = Convert.ToInt32(dr["IdVehiculo"]);
                            boletaTemporal.IdEspacio = Convert.ToInt32(dr["IdEspacio"]);
                            boletaTemporal.Placa = dr["Placa"].ToString();
                            boletaTemporal.HoraEntrada = Convert.ToDateTime(dr["HoraEntrada"]);
                            boletaTemporal.CorreoConductor = dr["Correo"].ToString();
                            boletaTemporal.NombreConductor = dr["Nombre"].ToString();

                            boletaTemporal.HoraSalida = DateTime.Now;
                            decimal costo = boletaTemporal.CalcularMonto();

                            lblEntrada.Text = "Entrada: " + boletaTemporal.HoraEntrada.ToString("HH:mm:ss");
                            lblSalida.Text = "Salida: " + boletaTemporal.HoraSalida.ToString("HH:mm:ss");
                            lblCosto.Text = "Costo: S/" + costo.ToString("0.00");

                           
                        }
                        else
                        {
                            MessageBox.Show("Vehículo no encontrado o ya salió del estacionamiento.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                        }
                    } 
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el vehículo: " + ex.Message, "Error de BD");
            }
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (boletaTemporal.IdVehiculo == 0)
            {
                MessageBox.Show("Primero debe buscar y encontrar el vehículo.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

         
            boletaTemporal.HoraSalida = DateTime.Now;
            decimal montoFinal = boletaTemporal.CalcularMonto();

          
            try
            {
                using (SqlConnection conexion = ConexionSQL.Conectar())
                {
                 
                    SqlCommand cmd = new SqlCommand("INSERT INTO Boleta(IdVehiculo,HoraEntrada,HoraSalida,Monto) VALUES(@v,@e,@s,@m)", conexion);
                    cmd.Parameters.AddWithValue("@v", boletaTemporal.IdVehiculo);
                    cmd.Parameters.AddWithValue("@e", boletaTemporal.HoraEntrada);
                    cmd.Parameters.AddWithValue("@s", boletaTemporal.HoraSalida);
                    cmd.Parameters.AddWithValue("@m", montoFinal);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("UPDATE Espacio SET Ocupado=0, PlacaVehiculo=NULL WHERE IdEspacio=@id", conexion);
                    cmd2.Parameters.AddWithValue("@id", boletaTemporal.IdEspacio);
                    cmd2.ExecuteNonQuery();

                    
                    SqlCommand cmd3 = new SqlCommand("DELETE FROM Vehiculo WHERE IdVehiculo=@v", conexion);
                    cmd3.Parameters.AddWithValue("@v", boletaTemporal.IdVehiculo);
                    cmd3.ExecuteNonQuery();
                }
                

                MessageBox.Show("Salida registrada y boleta generada.", "Éxito");

                new frmBoleta(boletaTemporal).ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la salida: " + ex.Message, "Error de BD");
            }
        }
    }
}
