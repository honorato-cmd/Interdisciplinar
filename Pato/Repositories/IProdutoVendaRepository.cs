using Pato.Models;

namespace Pato.Repositories
{
    public interface IProdutoVendaRepository
    {
        void Create(ProdutoVenda produtoVenda);
        List<ProdutoVenda> ReadByVenda(int id);
        List<ProdutoVenda> Read();
        ProdutoVenda Read(int id);
        void Update(int id, ProdutoVenda produtoVenda);
        void Delete(int id);
    }
}