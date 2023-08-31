using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source = DESKTOP-B541VSR; Initial Catalog = Filmes; Integrated Security = true";

        /// <summary>
        /// Atualiza um filme passando o id pelo corpo
        /// </summary>
        /// <param name="filme">Objeto filme com as novas informações</param>
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateBody = "UPDATE Filme SET Filme.IdGenero = @IdGenero, Filme.Titulo = @Titulo WHERE IdFilme = @IFilme";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@IFilme", filme.IdFilme);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Atualiza um filme passando o id pelo recurso
        /// </summary>
        /// <param name="id">id do filme que será atualizado</param>
        /// <param name="filme">objeto filme com as novas informações</param>
        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateUrl = "UPDATE Filme SET Filme.IdGenero = @IdGenero, Filme.Titulo = @Titulo WHERE IdFilme = @IFilme";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@IFilme", id);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Busca um filme através do seu id
        /// </summary>
        /// <param name="id">id do filme que será buscado</param>
        /// <returns>Um filme buscado ou null caso não seja encontrado</returns>
        public FilmeDomain BuscarPorId(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "SELECT Filme.IdFilme, Filme.Titulo, Filme.IdGenero, Genero.Nome FROM Filme INNER JOIN Genero ON Filme.IdGenero = Genero.IdGenero";

                // Abre a conexão com o banco de dados
                con.Open();

                // Deckara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        // Instancia um objeto filme do tipo FilmeDomain
                        FilmeDomain filmeBuscado = new FilmeDomain()
                        {

                            // Atribui à propriedade idFilme o valor da coluna "IdFilme" tabela do banco de dados
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            // Atribui à propriedade nome o valor da coluna "Titulo" da tabela do banco de dados
                            Titulo = (string)rdr["Titulo"],

                            // Atribui à propriedade idGenero o valor "Genero" coluna da tabela do banco de dados
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),


                            Genero = new GeneroDomain()
                            {
                                // Atribui à propriedade Nome o valor "Genero" coluna da tabela do banco de dados
                                Nome = (string)rdr["Nome"]
                            }
                        };

                        // Retorna o generoBuscado com os dados obtidos
                        return filmeBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }


        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novoFilme com as informações que serão cadastradas</param>
        public void Cadastrar(FilmeDomain novoFilme)
        {
            // Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO Filme(IdGenero,Titulo) VALUES (@IdGenero,@Titulo)";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);


                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Deleta um filme através do seu id
        /// </summary>
        /// <param name="id">id do filme que será deletado</param>
        public void Deletar(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query a ser executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM Filme WHERE IdFilme = @ID";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Define o valor do id recebido no método como o valor do parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Uma lista de filmes</returns>
        public List<FilmeDomain> ListarTodos()
        {
            // Cria uma lista listaFilmes onde serão armazenados os dados
            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT Filme.IdFilme, Filme.IdGenero, Filme.Titulo, Genero.Nome FROM Filme INNER JOIN Genero ON Filme.IdGenero = Genero.IdGenero";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto filme do tipo FilmeDomain
                        FilmeDomain filme = new FilmeDomain()
                        {
                            // Atribui à propriedade idFilme o valor da coluna "IdFilme" tabela do banco de dados
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            // Atribui à propriedade idGenero o valor "IdGenero" coluna da tabela do banco de dados
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            // Atribui à propriedade nome o valor da coluna "Titulo" da tabela do banco de dados
                            Titulo = rdr["Titulo"].ToString(),

                            Genero = new GeneroDomain()
                            {
                                // Atribui à propriedade idGenero o valor "IdGenero" coluna da tabela do banco de dados
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                                // Atribui à propriedade Nome o valor "Genero" coluna da tabela do banco de dados
                                Nome = rdr["Nome"].ToString()
                            }
                        };
                        // Adiciona o objeto filme criado à lista listaFilmes
                        ListaFilmes.Add(filme);
                    }
                }
            }
            return ListaFilmes;
        }
    }
}
