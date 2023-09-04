using webapi.filmes.manha.Domains;

namespace webapi.filmes.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string email, string senha);
    }
}
