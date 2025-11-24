using PU3_Estacionamiento.Clases;
using System;
using System.Drawing;
using System.Drawing.Printing; 

using System.Net.Mail;
using System.Windows.Forms;

namespace PU3_Estacionamiento
{
    public partial class frmBoleta : Form
    {
        private Boleta _boleta;

        private PrintDocument printDocument1 = new PrintDocument();

        public frmBoleta(Boleta boleta)
        {
            InitializeComponent();
            this._boleta = boleta;

            printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
        }

        private void frmBoleta_Load(object sender, EventArgs e)
        {
            MostrarDatosBoleta();
        }

        private void MostrarDatosBoleta()
        {
            TimeSpan tiempoTotal = _boleta.TiempoTotal;
            string tiempoStr = $"{(int)tiempoTotal.TotalHours}h {tiempoTotal.Minutes}m";

            lblBoleta.Text = "--- ESTACIONAMIENTO: BOLETA ---";

            lblDatos.Text = $"Placa: {_boleta.Placa}\n" +
                            $"Conductor: {_boleta.NombreConductor}\n" +
                            $"Correo: {_boleta.CorreoConductor}\n" +
                            $"----------------------------------\n" +
                            $"Entrada: {_boleta.HoraEntrada:dd/MM/yy HH:mm:ss}\n" +
                            $"Salida: {_boleta.HoraSalida:dd/MM/yy HH:mm:ss}\n" +
                            $"Tiempo Total: {tiempoStr}\n" +
                            $"----------------------------------\n" +
                            $"MONTO TOTAL: S/ {_boleta.MontoTotal:N2}";
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPreviewDialog printPreview = new PrintPreviewDialog();
                printPreview.Document = printDocument1;

                if (printPreview.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                    MessageBox.Show("Boleta enviada a impresión.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar la impresión: {ex.Message}", "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontTitulo = new Font("Arial", 12, FontStyle.Bold);
            Font fontNormal = new Font("Arial", 10);
            float yPos = 50;
            float leftMargin = 50;
            float lineHeight = fontNormal.GetHeight(g);

            string[] lines = lblDatos.Text.Split('\n');

            foreach (string line in lines)
            {
                g.DrawString(line, fontNormal, Brushes.Black, leftMargin, yPos);
                yPos += lineHeight + 2;
            }

            e.HasMorePages = false;
        }


        private void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            string correoDestino = _boleta.CorreoConductor;

            if (string.IsNullOrWhiteSpace(correoDestino) || !correoDestino.Contains("@"))
            {
                MessageBox.Show("El conductor no tiene un correo válido registrado para el envío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EnvioCorreo servicioCorreo = new EnvioCorreo();
            string asunto = $"Boleta de Estacionamiento - Placa {_boleta.Placa}";
            string cuerpoHtml = GenerarCuerpoHtmlBoleta();

            if (servicioCorreo.EnviarBoleta(correoDestino, asunto, cuerpoHtml))
            {
                MessageBox.Show($"Boleta enviada con éxito a {correoDestino}.", "Envío Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GenerarCuerpoHtmlBoleta()
        {
            return $"<html><body>" +
                   $"<h2>Boleta Estacionamiento</h2>" +
                   $"<p><b>Placa:</b> {_boleta.Placa}</p>" +
                   $"<p><b>Conductor:</b> {_boleta.NombreConductor}</p>" +
                   $"<p><b>Entrada:</b> {_boleta.HoraEntrada:dd/MM/yyyy HH:mm:ss}</p>" +
                   $"<p><b>Salida:</b> {_boleta.HoraSalida:dd/MM/yyyy HH:mm:ss}</p>" +
                   $"<hr>" +
                   $"<h3>MONTO TOTAL: S/ {_boleta.MontoTotal:N2}</h3>" +
                   $"</body></html>";
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}