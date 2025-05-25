using recetas.Data;

using recetas.Models;

namespace recetas.Data
{
    public static class SeedData
    {
        public static void Initialize(RecipeContext context)
        {
            if (context.Recipes.Any())
            {
                return;
            }

            var recipes = new Receta[]
            {
                new Receta
                {
                    Name = "Paella Valenciana",
                    Description = "Tradicional paella española con pollo, conejo y verduras",
                    Ingredients = "Arroz bomba, Pollo, Conejo, Judías verdes, Garrofón, Tomate, Pimiento rojo, Azafrán, Aceite de oliva, Sal",
                    Instructions = "1. Calentar aceite en paellera\n2. Sofreír pollo y conejo\n3. Añadir verduras\n4. Incorporar tomate y pimiento\n5. Agregar arroz y azafrán\n6. Cocinar 18-20 minutos",
                    PreparationTime = 45,
                    Servings = 6,
                    Category = "Plato Principal",
                    Difficulty = "Intermedio",
                    ImageUrl = "https://images.unsplash.com/photo-1534080564583-6be75777b70a?w=400",
                    IsFavorite = true,
                    Rating = 5
                },
                new Receta
                {
                    Name = "Tacos al Pastor",
                    Description = "Deliciosos tacos mexicanos con carne marinada",
                    Ingredients = "Carne de cerdo, Tortillas, Piña, Cebolla, Cilantro, Salsa verde, Achiote, Chile guajillo",
                    Instructions = "1. Marinar la carne con achiote\n2. Cocinar en trompo\n3. Cortar carne y piña\n4. Servir en tortillas\n5. Agregar cebolla y cilantro",
                    PreparationTime = 30,
                    Servings = 4,
                    Category = "Plato Principal",
                    Difficulty = "Fácil",
                    ImageUrl = "https://images.unsplash.com/photo-1565299624946-b28f40a0ca4b?w=400",
                    IsFavorite = false,
                    Rating = 4
                },
                new Receta
                {
                    Name = "Tiramisú",
                    Description = "Postre italiano cremoso con café y mascarpone",
                    Ingredients = "Mascarpone, Huevos, Azúcar, Café espresso, Bizcochos de soletilla, Cacao en polvo, Marsala",
                    Instructions = "1. Preparar crema de mascarpone\n2. Remojar bizcochos en café\n3. Alternar capas\n4. Refrigerar 4 horas\n5. Espolvorear cacao",
                    PreparationTime = 20,
                    Servings = 8,
                    Category = "Postre",
                    Difficulty = "Intermedio",
                    ImageUrl = "https://images.unsplash.com/photo-1571877227200-a0d98ea607e9?w=400",
                    IsFavorite = true,
                    Rating = 5
                }
            };

            context.Recipes.AddRange(recipes);
            context.SaveChanges();
        }
    }
}
