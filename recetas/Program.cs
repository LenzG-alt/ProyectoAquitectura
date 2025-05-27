using Microsoft.EntityFrameworkCore;
using recetas.Data; // Asegúrate de tener este using

var builder = WebApplication.CreateBuilder(args);

// Agrega RecipeContext al contenedor de servicios con la cadena de conexión
builder.Services.AddDbContext<RecipeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<RecipeContext>();

    // Aplica migraciones si faltan
    //context.Database.Migrate();

    // Llama a tu método Seed
    SeedData.Initialize(context);
}

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
