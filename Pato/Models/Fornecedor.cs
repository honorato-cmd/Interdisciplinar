namespace Pato.Models
{
    public class Fornecedor : EnderecoFornecedor
    {
        public int IdFornecedor { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string inscricaoEstadual { get; set; }
        public string Atributo { get; set; }
    }
}