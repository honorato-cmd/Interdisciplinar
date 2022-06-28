using Pato.Models;

namespace Pato.Repositories
{
    public interface ILoginRepository
    {
        Login Read(Login login);
    }
}