using System.Data.SqlClient;
using System.Runtime.CompilerServices;
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
        
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
