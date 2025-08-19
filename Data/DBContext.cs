using Microsoft.EntityFrameworkCore;
using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
    

        // Aquí defines los DbSets, que representan tablas en la base de datos
        public DbSet<Estudiante> Estudiantes { get; set; }


        // Método para configurar relaciones, reglas y restricciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de ESTUDIANTES
            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("ESTUDIANTES");

                entity.HasKey(e => e.IdEstudiante);

                entity.Property(e => e.IdEstudiante)
                      .HasColumnName("id_estudiante");

                entity.Property(e => e.IdUsuario)
                      .HasColumnName("id_usuario");

                entity.Property(e => e.Carnet)
                      .HasColumnName("carnet")
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(e => e.Telefono)
                      .HasColumnName("telefono")
                      .HasMaxLength(20);

                entity.Property(e => e.Direccion)
                      .HasColumnName("direccion")
                      .HasMaxLength(200);

                entity.Property(e => e.IdCarrera)
                      .HasColumnName("id_carrera");

                // Relación 1:1 con Usuario
                entity.HasOne(e => e.Usuario)
                      .WithOne(u => u.Estudiante)
                      .HasForeignKey<Estudiante>(e => e.IdUsuario)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de USUARIOS
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasKey(u => u.IdUsuario);

                entity.Property(u => u.IdUsuario)
                      .HasColumnName("id_usuario");

                entity.Property(u => u.nombre)
                      .HasColumnName("nombre")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(u => u.email)
                      .HasColumnName("email")
                      .HasMaxLength(150)
                      .IsRequired();

                entity.Property(u => u.contrasena)
                      .HasColumnName("contrasena")
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(u => u.Estado)
                      .HasColumnName("estado")
                      .HasDefaultValue(true);

                entity.Property(u => u.FechaCreacion)
                      .HasColumnName("fecha_creacion")
                      .HasDefaultValueSql("GETDATE()");
            });
        }


    }
}
