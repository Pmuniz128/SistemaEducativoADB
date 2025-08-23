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
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Pago> Pagos { get; set; }

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

                entity.Property(p => p.IdUsuario)
                      .HasColumnName("id_usuario");

                entity.Property(p => p.Cedula)
                      .HasColumnName("cedula")
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(p => p.Telefono)
                      .HasColumnName("telefono")
                      .HasMaxLength(20);

                entity.Property(p => p.CorreoPersonal)
                      .HasColumnName("correo_personal")
                      .HasMaxLength(100);

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


            //Configuracion de MATRICULAS
            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.ToTable("MATRICULAS");
                entity.HasKey(e => e.id_matricula);
                entity.Property(e => e.id_matricula).HasColumnName("id_matricula");
                entity.Property(e => e.id_estudiante).HasColumnName("id_estudiante");
                entity.Property(e => e.id_periodo).HasColumnName("id_periodo");
                entity.Property(e => e.estado).HasColumnName("estado").HasMaxLength(30);

                entity.HasIndex(e => new { e.id_estudiante, e.id_periodo })
                .IsUnique()
                .HasDatabaseName("UX_Matriculas_EstudiantePeriodo");

                // Relación con ESTUDIANTE
                entity.HasOne<Estudiante>()
                .WithMany()
                .HasForeignKey(e => e.id_estudiante)
                .HasConstraintName("FK_MATRICULAS_ESTUDIANTES")
                .OnDelete(DeleteBehavior.Restrict);
            });

            //Configuracion de Grupos
            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.ToTable("GRUPOS");
                entity.HasKey(g => g.IdGrupo);

                entity.Property(g => g.IdGrupo).HasColumnName("id_grupo");
                entity.Property(g => g.IdMateria).HasColumnName("id_materia");
                entity.Property(g => g.IdProfesor).HasColumnName("id_profesor");
                entity.Property(g => g.GrupoNumero).HasColumnName("grupo_numero").HasMaxLength(10);
                entity.Property(g => g.Aula).HasColumnName("aula").HasMaxLength(50);
                entity.Property(g => g.CupoMax).HasColumnName("cupo_max");

                entity.HasOne(g => g.Materia)
                      .WithMany()
                      .HasForeignKey(g => g.IdMateria)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(g => g.Profesor)
                      .WithMany()
                      .HasForeignKey(g => g.IdProfesor)
                      .OnDelete(DeleteBehavior.Restrict);

            });

            //Configuracion de Horarios
            modelBuilder.Entity<Horario>(entity =>
            {
                entity.ToTable("HORARIOS");
                entity.HasKey(h => h.IdHorario);

                entity.Property(h => h.IdHorario).HasColumnName("id_horario");
                entity.Property(h => h.IdGrupo).HasColumnName("id_grupo");
                entity.Property(h => h.DiaSemana).HasColumnName("dia_semana").HasMaxLength(20);
                entity.Property(h => h.HoraInicio).HasColumnName("hora_inicio").HasColumnType("time(0)");
                entity.Property(h => h.HoraFin).HasColumnName("hora_fin").HasColumnType("time(0)");

                // FK hacia Grupo
                entity.HasOne(h => h.Grupo)
                      .WithMany()
                      .HasForeignKey(h => h.IdGrupo)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            //Configuracion de Pagos
            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("PAGOS");
                entity.HasKey(p => p.IdPago);

                entity.Property(p => p.IdPago).HasColumnName("id_pago");
                entity.Property(p => p.IdEstudiante).HasColumnName("id_estudiante");
                entity.Property(p => p.Monto).HasColumnName("monto").HasColumnType("decimal(18,2)"); // o "money"
                entity.Property(p => p.Fecha).HasColumnName("fecha");
                entity.Property(p => p.Estado).HasColumnName("estado").HasMaxLength(30);
                entity.Property(p => p.MetodoPago).HasColumnName("metodo_pago").HasMaxLength(30);

                // FK opcional hacia Estudiante
                entity.HasOne(p => p.Estudiante)
                      .WithMany()
                      .HasForeignKey(p => p.IdEstudiante)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
