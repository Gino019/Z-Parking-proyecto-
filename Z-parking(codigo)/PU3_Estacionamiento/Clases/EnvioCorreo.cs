using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PU3_Estacionamiento.Clases
{
    public class EnvioCorreo
    {
        private const string CORREO_EMISOR = "pierosolorzano10@gmail.com";

        private const string CONTRASENA_EMISOR = "lssx ebgs zytv uast";

        private const string SMTP_SERVER = "smtp.gmail.com";
        private const int SMTP_PORT = 587;

        public bool EnviarBoleta(string destinatario, string asunto, string cuerpoHtml)
        {
            if (string.IsNullOrEmpty(destinatario)) return false;

            try
            {
                using (MailMessage mensaje = new MailMessage(CORREO_EMISOR, destinatario, asunto, cuerpoHtml))
                using (SmtpClient cliente = new SmtpClient(SMTP_SERVER, SMTP_PORT))
                {
                    mensaje.IsBodyHtml = true;
                    mensaje.BodyEncoding = Encoding.UTF8;

                    cliente.EnableSsl = true;
                    cliente.UseDefaultCredentials = false;
                    cliente.Credentials = new NetworkCredential(CORREO_EMISOR, CONTRASENA_EMISOR);

                    cliente.Send(mensaje);
                    return true;
                }
            }
            catch (SmtpException smtpEx)
            {
                MessageBox.Show($"Error SMTP al enviar correo: {smtpEx.StatusCode} - {smtpEx.Message}. Verifique la Contraseña de Aplicación.", "Error de Envío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general al enviar correo: " + ex.Message, "Error de Envío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
