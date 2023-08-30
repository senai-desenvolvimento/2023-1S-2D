using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os seguintes parâmetros:
        /// Data Source : Nome do servidor do banco
        /// Initial Catalog: Nome do banco de dados
        /// Autenticação
        ///     - windows : Integrated Security = True
        ///     -SqlServer : User Id = sa; Pwd = Senha
        /// </summary>
        private string StringConexao = "Data Source = DESKTOP-B541VSR; Initial Catalog = Filmes; Integrated Security=True";
        //private string StringConexao = "Data Source = DESKTOP-B541VSR; Initial Catalog = Filmes; User Id = sa; Pwd = 1234";


        /// <summary>
        /// Atualizar um gênero passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto com as novas informações</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateIdBody = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                // Abre a conexão com o banco de dados
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um gênero passando o id pelo recurso
        /// </summary>
        /// <param name="id">id do gênero que será atualizado</param>
        /// <param name="genero">objeto gênero com as novas informações</param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateUrl = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                // Abre a conexão com o banco de dados
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Buscar um gênero através do seu id
        /// </summary>
        /// <param name="id">Id do gênero a ser buscado</param>
        /// <returns>Objeto buscado</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            //Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                // Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectById,con))
                {
                    // Passa o valor para o parâmetro @IdGenero
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        // Se sim, instancia um novo objeto generoBuscado do tipo GeneroDomain
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            // Atribui à propriedade IdGenero o valor da coluna "IdGenero" da tabela do banco de dados
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            // Atribui à propriedade Nome o valor da coluna "Nome" da tabela do banco de dados
                            Nome = rdr["Nome"].ToString()
                        };
                        // Retorna o generoBuscado com os dados obtidos
                        return generoBuscado;
                    }
                    // Se não, retorna null
                    return null;
                }
            }
        }


        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryInsert = "INSERT INTO Genero(Nome) VALUES (@Nome)";

                //Declara o SqlCommand passando a query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    // Passa o valor do parâmetro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Delatar um gênero
        /// </summary>
        /// <param name="id">Id do gênero a ser deletado</param>
        public void Deletar(int id)
        {
            //Declara a conexão passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @IdGenero";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlCommand passando a query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Passa o valor do parâmetro @IdGenero
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    //executar a query (queryInsert)
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Listar todos os objetos do tipo genero
        /// </summary>
        /// <returns>Lista de objetos do tipo gênero</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de generos onde será armazenados os generos
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr
                    //o laço se repetirá
                    while(rdr.Read())
                    {
                        //Instancia um objeto do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero o valor da 
                            //coluna IdGenero
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade Nome o valor da 
                            //coluna Nome
                            Nome = rdr["Nome"].ToString()
                        };

                        //Adiciona o objeto criado dentro da lista 
                        listaGeneros.Add(genero);
                    }
                }
            }
            //Retorna a lista de gêneros
            return listaGeneros;
        }
    }
}
