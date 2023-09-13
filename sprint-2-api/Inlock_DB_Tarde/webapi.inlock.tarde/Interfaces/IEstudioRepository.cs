using webapi.inlock.tarde.Domains;

namespace webapi.inlock.tarde.Interfaces
{
    public interface IEstudioRepository
    {
        List<Estudio> Listar();

        Estudio BuscarPorId(Guid id);

        void Cadastrar(Estudio estudio);

        void Atualizar(Guid id, Estudio estudio);

        void Deletar(Guid id);

        List<Estudio> ListarComJogos();
    }
}
