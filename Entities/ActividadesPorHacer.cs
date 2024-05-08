using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class ActividadesPorHacer
    {
        public int ActividadId { get; set; }
        public string? Nombre { get; set; }
        public DateTime? Fecha { get; set; }
        public bool? Realizada { get; set; }
    }
}
