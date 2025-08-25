using Microsoft.AspNetCore.Authentication.Cookies;
using SistemaEducativo.Frontend.Services;


var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Frontend/Login";
        options.AccessDeniedPath = "/Frontend/AccesoDenegado";
    });


builder.Services.AddRazorPages();

// Registrar tu servicio
builder.Services.AddScoped<ICarreraApiService, CarreraApiService>();
// O si usas HttpClient:
builder.Services.AddHttpClient<ICarreraApiService, CarreraApiService>();  


var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "https://localhost:5071/";




var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapGet("/", () => Results.Redirect("/Dashboad/Index"));

app.MapRazorPages();

app.Run();
