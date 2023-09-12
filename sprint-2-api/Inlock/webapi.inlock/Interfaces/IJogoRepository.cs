using webapi.inlock.Domains;

namespace webapi.inlock.Interfaces
{
    public interface IJogoRepository
    {
        void Cadastrar(JogoDomain jogo);

        List<JogoDomain> Listar();

    }
}
