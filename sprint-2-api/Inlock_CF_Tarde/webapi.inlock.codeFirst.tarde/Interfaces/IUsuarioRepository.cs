using webapi.inlock.codeFirst.tarde.Domains;

namespace webapi.inlock.codeFirst.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuario(string email, string senha);

        void Cadastrar(Usuario usuario);
    }
}
