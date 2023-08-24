using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Filme
    /// </summary>
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "O título do filme é obrigatório!")]
        public string? Titulo { get; set; }
        public int IdGenero { get; set; }


        //Referência para a classe Genero
        public GeneroDomain? Genero { get; set; }
    }
}
