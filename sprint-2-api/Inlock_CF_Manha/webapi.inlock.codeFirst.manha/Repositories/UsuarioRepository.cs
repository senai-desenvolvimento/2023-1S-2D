using webapi.inlock.codeFirst.manha.Contexts;
using webapi.inlock.codeFirst.manha.Domains;
using webapi.inlock.codeFirst.manha.Interfaces;
using webapi.inlock.codeFirst.manha.Utils;

namespace webapi.inlock.codeFirst.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        ///Variável privada e somente leitura para armazenar os dados do contexto
        /// </summary>
        private readonly InlockContext ctx;

        /// <summary>
        /// Construtor do repositório
        /// Toda vez que o repositório for instanciado,
        /// Ele terá acesso aos dados fornecidos pelo contexto
        /// </summary>
        public UsuarioRepository()
        {
            ctx = new InlockContext();
        }

        public Usuario BuscarUsuario(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                
                ctx.Usuario.Add(usuario);

                
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}