using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class ProdutoPreco
    {
        public int ProdutoPrecoId { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }
        public Usuario Usuario { get; set; }
    }
}
