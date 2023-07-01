using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApi.Models
{
    public class Asiento
    {
        public int AsientoId{ get; set; }
        public string NumeroAsiento{ get; set; }
        public string Evento { get; set; }
        public string Seccion { get; set; }
         public string Disponibilidad { get; set; }
         public double Precio { get; set; }

    }
}