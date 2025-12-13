namespace EstoqueAPI.Models
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; } // Identificador de produto
        public string ? Descricao { get; set; } // Nome/descrição do produto

        public int ? Quantidade { get; set; } // Qauntidade do produto 

        public int FornecedorId { get; set; }
        public FornecedorModel ? Fornecedor { get; set; } //Relacionamento com tabela Fornecedor

        public List<MovimentacaoModel> Movimentacao { get; set; } = new List<MovimentacaoModel>(); //Relacionamento com tabela Movimentacao

    }
}
