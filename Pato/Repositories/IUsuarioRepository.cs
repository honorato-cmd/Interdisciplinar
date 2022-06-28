using Pato.Models;

namespace Pato.Repositories
{
    public interface IUsuarioRepository
    {
        void Create(Usuario usuario);
        List<Usuario> Read();
        Usuario Read(int id);
        void Update(int id, Usuario usuario);
        void Delete(int id);
        Usuario Read(string Login, string Senha);
    }
}