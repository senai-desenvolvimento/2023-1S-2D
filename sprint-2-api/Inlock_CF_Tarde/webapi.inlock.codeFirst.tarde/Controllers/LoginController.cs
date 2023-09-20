using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codeFirst.tarde.Domains;
using webapi.inlock.codeFirst.tarde.Interfaces;
using webapi.inlock.codeFirst.tarde.Repositories;
using webapi.inlock.codeFirst.tarde.ViewModels;

namespace webapi.inlock.codeFirst.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarUsuario(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401,"Email ou senha inválidos!");
                }

                //Agora é com vocês, se divirtam
                //Faça a lógica de criação do token e depois
                //a configuração do jwt na program.cs
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
