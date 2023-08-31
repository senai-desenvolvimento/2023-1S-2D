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
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que irá receber todos os métodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja referência aos métodos no repositório
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que aciona o método ListarTodos no repositório 
        /// </summary>
        /// <returns>Resposta para o usúário(front-end)</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista que recebe os dados da requisição
                List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

                //Retorna a lista no formato JSON com o status code Ok(200)
                return Ok(listaGeneros);

            }
            catch (Exception erro)
            {
                //Retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de cadastro de gênero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisição</param>
        /// <returns>Resposta para o usuário(front-end)</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                //Fazendo a chamada para o método cadastrar passando o objeto como parâmetro
                _generoRepository.Cadastrar(novoGenero);

                //Retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400(BadRequest) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de deletar gênero
        /// </summary>
        /// <param name="id">Id do gênero a ser deletado</param>
        /// <returns>Status Code</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Fazendo a chamada para o método deletar passando o id como parâmetro
                _generoRepository.Deletar(id);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                // Retorna um status 400 - BadRequest e o código do erro 
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de buscar por id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Status Code e objeto caso encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
                GeneroDomain generoBuscado  = _generoRepository.BuscarPorId(id);

                // Verifica se nenhum gênero foi encontrado
                if (generoBuscado == null)
                {
                    // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                    return NotFound("Nenhum gênero foi encontrado!");
                }

                // Caso seja encontrado, retorna o gênero buscado com um status code 200 - Ok
                return Ok(generoBuscado);
            }
            catch (Exception erro)
            {
                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um gênero existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto generoAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(GeneroDomain genero)
        {
            try
            {
                // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);

                // Verifica se algum gênero foi encontrado
                if (generoBuscado != null)
                {
                    // Tenta atualizar o registro
                    try
                    {
                        // Faz a chamada para o método .AtualizarIdCorpo();
                        _generoRepository.AtualizarIdCorpo(genero);

                        // Retorna um status code 204 - No Content
                        return StatusCode(204);
                    }
                    // Caso ocorra algum erro
                    catch (Exception erro)
                    {
                        // Retorna BadRequest e o erro
                        return BadRequest(erro.Message);
                    }
                }
                // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                return NotFound("Gênero não encontrado!");
            }
            catch (Exception erro)
            {
                // Retorna BadRequest e o erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um gênero existente passando o seu id pelo recurso
        /// </summary>
        /// <param name="id">id do gênero que será atualizado</param>
        /// <param name="genero">Objeto genero com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain genero)
        {
            try
            {
                // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                // Caso não seja encontrado
                if (generoBuscado == null)
                {
                    //retorna NotFound com uma mensagem personalizada
                    return NotFound("Genero não encontrado !");
                }

                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdUrl()
                    _generoRepository.AtualizarIdUrl(id, genero);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna um status 400 - BadRequest e o código do erro
                    return BadRequest(erro.Message);
                }
            }
            // Caso ocorra algum erro
            catch (Exception erro)
            {
                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro.Message);
            }
        }
    }
}
