using webapi.filmes.manha.Domains;

namespace webapi.filmes.manha.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// Definir os métodos que serão implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //TipoRetorno NomeMetodo(TipoParâmetro NomeParâmetro)

        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Atualizar objeto existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto atualizado (novas informações)</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar objeto existente passando o seu id pela url 
        /// </summary>
        /// <param name="id">Id do objeto que será atualizado</param>
        /// <param name="genero">Objeto atualizado(novas informações)</param>
        void AtualizarIdUrl(int id,GeneroDomain genero);

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
        GeneroDomain BuscarPorId(int id);
    }
}
