using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class Conta
    {
        public int ContaId { get; set; }
        public DateTime PedidoEm { get; set; }
        public bool? Ativo { get; set; }
        public int UsuarioId { get; set; }
        public int FornecedorId { get; set; }
        public int ContaCategoriaId { get; set; }

        public ContaCategoria ContaCategoria { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Usuario Usuario { get; set; }
    }
}
