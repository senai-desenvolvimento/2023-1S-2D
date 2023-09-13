using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codeFirst.manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade Jogo
    /// </summary>
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage ="Nome do jogo é obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage ="Descrição do jogo obrigatório!")]
        public string? Descricao { get; set; }

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage ="Data de lançamento obrigatório!")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName ="Decimal(4,2)")]
        [Required(ErrorMessage ="Preço do jogo obrigatório!")]
        public decimal Preco { get; set; }


        //Referência da Chave estrangeira (Tabela de Estúdio)

        [Required(ErrorMessage ="Informe o estúdio que produziu o jogo")]
        public Guid IdEstudio { get; set; }


        [ForeignKey("IdEstudio")]
        public Estudio? Estudio { get; set; }
    }
}
