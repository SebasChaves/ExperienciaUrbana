using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Lugare
    {
        public Lugare()
        {
            ComentariosLugares = new HashSet<ComentariosLugare>();
        }

        public int LugarId { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public double? Calificacion { get; set; }

        public virtual ICollection<ComentariosLugare> ComentariosLugares { get; set; }
    }
}
