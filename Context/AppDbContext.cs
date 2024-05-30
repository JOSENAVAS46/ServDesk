using Microsoft.EntityFrameworkCore;
using ServDesk.Models;

namespace ServDesk.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<DocumentoInternoModel> DocumentoInternos { get; set; }
        public DbSet<TablaGenericaModel> TablaGenericas { get; set; }
        public DbSet<EquipoModel> Equipos { get; set; }
        public DbSet<TecnicoModel> Tecnicos { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<SolicitudModel> Solicitudes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
