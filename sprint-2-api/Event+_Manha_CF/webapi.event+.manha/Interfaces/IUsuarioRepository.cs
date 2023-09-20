using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        void Cadastrar(Usuario usuario);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Usuario BuscarPorId(Guid id);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        Usuario BuscarPorEmailESenha(string email, string senha);
    }
}