using webapi.inlock.Domains;

namespace webapi.inlock.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string email, string senha);
    }
}
