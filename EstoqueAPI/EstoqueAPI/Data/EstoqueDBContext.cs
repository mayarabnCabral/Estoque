using Microsoft.EntityFrameworkCore;
using EstoqueAPI.Models;

namespace EstoqueAPI.Data
{
    public class EstoqueDBContext : DbContext // DbContext → Classe responsável por fazer a comunicação entre a aplicação e o banco de dados
    {
        public EstoqueDBContext(DbContextOptions<EstoqueDBContext> options)// Construtor que recebe as configurações do banco (string de conexão, provedor etc.)
        // Essas configurações são repassadas para a classe base DbContext.
        // DbSet -> Representa uma tabela no banco de dados.
        // Cada DbSet se torna uma tabela e cada objeto de UsuarioModel será um registro.
        : base(options)
        { 

        }

        public DbSet<ProdutoModel>  Produtos { get; set; } // Representa a tabela de Produtos no banco de dados
        public DbSet<FornecedorModel> Fornecedores { get; set; } // Representa a tabela de Fornecedores no banco de dados
        public DbSet <MovimentacaoModel> Movimentacoes { get; set; } // Representa a tabela de Movimentacoes no banco de dados

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Configurações os relacionamentos da entidade
        {


            // Inicio Produto

            modelBuilder.Entity<ProdutoModel>()
                .HasKey(p => p.ProdutoId);

            // Fim Produto



            // Inicio Fornecedor

            // Define explicitamente a chave primária da entidade FornecedorModel
            modelBuilder.Entity<FornecedorModel>()
                .HasKey(f => f.FornecedorId);

            // Relacionamento 1:N entre Fornecedor e Produto
            modelBuilder.Entity<FornecedorModel>() // Informa que vou configurar a entidade FornecedorModel
                .HasMany(f => f.Produtos) // Informa que o Fornecedor pode ter muitos produtos
                .WithOne(p => p.Fornecedor) // Cada produto está relacionado a um único fornecedor
                .HasForeignKey(p => p.FornecedorId); // FK localizada em ProdutoModel

            // Fim Fornecedor


            // Inicio Movimentação

            // Define explicitamente a chave primária da entidade MovimentacaoModel
            modelBuilder.Entity<MovimentacaoModel>()
                .HasKey(m => m.MovimentacaoId);

            // Relacionamento 1:N entre Produto e Movimentação
            modelBuilder.Entity<MovimentacaoModel>()
                .HasOne(m => m.Produto) // Uma movimentação possui um produto
                .WithMany(p => p.Movimentacao) // Um produto pode ter várias movimentações
                .HasForeignKey(m => m.ProdutoId); // FK localizada em MovimentacaoModel
            
            // Fim Movimentação
            base.OnModelCreating(modelBuilder);
        }
    }
}
