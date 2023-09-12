using System.ComponentModel.DataAnnotations;

namespace webapi.inlock.Domains
{
    public class TipoUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "Informe o tipo do usuário !")]
        public string Titulo { get; set; }
    }
}
