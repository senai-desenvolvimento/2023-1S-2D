using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento evento);
        void Deletar(Guid id);
        List<Evento> Listar();
        List<Evento> ListarProximos();
        Evento BuscarPorId(Guid id);
        void Atualizar(Guid id, Evento evento);
    }
}
