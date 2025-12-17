using EstoqueAPI.Data.Map;
using EstoqueAPI.Models;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<ProdutoModel> Produtos { get; set; } // Representa a tabela de Produtos no banco de dados
        public DbSet<FornecedorModel> Fornecedores { get; set; } // Representa a tabela de Fornecedores no banco de dados
        public DbSet<MovimentacaoModel> Movimentacoes { get; set; } // Representa a tabela de Movimentacoes no banco de dados
     


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap()); // Aplica as configurações de mapeamento do Produto (sem isso o EF ignora o map)
            modelBuilder.ApplyConfiguration(new MovimentacaoMap()); // Aplica as configurações de mapeamento do Movimentaçao (sem isso o EF ignora o map)
            modelBuilder.ApplyConfiguration(new FornecedorMap()); // Aplica as configurações de mapeamento do Fornecedor (sem isso o EF ignora o map)

            base.OnModelCreating(modelBuilder); // Depois de aplicar as minhas regras pode executar também as regras padrão do EF core
        }
    }
}

