using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{
    public class PresencaRepository : IPresencasEventoRepository
    {
        private readonly Event_Context _context;

        public PresencaRepository()
        {
            _context = new Event_Context();
        }

        public void Atualizar(Guid id, PresencasEvento presencaEvento)
        {
            try
            {
                PresencasEvento presencaEventoBuscado = _context.PresencasEvento.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    presencaEventoBuscado.Situacao = presencaEvento.Situacao;
                }

                _context.PresencasEvento.Update(presencaEventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PresencasEvento BuscarPorId(Guid id)
        {
            try
            {
                return _context.PresencasEvento
                    .Select(p => new PresencasEvento
                    {
                        IdPresencaEvento = p.IdPresencaEvento,
                        Situacao = p.Situacao,

                        Evento = new Evento
                        {
                            DataEvento = p.Evento!.DataEvento,
                            NomeEvento = p.Evento.NomeEvento,
                            Descricao = p.Evento.Descricao,

                            Instituicao = new Instituicao
                            {
                                NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                            }
                        }

                    }).FirstOrDefault(p => p.IdPresencaEvento == id)!;
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
                PresencasEvento presencaEventoBuscado = _context.PresencasEvento.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    _context.PresencasEvento.Remove(presencaEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Inscrever(PresencasEvento inscricao)
        {
            try
            {
                _context.PresencasEvento.Add(inscricao);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PresencasEvento> Listar()
        {
            try
            {
                return _context.PresencasEvento.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PresencasEvento> ListarMinhas(Guid id)
        {
            return _context.PresencasEvento
                .Select(p => new PresencasEvento
                {
                    IdPresencaEvento = p.IdPresencaEvento,
                    Situacao = p.Situacao,

                    Evento = new Evento
                    {
                        DataEvento = p.Evento!.DataEvento,
                        NomeEvento = p.Evento.NomeEvento,
                        Descricao = p.Evento.Descricao,

                        Instituicao = new Instituicao
                        {
                            NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                        }
                    }

                }).Where(p => p.IdUsuario == id).ToList();
        }
    }
}