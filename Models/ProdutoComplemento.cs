using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class ProdutoComplemento
    {
        public int ProdutoId { get; set; }
        public int ComplementoId { get; set; }

        public Complemento Complemento { get; set; }
        public Produto Produto { get; set; }
    }
}
