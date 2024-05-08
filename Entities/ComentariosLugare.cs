using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ComentariosLugare
    {
        public int ComentarioId { get; set; }
        public int? LugarId { get; set; }
        public int? UserId { get; set; }
        public string? Comentario { get; set; }
        public DateTime? FechaComentario { get; set; }

        public virtual Lugare? Lugar { get; set; }
        public virtual Usuario? User { get; set; }
    }
}
