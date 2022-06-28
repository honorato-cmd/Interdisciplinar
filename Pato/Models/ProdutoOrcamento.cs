namespace Pato.Models
{
    public class ProdutoOrcamento
    {
        public int IdPo { get; set; }
        public int IdProduto { get; set; }
        public int IdOrcamento { get; set; }
        public int qtd { get; set; }
        public string Produto { get; set; }
        public decimal Valor { get; set; }
    }
}