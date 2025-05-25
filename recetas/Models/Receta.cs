using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace recetas.Models
{
    public class Receta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los ingredientes son requeridos")]
        public string Ingredients { get; set; } = string.Empty;

        [Required(ErrorMessage = "Las instrucciones son requeridas")]
        public string Instructions { get; set; } = string.Empty;

        [Range(1, 480, ErrorMessage = "El tiempo de preparación debe estar entre 1 y 480 minutos")]
        public int PreparationTime { get; set; }

        [Range(1, 10, ErrorMessage = "Las porciones deben estar entre 1 y 10")]
        public int Servings { get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        public string Category { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dificultad es requerida")]
        public string Difficulty { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsFavorite { get; set; } = false;

        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5")]
        public int Rating { get; set; } = 5;
    }
}
