using System.Text.Json.Serialization;
using EstoqueAPI.Enums;

namespace EstoqueAPI.Models
{
    public class MovimentacaoModel
    {
        public int MovimentacaoId { get; set; }

        // Inicio FK de produtos
        public int ProdutoId { get; set; }
        [JsonIgnore]
        public ProdutoModel ? Produto { get; set; }
        // Fim FK de produtos
        public MovimentacaoEnum Tipo { get; set; }
        public int Quantidade { get; set; }

        public DateTime DataMovimentacao { get; set; } = DateTime.Now;

    }
}
