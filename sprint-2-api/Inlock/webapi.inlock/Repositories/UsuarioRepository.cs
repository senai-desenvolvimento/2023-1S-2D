using System.Data.SqlClient;
using webapi.inlock.Domains;
using webapi.inlock.Interfaces;

namespace webapi.inlock.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source=DESKTOP-B541VSR; Initial Catalog= inlock_games; Integrated Security = True";

        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            { 
                string querySelect = "SELECT IdUsuario,IdTipoUsuario,Email,Senha FROM Usuario WHERE Email = @Email AND Senha = @Senha;";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString()
                        };
                        return usuario;
                    }
                    return null;
                }
            }
        }
    }
}
