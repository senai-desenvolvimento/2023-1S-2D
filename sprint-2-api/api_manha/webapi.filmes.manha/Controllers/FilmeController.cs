using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;
using webapi.filmes.manha.Repositories;

namespace webapi.filmes.manha.Controllers
{
    //Define que a rota de uma requisição será no seguinte formato
    //dominio/api/nomeController
    //ex: http://localhost:5000/api/genero
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Classe controladora que herda da controller base
    //Onde será criado os Endpoints (rotas)
    public class FilmeController : ControllerBase
    {
        /// <summary>
        /// Objeto _filmeRepository que irá receber todos os métodos definidos na interface IFilmeRepository
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _filmeRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }


        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Uma lista de filmes e um status code</returns>
        /// dominio/api/Filme
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Cria uma lista nomeada listaFilmes para receber os dados
                List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

                // Retorna o status code 200 (Ok) com a lista de gêneros no formato JSON
                return Ok(listaFilmes);
            }
            catch (Exception erro)
            {
                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }

        }


        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme recebido na requisição</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                // Faz a chamada para o método .Cadastrar()
                _filmeRepository.Cadastrar(novoFilme);

                // Retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }

        }


        /// <summary>
        /// Deleta um filme existente
        /// </summary>
        /// <param name="id">id do filme que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método .Deletar()
                _filmeRepository.Deletar(id);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }

        }


        /// <summary>
        /// Atualiza um filme existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="filmeAtualizado">Objeto filmeAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(FilmeDomain filmeAtualizado)
        {
            try
            {
                // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filmeAtualizado.IdFilme);

                // Verifica se algum gênero foi encontrado
                if (filmeBuscado != null)
                {
                    // Tenta atualizar o registro
                    try
                    {
                        // Faz a chamada para o método .AtualizarIdCorpo();
                        _filmeRepository.AtualizarIdCorpo(filmeAtualizado);

                        // Retorna um status code 204 - No Content
                        return NoContent();
                    }
                    // Caso ocorra algum erro
                    catch (Exception erro)
                    {
                        // Retorna BadRequest e o erro
                        return BadRequest(erro);
                    }

                }

                // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                // e um bool para representar que houve erro
                return NotFound
                    (
                        new
                        {
                            mensagem = "Filme não encontrado",
                            erro = true
                        }
                    );
            }
            catch (Exception erro)
            {

                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }

        }


        /// <summary>
        /// Atualiza um filme existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="id">id do filme que será atualizado</param>
        /// <param name="filmeAtualizado">Objeto filmeAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        /// http://localhost:5000/api/filme/3
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FilmeDomain filmeAtualizado)
        {
            try
            {
                // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                // e um bool para apresentar que houve erro
                if (filmeBuscado == null)
                {
                    return NotFound
                        (new
                        {
                            mensagem = "Filme não encontrado!",
                            erro = true
                        }
                        );
                }

                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdUrl()
                    _filmeRepository.AtualizarIdUrl(id, filmeAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna um status 400 - BadRequest e o código do erro
                    return BadRequest(erro);
                }
            }
            catch (Exception erro)
            {

                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }

        }


        /// <summary>
        /// Busca um filme através do seu id
        /// </summary>
        /// <param name="id">id do filme que será buscado</param>
        /// <returns>Um filme buscado ou NotFound caso nenhum filme seja encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Cria um objeto filmeBuscado que irá receber o filme buscado no banco de dados
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                // Verifica se nenhum filme foi encontrado
                if (filmeBuscado == null)
                {
                    // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                    return NotFound("Nenhum filme encontrado!");
                }

                // Caso seja encontrado, retorna o filme buscado com um status code 200 - Ok
                return Ok(filmeBuscado);
            }
            catch (Exception erro)
            {

                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }


        }
    }
}
