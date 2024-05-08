using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class UsuariosActividade
    {
        public int? UserId { get; set; }
        public int? ActividadId { get; set; }
        public DateTime? FechaRealizacion { get; set; }

        public virtual ActividadesPorHacer? Actividad { get; set; }
        public virtual Usuario? User { get; set; }
    }
}
