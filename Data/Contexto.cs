using EventApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Data
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        
        public DbSet<Evento> Evento { get; set; }
        public DbSet<CarritoCompra> CarritoCompra { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Asiento>Asiento { get; set; }
        public DbSet<Seccion>Seccion{ get; set; }
    }
}
