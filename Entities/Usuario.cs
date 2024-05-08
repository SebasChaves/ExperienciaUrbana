using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            ComentariosLugares = new HashSet<ComentariosLugare>();
            ComentariosRestaurantes = new HashSet<ComentariosRestaurante>();
        }

        public int UserId { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }

        public virtual ICollection<ComentariosLugare> ComentariosLugares { get; set; }
        public virtual ICollection<ComentariosRestaurante> ComentariosRestaurantes { get; set; }
    }
}
