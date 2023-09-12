using System.Data.SqlClient;
using webapi.inlock.Domains;
using webapi.inlock.Interfaces;

namespace webapi.inlock.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source=DESKTOP-B541VSR; Initial Catalog= inlock_games; Integrated Security = True";
        public void Cadastrar(JogoDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Jogo (IdEstudio,Nome,Descricao,DataLancamento,Valor)" +
                                     "VALUES (@IdEstudio,@Nome,@Descricao,@DataLancamento,@Valor)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", jogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> Listar()
        {
            List<JogoDomain> listaJogo = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT Jogo.Nome,Jogo.IdJogo,Jogo.IdEstudio,Jogo.Descricao,Jogo.DataLancamento,Jogo.Valor,Estudio.Nome FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            Nome = rdr[0].ToString(),
                            IdJogo = Convert.ToInt32(rdr[1]),
                            IdEstudio = Convert.ToInt32(rdr[2]),
                            Descricao = rdr[3].ToString(),
                            DataLancamento = Convert.ToDateTime(rdr[4]),
                            Valor = Convert.ToDecimal(rdr[5]),

                            Estudio = new EstudioDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr[2]),
                                Nome = rdr[6].ToString()
                            }
                        };

                        listaJogo.Add(jogo);
                    }
                }
            }

            return listaJogo;
        }
    }
}
