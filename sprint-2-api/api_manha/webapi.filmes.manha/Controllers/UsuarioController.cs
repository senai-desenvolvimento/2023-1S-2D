using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.manha.Domains;
using webapi.filmes.manha.Interfaces;
using webapi.filmes.manha.Repositories;

namespace webapi.filmes.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou Senha Inválidos !");
            }

            return Ok(usuarioBuscado);
        }
    }
}
