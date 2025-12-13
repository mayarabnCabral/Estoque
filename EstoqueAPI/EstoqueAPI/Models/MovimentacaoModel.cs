namespace EstoqueAPI.Models
{
    // Inicio da "configurãção" do Enum
    public enum TipoDeMovimentacao
    {
        Entrada = 1,
        Saida = 2
    }
    // Fim da "configurãção" do Enum
    public class MovimentacaoModel
    {
        public int MovimentacaoId { get; set; }

        // Inicio FK de produtos
        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }
        // Fim FK de produtos
        public TipoDeMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }

        public DateTime DataMovimentacao { get; set; } = DateTime.Now;

    }
}
