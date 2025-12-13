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

        public DbSet<ProdutosModel>  Produtos { get; set; } // Representa a tabela de Produtos no banco de dados
        public DbSet<FornecedorModel> Fornecedores { get; set; } // Representa a tabela de Fornecedores no banco de dados
        public DbSet <MovimentacoesModel> Movimentacoes { get; set; } // Representa a tabela de Movimentacoes no banco de dados

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Configurações os relacionamentos da entidade
        {
            modelBuilder.Entity<FornecedorModel>() // Informa que vou configurar a entidade FornecedorModel (Tudo que vier a seguir será sobre como os FornecedorModel se relacionam com outras entidades)
                .HasMany(f => f.Produtos) //Informa que o OFrnecedor pode ter muitos produtos
                .WithOne(p => p.Fornecedor) // Informa que cada produto está relacionado a um unico fornecedor
                .HasForeignKey(p => p.IdFornecedor); // Informamos qual prorpiewdade em ProdutosModelé a FK (Chave estrangeira)
        }
    }
}
