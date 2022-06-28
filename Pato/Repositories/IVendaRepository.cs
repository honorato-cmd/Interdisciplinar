using Pato.Models;

namespace Pato.Repositories
{
    public interface IVendaRepository
    {
        void Create(Venda venda);
        List<Venda> Read();
        List<Venda> ReadByCliente(int id);
        Venda Read(int id);
        void Update(int id, Venda venda);
        void Delete(int id);
    }
}