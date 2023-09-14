using Microsoft.EntityFrameworkCore;
using webapi.inlock.codeFirst.manha.Domains;

namespace webapi.inlock.codeFirst.manha.Contexts
{
    public class InlockContext : DbContext
    {
        //Define as entidades do banco de dados
        public DbSet<TiposUsuario> TipoUsuario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Estudio> Estudio { get; set; }

        public DbSet<Jogo> Jogo { get; set; }

        /// <summary>
        /// Define as opções de construção do banco(String Conexão)
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as configurações definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-B541VSR; Database=inLock_games_codeFirst_manha; Integrated Security=True; TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}