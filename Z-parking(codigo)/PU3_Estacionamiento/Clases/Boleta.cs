using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PU3_Estacionamiento.Clases
{
    public class Boleta
    {
        public int IdBoleta { get; set; }
        public int IdVehiculo { get; set; }

        public int IdEspacio { get; set; }

        public string Placa { get; set; }
        public string NombreConductor { get; set; }
        public string CorreoConductor { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }

        public decimal MontoTotal { get; private set; }
        public TimeSpan TiempoTotal { get; private set; }

        private const decimal TarifaPorHora = 2.50m;

    
        public decimal CalcularMonto()
        {
            TiempoTotal = HoraSalida - HoraEntrada;

            double horasEstacionadas = TiempoTotal.TotalHours;
            int horasCobrar = (int)Math.Ceiling(horasEstacionadas);

            MontoTotal = horasCobrar * TarifaPorHora;
            return MontoTotal;
        }
    }
}
