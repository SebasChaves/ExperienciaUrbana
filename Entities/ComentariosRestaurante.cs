using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ComentariosRestaurante
    {
        public int ComentarioId { get; set; }
        public int? RestauranteId { get; set; }
        public int? UserId { get; set; }
        public string? Comentario { get; set; }
        public DateTime? FechaComentario { get; set; }

        public virtual Restaurante? Restaurante { get; set; }
        public virtual Usuario? User { get; set; }
    }
}
