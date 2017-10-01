using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class MesaSituacao
    {
        public MesaSituacao()
        {
            Mesa = new HashSet<Mesa>();
        }

        public int MesaSituacaoId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Mesa> Mesa { get; set; }
    }
}
