using Pato.Models;

namespace Pato.Repositories
{
    public interface IOrcamentoRepository
    {
        void Create(Orcamento orcamento);
        List<Orcamento> Read();
        List<Orcamento> ReadByCliente(int id);
        Orcamento Read(int id);
        void Update(int id, Orcamento orcamento);
        void Delete(int id);
    }
}