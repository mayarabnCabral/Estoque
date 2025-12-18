using EstoqueAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EstoqueAPI.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.ProdutoId); // Chave Primaria
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(255); // Essa linha informa que temos uma varial chamda Descricao, que é obrigatório seu preenchimento e tem o limite o maximo de 225 caracteres
            builder.Property(x => x.Quantidade).IsRequired();
            builder.HasOne(p => p.Fornecedor).WithMany(f => f.Produtos).HasForeignKey(p => p.FornecedorId).IsRequired(false).OnDelete(DeleteBehavior.SetNull); ; ; // Relacionamento 1:N
            builder.Property(x => x.Preco).IsRequired().HasPrecision(18, 2);
        }
    }
}
