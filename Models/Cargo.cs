using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int CargoId { get; set; }
        public string Descricao { get; set; }
        public bool? Ativo { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
