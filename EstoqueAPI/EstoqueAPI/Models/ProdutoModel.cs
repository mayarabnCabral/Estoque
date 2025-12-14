using System.Text.Json.Serialization;

namespace EstoqueAPI.Models
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; } // Identificador de produto
        public required string Descricao { get; set; } // Nome/descrição do produto

        public int Quantidade { get; set; } // Qauntidade do produto 

        public decimal Preco { get; set; } // Qauntidade do produto 

 
        public int ? FornecedorId { get; set; }
        [JsonIgnore]
        public FornecedorModel ? Fornecedor { get; set; } //Relacionamento com tabela Fornecedor, o ? indica que a variavel pode ser nula 

        public List<MovimentacaoModel> Movimentacao { get; set; } = new List<MovimentacaoModel>(); //Relacionamento com tabela Movimentacao

    }
}
