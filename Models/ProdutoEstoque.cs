using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class ProdutoEstoque
    {
        public int ProdutoEstoqueId { get; set; }
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }
    }
}
