using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class ProdutoCategoria
    {
        public ProdutoCategoria()
        {
            Produto = new HashSet<Produto>();
        }

        public int ProdutoCategoriaId { get; set; }
        public string Descricao { get; set; }
        public bool? Ativo { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<Produto> Produto { get; set; }
    }
}
