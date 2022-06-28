using Pato.Models;

namespace Pato.Repositories
{
    public interface IProdutoRepository
    {
        void Create(Produto produto);
        List<Produto> Read();
        List<Produto> ReadByFornecedor(int id);
        Produto Read(int id);
        void Update(int id, Produto produto);
        void Delete(int id);
    }
}