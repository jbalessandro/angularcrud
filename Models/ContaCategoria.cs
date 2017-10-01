using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class ContaCategoria
    {
        public ContaCategoria()
        {
            Conta = new HashSet<Conta>();
        }

        public int ContaCategoriaId { get; set; }
        public string Descricao { get; set; }
        public bool? Ativo { get; set; }
        public DateTime AlteradoEm { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<Conta> Conta { get; set; }
    }
}
