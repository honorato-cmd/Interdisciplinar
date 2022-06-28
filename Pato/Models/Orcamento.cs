namespace Pato.Models
{
    public class Orcamento
    {
        public int IdOrcamento { get; set; }
        public DateTime Data { get; set; }
        public decimal valorLiquido { get; set; }
        public decimal Desconto { get; set; }
        public decimal valorBruto { get; set; }
        public int IdPessoa { get; set; }
        public string Cliente { get; set; }
        public int IdProduto { get; set; }
        public string Produto { get; set; }
        public decimal ValorUnit { get; set; }
        public int qtd { get; set; }
    }
}