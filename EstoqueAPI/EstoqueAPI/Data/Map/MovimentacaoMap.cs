using EstoqueAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueAPI.Data.Map
{
    public class MovimentacaoMap : IEntityTypeConfiguration<MovimentacaoModel>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoModel> builder)
        {
            builder.HasKey(x => x.MovimentacaoId);
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.DataMovimentacao).IsRequired();
            builder.HasOne(m => m.Produto).WithMany(p => p.Movimentacao).HasForeignKey(m => m.ProdutoId); // Define o relacionamento 1:N entre Produto e Movimentação,utilizando ProdutoId como chave estrangeira na tabela de Movimentações
        }
    }
}
