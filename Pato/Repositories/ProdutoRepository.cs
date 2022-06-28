using Pato.Models;
using System.Linq;

namespace Pato.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private List<Produto> produtos = new List<Produto>();

        public void Create(Produto produto)
        {
            produto.IdProduto = (int)DateTimeOffset.Now.ToUnixTimeMilliseconds();        
            produtos.Add(produto);
        }

        public List<Produto> Read()
        {
            return produtos;
        }
        
        public Produto Read(int id)
        {
            return produtos.Single(p => p.IdProduto == id);
        }

        public void Update(int id, Produto produto)
        {
            var p = produtos.Single(p => p.IdProduto == id);
            p.Nome = produto.Nome;
            p.Valor = produto.Valor;
            p.Estoque = produto.Estoque;
        }

        public void Delete(int id)
        {
            var produto = produtos.Single(p => p.IdProduto == id);
            produtos.Remove(produto);
        }

        public void Dispose()
        {
        }
        public List<Produto> ReadByFornecedor(int id)
        {
            throw new NotImplementedException();
        }
    }
}