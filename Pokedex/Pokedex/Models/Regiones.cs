using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public partial class Regiones
    {
        public Regiones()
        {
            Pokemon = new HashSet<Pokemon>();
        }

        public int RegId { get; set; }
        public string NombreR { get; set; }

        public virtual ICollection<Pokemon> Pokemon { get; set; }
    }
}
