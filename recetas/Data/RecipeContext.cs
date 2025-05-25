using Microsoft.EntityFrameworkCore;
using recetas.Models;

namespace recetas.Data
{
    public class RecipeContext(DbContextOptions<RecipeContext> options) : DbContext(options)
    {
        public DbSet<Receta> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
