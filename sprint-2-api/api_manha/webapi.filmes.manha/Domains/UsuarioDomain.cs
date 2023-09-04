using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.manha.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }


        [Required(ErrorMessage ="O campo email é obrigatório!")]
        public string Email { get; set; }


        [StringLength(20,MinimumLength =3, ErrorMessage ="A senha deve ter de 3 á 20 caracteres")]
        [Required(ErrorMessage ="O campo senha é obrigatório!")]
        public string Senha { get; set; }

        public string Permissao { get; set; }
    }
}
