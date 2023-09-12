using System.Data.SqlClient;
using webapi.inlock.Domains;
using webapi.inlock.Interfaces;

namespace webapi.inlock.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source=DESKTOP-B541VSR; Initial Catalog= inlock_games; Integrated Security = True";

        public void Cadastrar(EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Estudio (Nome) VALUES (@Nome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", estudio.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> Listar()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdEstudio,Nome FROM Estudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[0]),
                            Nome = rdr[1].ToString()
                        };

                        listaEstudio.Add(estudio);
                    }
                }
            }

            return listaEstudio;
        }

        public List<EstudioDomain> ListarComJogos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection conEstudios = new SqlConnection(StringConexao))
            {
                string querySelectAllStudio = "SELECT IdEstudio, Nome FROM Estudio";

                conEstudios.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectAllStudio, conEstudios))
                {
                    SqlDataReader rdrEstudio = cmd.ExecuteReader();

                    while (rdrEstudio.Read())
                    {
                        //cria a lista de jogos para cada estúdio
                        List<JogoDomain> listaJogos = new List<JogoDomain>();

                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdrEstudio["IdEstudio"]),
                            Nome = rdrEstudio["Nome"].ToString()!
                        };

                        using (SqlConnection conJogos = new SqlConnection(StringConexao))
                        {

                            string querySelectAllGames = "SELECT IdJogo, Nome, Descricao, DataLancamento, Valor FROM Jogo WHERE IdEstudio = @IdEstudio";

                            conJogos.Open();

                            using (SqlCommand cmdGames = new SqlCommand(querySelectAllGames, conJogos))
                            {
                                cmdGames.Parameters.AddWithValue("@IdEstudio", estudio.IdEstudio);

                                SqlDataReader readerGames =  cmdGames.ExecuteReader();

                                while (readerGames.Read())
                                {
                                    JogoDomain jogo = new JogoDomain()
                                    {
                                        IdJogo = Convert.ToInt32(readerGames["IdJogo"]),

                                        Nome = readerGames["Nome"].ToString()!,

                                        Descricao = readerGames["Descricao"].ToString()!,

                                        DataLancamento = Convert.ToDateTime(readerGames["DataLancamento"]),

                                        Valor = Convert.ToDecimal(readerGames["Valor"])
                                    };

                                    listaJogos.Add(jogo);
                                }
                            }

                            estudio.ListaJogos = listaJogos;

                            listaEstudios.Add(estudio);
                        }
                    }
                }
            }

            // Retorna a lista de estúdios
            return listaEstudios;
        }
    }
}