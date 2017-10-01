using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            Conta = new HashSet<Conta>();
        }

        public int FornecedorId { get; set; }
        public string Fantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public bool? Ativo { get; set; }
        public DateTime AlteradoEm { get; set; }
        public int UsuarioId { get; set; }
        public int RamoId { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
        public int EstadoId { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }

        public Estado Estado { get; set; }
        public Ramo Ramo { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Conta> Conta { get; set; }
    }
}
