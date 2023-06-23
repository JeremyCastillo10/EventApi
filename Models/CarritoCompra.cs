using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventApi.Models
{
    public class CarritoCompra
    {
        [Key]
        public int CarritoId { get; set; }
        public int ClienteId { get; set; }
        public int AsientoId{ get; set; }
        public double TotalCarrito{ get; set; }
        public int CantidadBoletas{ get; set; }
    }
}