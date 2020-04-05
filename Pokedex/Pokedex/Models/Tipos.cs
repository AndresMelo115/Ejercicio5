using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public partial class Tipos
    {
        public Tipos()
        {
            PokemonTipo1Navigation = new HashSet<Pokemon>();
            PokemonTipo2Navigation = new HashSet<Pokemon>();
        }

        public int TiposId { get; set; }
        public string NombreT { get; set; }

        public virtual ICollection<Pokemon> PokemonTipo1Navigation { get; set; }
        public virtual ICollection<Pokemon> PokemonTipo2Navigation { get; set; }
    }
}
