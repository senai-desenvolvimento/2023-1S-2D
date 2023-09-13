using Microsoft.AspNetCore.Mvc;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;
using webapi.inlock.tarde.Repositories;

namespace webapi.inlock.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository;

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_estudioRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarComJogos")]
        public IActionResult GetWithGames()
        {
            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _estudioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Estudio estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_estudioRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id,Estudio estudio)
        {
            try
            {
                _estudioRepository.Atualizar(id, estudio);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}