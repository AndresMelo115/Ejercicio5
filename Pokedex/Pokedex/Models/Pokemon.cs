using System;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public partial class Pokemon
    {
        public int PokeId { get; set; }
        public string Nombre { get; set; }
        public int Tipo1 { get; set; }
        public int? Tipo2 { get; set; }
        public int Region { get; set; }
        public string Move1 { get; set; }
        public string Move2 { get; set; }
        public string Move3 { get; set; }
        public string Move4 { get; set; }
        public string Foto { get; set; }

        public virtual Regiones RegionNavigation { get; set; }
        public virtual Tipos Tipo1Navigation { get; set; }
        public virtual Tipos Tipo2Navigation { get; set; }
    }
}
