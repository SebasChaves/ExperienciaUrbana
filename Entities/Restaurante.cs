using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Restaurante
    {
        public Restaurante()
        {
            ComentariosRestaurantes = new HashSet<ComentariosRestaurante>();
        }

        public int RestauranteId { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public double? Calificacion { get; set; }

        public virtual ICollection<ComentariosRestaurante> ComentariosRestaurantes { get; set; }
    }
}
