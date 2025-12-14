using EstoqueAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoqueAPI.Data.Map
{
    public class FornecedorMap : IEntityTypeConfiguration<FornecedorModel>
    {
        public void Configure(EntityTypeBuilder<FornecedorModel> builder)
        {
            builder.HasKey(x => x.FornecedorId);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(255); // Essa linha informa que temos uma varial chamda Descricao, que é obrigatório seu preenchimento e tem o limite o maximo de 225 caracteres
            builder.Property(x => x.CNPJ).IsRequired().HasMaxLength(14);
            builder.HasMany(f => f.Produtos).WithOne(p => p.Fornecedor).HasForeignKey(p => p.FornecedorId); // Configura o relacionamento 1:N entre Fornecedor e Produto, utilizando FornecedorId como chave estrangeira na tabela de Produtos.
        }
    }
}
