using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recetas.Data;
using recetas.Models;

namespace recetas.Controllers
{
    public class HomeController : Controller
    {
        private readonly RecipeContext _context;

        public HomeController(RecipeContext context)
        {
            _context = context;
        }

        // GET: Recipe
        public async Task<IActionResult> Index(string searchString, string category, string difficulty)
        {
            var recipes = from r in _context.Recipes select r;

            if (!string.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(r => r.Name.Contains(searchString) ||
                                           r.Description.Contains(searchString) ||
                                           r.Ingredients.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(category))
            {
                recipes = recipes.Where(r => r.Category == category);
            }

            if (!string.IsNullOrEmpty(difficulty))
            {
                recipes = recipes.Where(r => r.Difficulty == difficulty);
            }

            ViewBag.Categories = await _context.Recipes.Select(r => r.Category).Distinct().ToListAsync();
            ViewBag.Difficulties = await _context.Recipes.Select(r => r.Difficulty).Distinct().ToListAsync();

            return View(await recipes.OrderByDescending(r => r.CreatedAt).ToListAsync());
        }

        // GET: Recipe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipe/Create// Mostrar formulario
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Ingredients,Instructions,PreparationTime,Servings,Category,Difficulty,ImageUrl,Rating")] Receta recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.CreatedAt = DateTime.Now;
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Ingredients,Instructions,PreparationTime,Servings,Category,Difficulty,ImageUrl,CreatedAt,IsFavorite,Rating")] Receta recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Recipe/ToggleFavorite/5
        [HttpPost]
        public async Task<IActionResult> ToggleFavorite(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                recipe.IsFavorite = !recipe.IsFavorite;
                await _context.SaveChangesAsync();
                return Json(new { success = true, isFavorite = recipe.IsFavorite });
            }
            return Json(new { success = false });
        }

        // GET: Recipe/Favorites
        public async Task<IActionResult> Favorites()
        {
            var favoriteRecipes = await _context.Recipes
                .Where(r => r.IsFavorite)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return View(favoriteRecipes);
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }

    }
}

