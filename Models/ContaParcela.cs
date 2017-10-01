using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class ContaParcela
    {
        public int ContaParcelaId { get; set; }
        public DateTime Vencto { get; set; }
        public decimal Valor { get; set; }
        public bool? Ativo { get; set; }
        public bool? Pago { get; set; }
        public int UsuarioId { get; set; }
        public DateTime? PagoEm { get; set; }
        public decimal Desconto { get; set; }
        public decimal Juros { get; set; }
        public decimal TotalPago { get; set; }

        public Usuario Usuario { get; set; }
    }
}
