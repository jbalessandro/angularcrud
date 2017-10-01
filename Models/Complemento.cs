using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class Complemento
    {
        public Complemento()
        {
            ProdutoComplemento = new HashSet<ProdutoComplemento>();
        }

        public int ComplementoId { get; set; }
        public string Descricao { get; set; }
        public bool? Ativo { get; set; }

        public ICollection<ProdutoComplemento> ProdutoComplemento { get; set; }
    }
}
