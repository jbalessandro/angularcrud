using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class Ramo
    {
        public Ramo()
        {
            Fornecedor = new HashSet<Fornecedor>();
        }

        public int RamoId { get; set; }
        public string Descricao { get; set; }
        public bool? Ativo { get; set; }
        public DateTime AlteradoEm { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<Fornecedor> Fornecedor { get; set; }
    }
}
