using PU3_Estacionamiento.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq; 
using System.Windows.Forms;
using Microsoft.VisualBasic; 
using System.Collections.Generic;

namespace PU3_Estacionamiento
{
    public partial class frmControlEstacionamiento : Form
    {
        private ControlArduino _controlArduino;

      
        private Dictionary<int, DateTime> _ultimoAviso = new Dictionary<int, DateTime>();

        public frmControlEstacionamiento(ControlArduino arduino)
        {
            InitializeComponent();
            _controlArduino = arduino; 
        }

        private void frmControlEstacionamiento_Load(object sender, EventArgs e)
        {
            CargarEspacios();
            CargarTablaOcupacion();

            if (_controlArduino != null)
            {
                _controlArduino.SensorEspacioCambiado += ControlArduino_SensorEspacioCambiado;
            }
        }

        private void ControlArduino_SensorEspacioCambiado(int idEspacio, bool ocupado)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SensorEspacioEventHandler(ControlArduino_SensorEspacioCambiado), new object[] { idEspacio, ocupado });
                return;
            }

            Button btn = this.Controls.Find("btnEspacio" + idEspacio, true).FirstOrDefault() as Button;
            if (btn == null) return; 

            if (ocupado) 
            {
                
                if (_ultimoAviso.ContainsKey(idEspacio))
                {
                    if ((DateTime.Now - _ultimoAviso[idEspacio]).TotalSeconds < 5) return; 
                }
                _ultimoAviso[idEspacio] = DateTime.Now;

               
                btn.BackColor = Color.Red;
                
                MessageBox.Show($"¡Auto detectado en Espacio {idEspacio}!\n" +
                                $"El botón se ha puesto ROJO.\n" +
                                $"Haga clic en él para vincular la placa.", 
                                "Sensor Activado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                
                if (btn.BackColor == Color.Red)
                {
                    btn.BackColor = Color.Green;
                    
                  
                    LiberarEspacioEnBD(idEspacio);
                    
                   
                    CargarTablaOcupacion();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarEspacios();
            CargarTablaOcupacion();
        }

        private void CargarEspacios()
        {
            try
            {
                using (SqlConnection conexion = ConexionSQL.Conectar())
                {
                    SqlCommand cmd = new SqlCommand("SELECT IdEspacio, Ocupado FROM Espacio WHERE IdEspacio <= 5", conexion);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr["IdEspacio"]);
                        bool ocupado = Convert.ToBoolean(dr["Ocupado"]);
                        
                        Button btn = this.Controls.Find("btnEspacio" + id, true).FirstOrDefault() as Button;
                        if (btn != null)
                        {
                            btn.BackColor = ocupado ? Color.Red : Color.Green;
                        }
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar espacios: " + ex.Message);
            }
        }

  
        private void btnEspacio_Click(object sender, EventArgs e)
        {
            Button botonEspacio = (Button)sender;
            int idEspacio = int.Parse(botonEspacio.Name.Replace("btnEspacio", ""));

            if (botonEspacio.BackColor == Color.Red)
            {

                string placa = Interaction.InputBox($"El Espacio {idEspacio} está ocupado. Ingrese la PLACA para VINCULARLA:", "Vincular Placa", "");

                if (!string.IsNullOrEmpty(placa))
                {
                    AsignarEspacio(placa.ToUpper(), idEspacio);
                    CargarTablaOcupacion();
                }
            }
            else 
            {
               
                if (MessageBox.Show($"El espacio {idEspacio} está libre. ¿Desea marcarlo como ocupado manualmente?", "Asignación Manual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string placa = Interaction.InputBox($"Ingrese la PLACA para el Espacio {idEspacio}:", "Asignar Manualmente", "");
                    if (!string.IsNullOrEmpty(placa))
                    {
                        AsignarEspacio(placa.ToUpper(), idEspacio);
                        botonEspacio.BackColor = Color.Red;
                        CargarTablaOcupacion();
                    }
                }
            }
        }

        private void AsignarEspacio(string placa, int idEspacio)
        {
            try
            {
                using (SqlConnection conexion = ConexionSQL.Conectar())
                {
                   
                    string queryVehiculo = "UPDATE Vehiculo SET IdEspacio = @idEspacio WHERE Placa = @placa AND IdEspacio IS NULL";
                    SqlCommand cmdVehiculo = new SqlCommand(queryVehiculo, conexion);
                    cmdVehiculo.Parameters.AddWithValue("@idEspacio", idEspacio);
                    cmdVehiculo.Parameters.AddWithValue("@placa", placa);
                    
                    int filasAfectadas = cmdVehiculo.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        string queryEspacio = "UPDATE Espacio SET Ocupado = 1, PlacaVehiculo = @placa WHERE IdEspacio = @idEspacio";
                        SqlCommand cmdEspacio = new SqlCommand(queryEspacio, conexion);
                        cmdEspacio.Parameters.AddWithValue("@idEspacio", idEspacio);
                        cmdEspacio.Parameters.AddWithValue("@placa", placa);
                        cmdEspacio.ExecuteNonQuery();
                        
                        MessageBox.Show($"Placa {placa} vinculada correctamente al espacio {idEspacio}.", "Éxito");
                    }
                    else
                    {
                        MessageBox.Show($"No se encontró el vehículo '{placa}' pendiente o ya tiene espacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error SQL al asignar: " + ex.Message);
            }
        }

        private void LiberarEspacioEnBD(int idEspacio)
        {
             try
            {
                using (SqlConnection conexion = ConexionSQL.Conectar())
                {
                     string queryEspacio = "UPDATE Espacio SET Ocupado = 0, PlacaVehiculo = NULL WHERE IdEspacio = @idEspacio";
                     SqlCommand cmdEspacio = new SqlCommand(queryEspacio, conexion);
                     cmdEspacio.Parameters.AddWithValue("@idEspacio", idEspacio);
                     cmdEspacio.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al liberar automáticamente: " + ex.Message);
            }
        }

        private void CargarTablaOcupacion()
        {
            try
            {
                using (SqlConnection conexion = ConexionSQL.Conectar())
                {
                    string query = @"
                        SELECT 
                            E.IdEspacio AS [Espacio],
                            C.Nombre AS [Conductor],
                            V.Placa AS [Placa],
                            V.Color AS [Color],
                            C.Telefono AS [Teléfono]
                        FROM Espacio E
                        LEFT JOIN Vehiculo V ON E.IdEspacio = V.IdEspacio
                        LEFT JOIN Conductor C ON V.IdConductor = C.IdConductor
                        WHERE E.IdEspacio <= 5
                        ORDER BY E.IdEspacio";

                    SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvOcupacion.DataSource = dt;
                } 

                foreach (DataGridViewRow fila in dgvOcupacion.Rows)
                {
                    if (fila.Cells["Placa"].Value == DBNull.Value)
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;
                    else
                        fila.DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tabla: " + ex.Message);
            }
        }

        private void frmControlEstacionamiento_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_controlArduino != null)
            {
                _controlArduino.SensorEspacioCambiado -= ControlArduino_SensorEspacioCambiado;
            }
        }
    }
}