using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ActividadesPorHacerViewModel
    {
        public int ActividadId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El nombre no puede tener más de 30 caracteres.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La fecha es obligatorio.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [FechaNoPasada(ErrorMessage = "La fecha no puede ser un día pasado.")]
        public DateTime? Fecha { get; set; }
        public bool? Realizada { get; set; }
    }
    public class FechaNoPasadaAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime fechaIngresada = (DateTime)value;
            return fechaIngresada >= DateTime.Now.Date;
        }
    }
}
