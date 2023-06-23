using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApi.Models
{
    public class Asiento
    {
        public int AsientoId{ get; set; }
        public int NumeroAsiento{ get; set; }
        public string Seccion { get; set; }
         public string Disponibilidad { get; set; }

    }
}