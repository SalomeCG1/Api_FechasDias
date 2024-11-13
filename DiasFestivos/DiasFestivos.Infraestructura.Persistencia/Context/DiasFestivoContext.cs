using DiasFestivos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace DiasFestivos.Infraestructura.Persistencia.Context
{
    public class DiasFestivoContext : DbContext
    {
        public DiasFestivoContext(DbContextOptions<DiasFestivoContext> options) : base(options)
        {
        }

        public DbSet<TBFestivos> festivos { get; set; }
        public DbSet<TBTipo> tipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TBFestivos>(festivo =>
            {
                festivo.HasKey(f => f.Id);
                festivo.HasIndex(f => f.Nombre).IsUnique();
            });

            modelBuilder.Entity<TBTipo>(tipo =>
            {
                tipo.HasKey(t => t.Id);
                tipo.HasIndex(t => t.Tipo).IsUnique();
            });

            modelBuilder.Entity<TBFestivos>(festivo =>
            {
                festivo.HasKey(f => f.Id);
                festivo.HasIndex(f => f.Nombre).IsUnique();
                festivo.Property(f => f.Dia).IsRequired();
                festivo.Property(f => f.Mes).IsRequired();
            });

            modelBuilder.Entity<TBTipo>(tipo =>
            {
                tipo.HasKey(t => t.Id);
                tipo.HasIndex(t => t.Tipo).IsUnique();
                tipo.Property(t => t.Tipo).IsRequired();
            });
        }

    }
}
