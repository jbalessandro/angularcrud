using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class PedidoProdutoSituacao
    {
        public PedidoProdutoSituacao()
        {
            PedidoProduto = new HashSet<PedidoProduto>();
        }

        public int PedidoProdutoSituacaoId { get; set; }
        public string Descricao { get; set; }
        public bool? Ativo { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<PedidoProduto> PedidoProduto { get; set; }
    }
}
