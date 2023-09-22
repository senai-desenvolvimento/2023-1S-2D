using webapi.event_.Domains;

namespace webapi.event_.Interfaces
{
    public interface IPresencasEventoRepository
    {
        void Deletar(Guid id);
        List<PresencasEvento> Listar();
        PresencasEvento BuscarPorId(Guid id);
        void Atualizar(Guid id, PresencasEvento presencaEvento);
        List<PresencasEvento> ListarMinhas(Guid id);
        void Inscrever(PresencasEvento inscricao);
    }
}