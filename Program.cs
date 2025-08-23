using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using SistemaEducativoADB.API.Data;
using SistemaEducativoADB.API.Repositories.Implementatios;
using SistemaEducativoADB.API.Repositories.Interfaces;
using SistemaEducativoADB.API.Services;
using SistemaEducativoADB.API.Services.Interfaces;

namespace SistemaEducativoADB.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Controllers + JSON
            builder.Services.AddControllers()
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            // Swagger: registra el DOC "v1"
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SistemaEducativoADB.API",
                    Version = "v1",
                    Description = "API del sistema educativo"
                });
            });

            // DbContext
            builder.Services.AddDbContext<DBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();
            builder.Services.AddScoped<ICarreraRepository, CarreraRepository>();
            builder.Services.AddScoped<IMateriaRepository, MateriaRepository>();
            builder.Services.AddScoped<IProfesorRepository, ProfesorRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();
            builder.Services.AddScoped<IGruposRepository, GruposRepository>();
            builder.Services.AddScoped<IHorariosRepository, HorariosRepository>();
            builder.Services.AddScoped<IPagosRepository, PagosRepository>();

            // Services
            builder.Services.AddScoped<IEstudianteService, EstudianteService>();
            builder.Services.AddScoped<ICarreraService, CarreraService>();
            builder.Services.AddScoped<IMateriaService, MateriaService>();
            builder.Services.AddScoped<IProfesorService, ProfesorService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IMatriculaService, MatriculaService>();
            builder.Services.AddScoped<IGruposService, GruposService>();
            builder.Services.AddScoped<IHorariosService, HorariosService>();
            builder.Services.AddScoped<IPagosService, PagosService>();

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                    p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            var app = builder.Build();

            // Swagger habilitado, UI en /swagger (coincide con launchSettings)
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemaEducativoADB.API v1");
                c.RoutePrefix = "swagger";   // UI = /swagger
            });

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
