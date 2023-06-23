using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventApi.Models
{
    public class Evento
    {
        [Key]
        public int EventoId { get; set; }
        public string NombreEvento { get; set; }
        public string Ubicacion{ get; set; }
        public string ImagenUrl { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public string Fecha{ get; set; }
    }
}