using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class Mesa
    {
        public Mesa()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int MesaId { get; set; }
        public string Descricao { get; set; }
        public bool? Ativa { get; set; }
        public int UsuarioId { get; set; }
        public int MesaSituacaoId { get; set; }

        public MesaSituacao MesaSituacao { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
    }
}
