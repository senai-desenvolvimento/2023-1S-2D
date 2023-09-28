using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.Domains;
using webapi.inlock.Interfaces;
using webapi.inlock.Repositories;

namespace webapi.inlock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Cadastra um novo estúdio
        /// </summary>
        [HttpPost("Cadastrar")]
        public IActionResult Post(EstudioDomain estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);

                return Ok("Estudio Cadastrado !");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
            
        }

        /// <summary>
        /// Lista todos os estúdios cadastrados
        /// </summary>
        [HttpGet("Listar")]
        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> listaEstudios = _estudioRepository.Listar();

                return Ok(listaEstudios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }   
        }

        /// <summary>
        /// Lista todos os estúdios cadastrados
        /// </summary>
        [HttpGet("ListarComJogos")]
        public IActionResult GetWithGamers()
        {
            try
            {
                List<EstudioDomain> listaEstudios = _estudioRepository.ListarComJogos();

                return Ok(listaEstudios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
