using System.ComponentModel.DataAnnotations;

namespace webapi.inlock.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        public int IdEstudio { get; set; }


        [Required(ErrorMessage = "Campo do nome obrigatório ! ")]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "Campo da descrição obrigatório ! ")]
        public string? Descricao { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo da data do lançamento obrigatório ! ")]
        public DateTime DataLancamento { get; set; }


        [Required(ErrorMessage = "Campo do valor obrigatório ! ")]
        public decimal Valor { get; set; }


        //referência - Estudio
        public EstudioDomain? Estudio { get; set; }

    }
}
