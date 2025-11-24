using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PU3_Estacionamiento.Clases
{
    public class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public int IdConductor { get; set; }
        public int IdEspacio { get; set; }
        public DateTime HoraEntrada { get; set; }
    }
}
