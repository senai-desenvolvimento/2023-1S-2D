using webapi.inlock.Domains;

namespace webapi.inlock.Interfaces
{
    public interface IEstudioRepository
    {
        void Cadastrar(EstudioDomain estudio);

        List<EstudioDomain> Listar();

        List<EstudioDomain> ListarComJogos();
    }
}
