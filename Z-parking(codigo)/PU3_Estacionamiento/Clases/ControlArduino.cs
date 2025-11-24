using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace PU3_Estacionamiento.Clases
{
    public delegate void SensorEspacioEventHandler(int idEspacio, bool ocupado);
    public delegate void AlertaSensorEventHandler(string tipoAlerta, bool estado);

    public class ControlArduino
    {
        private SerialPort arduinoPort;

        private const string PORT_NAME = "COM4";
        private const int BAUD_RATE = 9600;

        public event SensorEspacioEventHandler SensorEspacioCambiado;
        public event AlertaSensorEventHandler AlertaRecibida;


        public ControlArduino()
        {
            arduinoPort = new SerialPort(PORT_NAME, BAUD_RATE);
            arduinoPort.ReadTimeout = 1000;
            arduinoPort.WriteTimeout = 1000;
        }

        public bool Conectar()
        {
            try
            {
                if (!arduinoPort.IsOpen)
                {
                    arduinoPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    arduinoPort.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con Arduino en " + PORT_NAME + ": " + ex.Message, "Error de Conexión Serial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void Desconectar()
        {
            if (arduinoPort.IsOpen)
            {
                arduinoPort.DataReceived -= DataReceivedHandler;
                arduinoPort.Close();
            }
        }

        public bool EnviarComando(string comando)
        {
            if (!arduinoPort.IsOpen) return false;

            try
            {
                arduinoPort.WriteLine(comando);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar comando '{comando}': {ex.Message}", "Error Serial");
                return false;
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            try
            {
                string data = sp.ReadLine().Trim();
                string[] partes = data.Split(':');

                if (partes.Length > 0)
                {
                    switch (partes[0])
                    {
                        case "ESPACIO":
                            if (partes.Length == 3 && SensorEspacioCambiado != null)
                            {
                                int id = int.Parse(partes[1]);
                                bool ocupado = (partes[2] == "1");
                                SensorEspacioCambiado(id, ocupado);
                            }
                            break;

                        case "ALERTA_LLUVIA":
                            if (partes.Length == 2 && AlertaRecibida != null)
                                AlertaRecibida("LLUVIA", (partes[1] == "1"));
                            break;

                        case "ALERTA_HUMO":
                            if (partes.Length == 2 && AlertaRecibida != null)
                                AlertaRecibida("HUMO", (partes[1] == "1"));
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error lectura serial: " + ex.Message);
            }
        }
    }
}