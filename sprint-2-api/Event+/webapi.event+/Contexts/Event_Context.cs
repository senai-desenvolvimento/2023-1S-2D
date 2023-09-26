using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using webapi.event_.Domains;

namespace webapi.event_.Contexts
{
    /// <summary>
    /// Classe de contexto que faz referências as tabelas e define string de conexão
    /// </summary>
    public class Event_Context : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<TiposEvento> TiposEvento { get; set; }

        public DbSet<Evento> Evento { get; set; }

        public DbSet<ComentariosEvento> ComentariosEvento { get; set; }

        public DbSet<Instituicao> Instituicao { get; set; }

        public DbSet<PresencasEvento> PresencasEvento { get; set; }

        /// <summary>
        /// Define as opções de construção do banco
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as configurações definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string conexão local Carlos
            //optionsBuilder.UseSqlServer("Server=DESKTOP-B541VSR; Database=event+; Integrated Security=True; TrustServerCertificate=true;");
            //base.OnConfiguring(optionsBuilder);

            //string conexão local Eduardo
            //optionsBuilder.UseSqlServer("Server=localhost; Database=event+; User Id = sa; Pwd = 999999; TrustServerCertificate=true;");

            //string conexão banco azure
            optionsBuilder.UseSqlServer("Server = tcp:eventbd.database.windows.net,1433; Initial Catalog = eventbd; Encrypt = True; TrustServerCertificate = true; Connection Timeout = 30; Authentication = \"Active Directory Default\";");
            base.OnConfiguring(optionsBuilder);

        }
    }
}