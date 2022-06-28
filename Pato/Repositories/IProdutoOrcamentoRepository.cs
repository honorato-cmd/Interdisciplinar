using Pato.Models;

namespace Pato.Repositories
{
    public interface IProdutoOrcamentoRepository
    {
        void Create(ProdutoOrcamento produtoOrcamento);
        List<ProdutoOrcamento> Read();
        List<ProdutoOrcamento> ReadByOrcamento(int id);
        ProdutoOrcamento Read(int id);
        void Update(int id, ProdutoOrcamento produtoOrcamento);
        void Delete(int id);
    }
}