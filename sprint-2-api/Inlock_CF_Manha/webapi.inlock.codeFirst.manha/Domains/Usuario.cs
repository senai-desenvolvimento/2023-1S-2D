using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.manha.Domains
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Email obrigatório")]
        public string? Email { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Senha obrigatória!")]
        [StringLength(20, MinimumLength =6, ErrorMessage ="Senha de 6 á 20 caracteres")]
        public string? Senha { get; set; }


        //Referência da Chave estrangeira (Tabela de TiposUsuario)

        [Required(ErrorMessage ="Tipo do usuário obrigatório")]
        public Guid IdTipoUsuario { get; set; }


        [ForeignKey("IdTipoUsuario")]
        public TiposUsuario? TipoUsuario { get; set; }
    }
}