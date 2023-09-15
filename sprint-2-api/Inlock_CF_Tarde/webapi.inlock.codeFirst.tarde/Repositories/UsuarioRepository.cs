using webapi.inlock.codeFirst.tarde.Contexts;
using webapi.inlock.codeFirst.tarde.Domains;
using webapi.inlock.codeFirst.tarde.Interfaces;
using webapi.inlock.codeFirst.tarde.Utils;

namespace webapi.inlock.codeFirst.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly InlockContext ctx;

        public UsuarioRepository()
        {
            ctx = new InlockContext();
        }

        public Usuario BuscarUsuario(string email, string senha)
        {
            try
            {
                var usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email);

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
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