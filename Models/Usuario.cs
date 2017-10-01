using System;
using System.Collections.Generic;

namespace angularapp.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Conta = new HashSet<Conta>();
            ContaCategoria = new HashSet<ContaCategoria>();
            ContaParcela = new HashSet<ContaParcela>();
            Estado = new HashSet<Estado>();
            Fornecedor = new HashSet<Fornecedor>();
            Mesa = new HashSet<Mesa>();
            Pedido = new HashSet<Pedido>();
            PedidoProduto = new HashSet<PedidoProduto>();
            PedidoProdutoSituacao = new HashSet<PedidoProdutoSituacao>();
            Produto = new HashSet<Produto>();
            ProdutoCategoria = new HashSet<ProdutoCategoria>();
            ProdutoPreco = new HashSet<ProdutoPreco>();
            Ramo = new HashSet<Ramo>();
        }

        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Logon { get; set; }
        public string Senha { get; set; }
        public bool? Ativo { get; set; }
        public DateTime AlteradoEm { get; set; }
        public int CargoId { get; set; }

        public Cargo Cargo { get; set; }
        public ICollection<Conta> Conta { get; set; }
        public ICollection<ContaCategoria> ContaCategoria { get; set; }
        public ICollection<ContaParcela> ContaParcela { get; set; }
        public ICollection<Estado> Estado { get; set; }
        public ICollection<Fornecedor> Fornecedor { get; set; }
        public ICollection<Mesa> Mesa { get; set; }
        public ICollection<Pedido> Pedido { get; set; }
        public ICollection<PedidoProduto> PedidoProduto { get; set; }
        public ICollection<PedidoProdutoSituacao> PedidoProdutoSituacao { get; set; }
        public ICollection<Produto> Produto { get; set; }
        public ICollection<ProdutoCategoria> ProdutoCategoria { get; set; }
        public ICollection<ProdutoPreco> ProdutoPreco { get; set; }
        public ICollection<Ramo> Ramo { get; set; }
    }
}
