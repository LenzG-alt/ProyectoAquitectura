using Microsoft.EntityFrameworkCore;
using recetas.Data; // Aseg�rate de tener este using

var builder = WebApplication.CreateBuilder(args);

// Agrega RecipeContext al contenedor de servicios con la cadena de conexi�n
builder.Services.AddDbContext<RecipeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
