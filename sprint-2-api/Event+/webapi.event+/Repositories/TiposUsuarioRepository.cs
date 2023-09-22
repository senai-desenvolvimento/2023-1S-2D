using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly Event_Context _context;

        public TiposUsuarioRepository()
        {
            _context = new Event_Context();
        }

        public void Atualizar(Guid id, TiposUsuario tipoUsuario)
        {
            try
            {
                TiposUsuario tipoBuscado = _context.TiposUsuario.Find(id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.Titulo = tipoUsuario.Titulo;
                }

                _context.TiposUsuario.Update(tipoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            try
            {
                return _context.TiposUsuario.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            try
            {
                _context.TiposUsuario.Add(tipoUsuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                TiposUsuario tipoBuscado = _context.TiposUsuario.Find(id)!;

                if (tipoBuscado != null)
                {
                    _context.TiposUsuario.Remove(tipoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TiposUsuario> Listar()
        {
            try
            {
                return _context.TiposUsuario.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}