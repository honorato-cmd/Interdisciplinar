namespace Pato.Models
{
    public class Produto
    {
        // propriedades
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Estoque { get; set; }
        public int IdFornecedor { get; set; }
        public string Fornecedor { get; set; }
    }
}