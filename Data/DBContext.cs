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
            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("ESTUDIANTES");

                entity.HasKey(e => e.IdEstudiante);

                entity.Property(e => e.IdEstudiante).HasColumnName("id_estudiante");
                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
                entity.Property(e => e.Carnet).HasColumnName("carnet").HasMaxLength(20).IsRequired();
                entity.Property(e => e.Telefono).HasColumnName("telefono").HasMaxLength(20);
                entity.Property(e => e.Direccion).HasColumnName("direccion").HasMaxLength(200);
                entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");

                
                //entity.HasOne(e => e.Usuario)
                  //    .WithOne() 
                    //  .HasForeignKey<Estudiante>(e => e.IdUsuario);
            });
        }

    }
}
