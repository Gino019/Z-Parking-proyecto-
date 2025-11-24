using PU3_Estacionamiento.Clases;
using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO.Ports;

namespace PU3_Estacionamiento
{
    public partial class frmPrincipal : Form
    {
        private ControlArduino controlArduino;

        public frmPrincipal()
        {
            InitializeComponent();

            controlArduino = new ControlArduino();
            if (controlArduino.Conectar())
            {
                
                controlArduino.AlertaRecibida += ControlArduino_AlertaRecibida;
            }
        }

        private void ControlArduino_AlertaRecibida(string tipoAlerta, bool estado)
        {
           
            this.Invoke((MethodInvoker)delegate {
                if (tipoAlerta == "LLUVIA" && estado == true)
                {
                    MessageBox.Show("¡Está lloviendo! Cerrando el techo...", "Alerta de Lluvia");
                }
                if (tipoAlerta == "HUMO" && estado == true)
                {
                    MessageBox.Show("¡¡ALERTA DE HUMO DETECTADA!!", "PELIGRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
        }

    
        private void btnRegistrarVehiculo_Click(object sender, EventArgs e)
        {
           
            if (controlArduino.EnviarComando("ABRIR_ENTRADA"))
            {
                MessageBox.Show("Barrera de ENTRADA abierta. Proceda al registro.");

                new frmRegistrarVehiculo().ShowDialog();

                controlArduino.EnviarComando("CERRAR_ENTRADA");
            }
            else
            {
                MessageBox.Show("No se pudo abrir la barrera. Revise la conexión del Arduino.", "Error de Hardware");
            }
        }

        
        private void btnControlEstacionamiento_Click(object sender, EventArgs e)
        {
            frmControlEstacionamiento frmControl = new frmControlEstacionamiento(controlArduino);
            frmControl.ShowDialog();
        }

        private void btnSalidaVehiculo_Click(object sender, EventArgs e)
        {
            new frmSalidaVehiculo().ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controlArduino != null)
            {
                controlArduino.Desconectar();
            }
        }
    }
}