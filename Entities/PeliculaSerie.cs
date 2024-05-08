using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class PeliculaSerie
    {
        public int PeliculaSerieId { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
        public string? Imagen { get; set; }
        public string? Descripcion { get; set; }
        public string? FechaEstreno { get; set; }
    }
}
