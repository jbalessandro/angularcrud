using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class PedidoProduto
    {
        public int PedidoProdutoId { get; set; }
        public decimal Qtde { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public bool? Cancelado { get; set; }
        public int PedidoId { get; set; }
        public int PedidoProdutoSituacaoId { get; set; }

        public Pedido Pedido { get; set; }
        public PedidoProdutoSituacao PedidoProdutoSituacao { get; set; }
        public Usuario Usuario { get; set; }
    }
}
