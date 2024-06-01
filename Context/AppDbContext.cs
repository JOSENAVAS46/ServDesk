using Microsoft.EntityFrameworkCore;
using ServDesk.Models;

namespace ServDesk.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<DocumentoInterno> DocumentoInternos { get; set; }
        public DbSet<TablaGenerica> TablaGenericas { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Reparacion> Reparaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
