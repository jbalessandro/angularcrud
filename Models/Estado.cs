using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Fornecedor = new HashSet<Fornecedor>();
        }

        public int EstadoId { get; set; }
        public string Uf { get; set; }
        public bool? Ativo { get; set; }
        public DateTime AlteradoEm { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<Fornecedor> Fornecedor { get; set; }
    }
}
