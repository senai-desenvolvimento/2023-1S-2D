using webapi.filmes.manha.Domains;

namespace webapi.filmes.manha.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FilmeRepository
    /// Definir os métodos que serão implementados pelo FilmeRepository
    /// </summary>
    public interface IFilmeRepository
    {
        //TipoRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Cadastrar um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto que será cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Atualizar objeto existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objeto atualizado (novas informações)</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualizar objeto existente passando o seu id pela url 
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="filme)">Objeto atualizado(novas informações)</param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um objeto através do seu id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        FilmeDomain BuscarPorId(int id);

    }
}
