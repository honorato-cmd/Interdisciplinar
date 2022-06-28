using Pato.Models;

namespace Pato.Repositories
{
    public interface IFornecedorRepository
    {
        void Create(Fornecedor fornecedor);
        List<Fornecedor> Read();
        Fornecedor Read(int id);
        void Update(int id, Fornecedor fornecedor);
        void Delete(int id);
    }
}