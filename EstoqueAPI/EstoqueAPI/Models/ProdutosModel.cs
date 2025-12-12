namespace EstoqueAPI.Models
{
    public class ProdutosModel
    {
        public int ProdutoId { get; set; } // Identificador de produto
        public string ? Descricao { get; set; } // Nome/descrição do produto

        public int ? Quantidade { get; set; } // Qauntidade do produto 

        public int IdFornecedor { get; set; }
        public FornecedorModel Fornecedor { get; set; } //Relacionamento com tabela Fornecedor

        public List<MovimentacoesModel> Movimentacao { get; set; } = new List<MovimentacoesModel>(); //Relacionamento com tabela Movimentacao

    }
}
