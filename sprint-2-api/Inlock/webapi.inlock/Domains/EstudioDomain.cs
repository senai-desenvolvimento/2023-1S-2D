using System.ComponentModel.DataAnnotations;

namespace webapi.inlock.Domains
{
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "Campo do nome obrigatório ! ")]
        public string? Nome { get; set; }

        public List<JogoDomain>? ListaJogos { get; set; }
    }
}
