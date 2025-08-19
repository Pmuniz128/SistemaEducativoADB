using Microsoft.EntityFrameworkCore;
using SistemaEducativoADB.API.Models.Entities;

namespace SistemaEducativoADB.API.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        // DbSets (Tablas)
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Profesor> Profesores { get; set; }

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

            // Configuración de PROFESORES
            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.ToTable("PROFESORES");

                entity.HasKey(p => p.IdProfesor);

                entity.Property(p => p.IdProfesor)
                      .HasColumnName("id_profesor");

                entity.Property(p => p.cedula)
                      .HasColumnName("cedula")
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(p => p.Telefono)
                      .HasColumnName("telefono")
                      .HasMaxLength(20);

                entity.Property(p => p.CorreoPersonal)
                      .HasColumnName("correo_personal")
                      .HasMaxLength(100);

                // Relación 1:1 con Usuario
                entity.HasOne(p => p.Usuario)
                      .WithOne(u => u.Profesor)
                      .HasForeignKey<Profesor>(p => p.IdUsuario)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de MATERIAS
            modelBuilder.Entity<Materia>(entity =>
            {
                entity.ToTable("MATERIAS");

                entity.HasKey(m => m.IdMateria);

                entity.Property(m => m.IdMateria)
                      .HasColumnName("id_materia");

                entity.Property(m => m.Codigo)
                      .HasColumnName("codigo")
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(m => m.Nombre)
                      .HasColumnName("nombre")
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(m => m.Creditos)
                      .HasColumnName("creditos")
                      .IsRequired();

                entity.Property(m => m.IdPlan)
                      .HasColumnName("id_plan");

                // Relación con PLAN_ESTUDIO (si hay entidad)
                // Si tienes un modelo PlanEstudio, activa esto:
                // entity.HasOne(m => m.PlanEstudio)
                //       .WithMany(p => p.Materias)
                //       .HasForeignKey(m => m.IdPlan)
                //       .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de CARRERAS
            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.ToTable("CARRERAS");

                entity.HasKey(c => c.IdCarrera);

                entity.Property(c => c.IdCarrera)
                      .HasColumnName("id_carrera");

                entity.Property(c => c.NombreCarrera)
                      .HasColumnName("nombre_carrera")
                      .HasMaxLength(100)
                      .IsRequired();
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
