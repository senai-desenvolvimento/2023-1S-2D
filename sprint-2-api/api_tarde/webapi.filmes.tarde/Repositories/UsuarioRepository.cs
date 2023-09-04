using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = DESKTOP-B541VSR; Initial Catalog = Filmes; Integrated Security = true";

        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT IdUsuario,Email,Permissao FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryLogin,con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Permissao = rdr["Permissao"].ToString()
                        };
                        return usuario;
                    }
                    return null;

                }
            }    
        }
    }
}
