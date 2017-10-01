using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace angularapp.Models
{
    public partial class CHAMONIXContext : DbContext
    {
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Complemento> Complemento { get; set; }
        public virtual DbSet<Conta> Conta { get; set; }
        public virtual DbSet<ContaCategoria> ContaCategoria { get; set; }
        public virtual DbSet<ContaParcela> ContaParcela { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<Mesa> Mesa { get; set; }
        public virtual DbSet<MesaSituacao> MesaSituacao { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoProduto> PedidoProduto { get; set; }
        public virtual DbSet<PedidoProdutoSituacao> PedidoProdutoSituacao { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ProdutoCategoria> ProdutoCategoria { get; set; }
        public virtual DbSet<ProdutoComplemento> ProdutoComplemento { get; set; }
        public virtual DbSet<ProdutoEstoque> ProdutoEstoque { get; set; }
        public virtual DbSet<ProdutoPreco> ProdutoPreco { get; set; }
        public virtual DbSet<Ramo> Ramo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        public CHAMONIXContext(DbContextOptions<CHAMONIXContext> options)
            :base(options)
        {

        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Data Source=ALE-PC\ALE;Initial Catalog=CHAMONIX;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Complemento>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.PedidoEm).HasColumnType("date");

                entity.HasOne(d => d.ContaCategoria)
                    .WithMany(p => p.Conta)
                    .HasForeignKey(d => d.ContaCategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ContaCategoria_Conta");

                entity.HasOne(d => d.Fornecedor)
                    .WithMany(p => p.Conta)
                    .HasForeignKey(d => d.FornecedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fornecedor_Conta");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Conta)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_Conta");
            });

            modelBuilder.Entity<ContaCategoria>(entity =>
            {
                entity.Property(e => e.AlteradoEm).HasColumnType("date");

                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ContaCategoria)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_ContaCategoria");
            });

            modelBuilder.Entity<ContaParcela>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Desconto)
                    .HasColumnType("decimal(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Juros)
                    .HasColumnType("decimal(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Pago).HasDefaultValueSql("((0))");

                entity.Property(e => e.PagoEm).HasColumnType("date");

                entity.Property(e => e.TotalPago)
                    .HasColumnType("decimal(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Valor).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Vencto).HasColumnType("date");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ContaParcela)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_ContaParcela");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.AlteradoEm).HasColumnType("date");

                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Estado)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_Estado");
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.Property(e => e.AlteradoEm).HasColumnType("date");

                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fantasia)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Ie)
                    .HasColumnName("IE")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Fornecedor)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Estado_Fornecedor");

                entity.HasOne(d => d.Ramo)
                    .WithMany(p => p.Fornecedor)
                    .HasForeignKey(d => d.RamoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ramo_Fornecedor");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Fornecedor)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_Fornecedor");
            });

            modelBuilder.Entity<Mesa>(entity =>
            {
                entity.Property(e => e.Ativa).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.MesaSituacao)
                    .WithMany(p => p.Mesa)
                    .HasForeignKey(d => d.MesaSituacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MesaSituacao_Mesa");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Mesa)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_Mesa");
            });

            modelBuilder.Entity<MesaSituacao>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.Pessoas).HasDefaultValueSql("((1))");

                entity.Property(e => e.Preco)
                    .HasColumnType("decimal(12, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Mesa)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.MesaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Mesa_Pedido");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_Pedido");
            });

            modelBuilder.Entity<PedidoProduto>(entity =>
            {
                entity.Property(e => e.Cancelado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Qtde).HasColumnType("decimal(12, 2)");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.PedidoProduto)
                    .HasForeignKey(d => d.PedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pedido_PedidoProduto");

                entity.HasOne(d => d.PedidoProdutoSituacao)
                    .WithMany(p => p.PedidoProduto)
                    .HasForeignKey(d => d.PedidoProdutoSituacaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PedidoProdutoSituacao_PedidoProduto");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.PedidoProduto)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_PedidoProduto");
            });

            modelBuilder.Entity<PedidoProdutoSituacao>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.PedidoProdutoSituacao)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_PedidoProdutoSituacao");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.BaixarEstoque).HasDefaultValueSql("((0))");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ProdutoMenu).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ProdutoCategoria)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.ProdutoCategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProdutoCategoria_Produto");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_Produto");
            });

            modelBuilder.Entity<ProdutoCategoria>(entity =>
            {
                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ProdutoCategoria)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_ProdutoCategoria");
            });

            modelBuilder.Entity<ProdutoComplemento>(entity =>
            {
                entity.HasKey(e => new { e.ProdutoId, e.ComplementoId });

                entity.HasOne(d => d.Complemento)
                    .WithMany(p => p.ProdutoComplemento)
                    .HasForeignKey(d => d.ComplementoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Complemento_ProdutoComplemento");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.ProdutoComplemento)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Produto_ProdutoComplemento");
            });

            modelBuilder.Entity<ProdutoEstoque>(entity =>
            {
                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.ProdutoEstoque)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Produto_ProdutoEstoque");
            });

            modelBuilder.Entity<ProdutoPreco>(entity =>
            {
                entity.Property(e => e.DtFim).HasColumnType("date");

                entity.Property(e => e.DtInicio).HasColumnType("date");

                entity.Property(e => e.PrecoCusto).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.PrecoVenda).HasColumnType("decimal(12, 2)");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.ProdutoPreco)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Produto_ProdutoPreco");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.ProdutoPreco)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_ProdutoPreco");
            });

            modelBuilder.Entity<Ramo>(entity =>
            {
                entity.Property(e => e.AlteradoEm).HasColumnType("date");

                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Ramo)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_Ramo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.AlteradoEm).HasColumnType("date");

                entity.Property(e => e.Ativo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Logon)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.CargoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cargo_Usuario");
            });
        }
    }
}
