using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoProduto = new HashSet<PedidoProduto>();
        }

        public int PedidoId { get; set; }
        public int MesaId { get; set; }
        public DateTime DtInicio { get; set; }
        public decimal Preco { get; set; }
        public int UsuarioId { get; set; }
        public int Pessoas { get; set; }

        public Mesa Mesa { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<PedidoProduto> PedidoProduto { get; set; }
    }
}
