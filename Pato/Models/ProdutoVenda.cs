namespace Pato.Models
{
    public class ProdutoVenda
    {
        public int IdPv { get; set; }
        public int IdProduto { get; set; }
        public string Produto { get; set; }
        public int qtd { get; set; }
        public int IdVenda { get; set; }
        public decimal Valor { get; set; }
    }
}