using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {
        private readonly Event_Context _context;

        public TiposEventoRepository()
        {
            _context = new Event_Context();
        }

        public void Atualizar(Guid id, TiposEvento tipoEvento)
        {
            try
            {
                TiposEvento tipoBuscado = _context.TiposEvento.Find(id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.Titulo = tipoEvento.Titulo;
                }

                _context.TiposEvento.Update(tipoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TiposEvento BuscarPorId(Guid id)
        {
            try
            {
                return _context.TiposEvento.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TiposEvento tipoEvento)
        {
            try
            {
                _context.TiposEvento.Add(tipoEvento);

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
                TiposEvento tipoBuscado = _context.TiposEvento.Find(id)!;

                if (tipoBuscado != null)
                {
                    _context.TiposEvento.Remove(tipoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TiposEvento> Listar()
        {
            try
            {
                return _context.TiposEvento.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}