namespace EstoqueAPI.Models
{
    public class FornecedorModel
    {

        public int FornecedorId { get; set; }

        public string ? CNPJ {  get; set; } // Utilizado o tipo string, pois o int pode tirar o 0 e ultrapassa (Mínimo: -2.147.483.648 Máximo:  2.147.483.647)
        public string ? Descricao { get; set; }

        public List<ProdutoModel> Produtos { get; set; } = new List<ProdutoModel>();

    }
}
