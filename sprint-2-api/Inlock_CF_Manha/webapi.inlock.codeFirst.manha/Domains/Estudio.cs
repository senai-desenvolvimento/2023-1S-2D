using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.manha.Domains
{
    [Table("Estudio")]
    public class Estudio
    {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Nome do estúdio obrigatório!")]
        public string? Nome { get; set; }


        public List<Jogo>? Jogo { get; set; }
    }
}
