using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class RestauranteViewModel
    {
        public int RestauranteId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El nombre no puede tener más de 30 caracteres.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [MaxLength(30, ErrorMessage = "La dirección no puede tener más de 30 caracteres.")]
        public string? Direccion { get; set; }

        [Range(1, 10, ErrorMessage = "La calificación debe estar en el rango de 1 a 10.")]
        public double? Calificacion { get; set; }
    }
}
