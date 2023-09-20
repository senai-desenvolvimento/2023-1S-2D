using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data do evento é obrigatória!")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage ="Nome do evento é obrigatório!")]
        public string? NomeEvento { get; set; }

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage ="A descrição do evento é obrigatório!")]
        public string? Descricao { get; set; }

        //ref.tabela TipoEvento = FK
        [Required(ErrorMessage ="Tipo do evento é obrigatório!")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TipoEvento? TipoEvento { get; set; }


        //ref.tabela Instituicao = FK
        [Required(ErrorMessage ="A instituição é obrigatória!")]
        public Guid IdInstituicao { get; set; }

        [ForeignKey (nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }

    }
}
