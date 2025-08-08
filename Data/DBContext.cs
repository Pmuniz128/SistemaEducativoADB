using Microsoft.EntityFrameworkCore;
using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Data
{
    public class SistemaEducativoContext : DbContext
    {
        public SistemaEducativoContext(DbContextOptions<SistemaEducativoContext> options)
            : base(options)
        {
        }

        // Aquí defines los DbSets, que representan tablas en la base de datos
        public DbSet<Estudiante> Estudiantes { get; set; }


        // Método para configurar relaciones, reglas y restricciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estudiante>()
                .HasKey(e => e.Id); // Define explícitamente la clave primaria

            modelBuilder.Entity<Estudiante>()
                .HasIndex(e => e.Id)
                .IsUnique(); // Por ejemplo, si quieres que ID sea único
        }

    }
}
