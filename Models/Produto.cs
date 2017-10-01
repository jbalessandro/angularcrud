using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class Produto
    {
        public Produto()
        {
            ProdutoComplemento = new HashSet<ProdutoComplemento>();
            ProdutoEstoque = new HashSet<ProdutoEstoque>();
            ProdutoPreco = new HashSet<ProdutoPreco>();
        }

        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public bool? Ativo { get; set; }
        public int UsuarioId { get; set; }
        public int ProdutoCategoriaId { get; set; }
        public bool? BaixarEstoque { get; set; }
        public bool? ProdutoMenu { get; set; }

        public ProdutoCategoria ProdutoCategoria { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<ProdutoComplemento> ProdutoComplemento { get; set; }
        public ICollection<ProdutoEstoque> ProdutoEstoque { get; set; }
        public ICollection<ProdutoPreco> ProdutoPreco { get; set; }
    }
}
