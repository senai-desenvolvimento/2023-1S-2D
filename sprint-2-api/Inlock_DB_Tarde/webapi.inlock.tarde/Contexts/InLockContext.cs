using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.inlock.tarde.Domains;

namespace webapi.inlock.tarde.Contexts;

public partial class InLockContext : DbContext
{
    public InLockContext()
    {
    }

    public InLockContext(DbContextOptions<InLockContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estudio> Estudios { get; set; }

    public virtual DbSet<Jogo> Jogos { get; set; }

    public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-B541VSR; initial catalog=inlock_games_dbFirst_tarde; Integrated Security=True; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudio>(entity =>
        {
            entity.HasKey(e => e.IdEstudio).HasName("PK__Estudio__0C3B43559755A522");

            entity.ToTable("Estudio");

            entity.Property(e => e.IdEstudio).ValueGeneratedNever();
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Jogo>(entity =>
        {
            entity.HasKey(e => e.IdJogo).HasName("PK__Jogo__69E08513137E40EB");

            entity.ToTable("Jogo");

            entity.Property(e => e.IdJogo).ValueGeneratedNever();
            entity.Property(e => e.DataLancamento).HasColumnType("date");
            entity.Property(e => e.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("smallmoney");

            entity.HasOne(d => d.IdEstudioNavigation).WithMany(p => p.Jogos)
                .HasForeignKey(d => d.IdEstudio)
                .HasConstraintName("FK__Jogo__IdEstudio__4BAC3F29");
        });

        modelBuilder.Entity<TiposUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__TiposUsu__CA04062B4C4FD19F");

            entity.ToTable("TiposUsuario");

            entity.Property(e => e.IdTipoUsuario).ValueGeneratedNever();
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF9750025269");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoUsuario)
                .HasConstraintName("FK__Usuario__IdTipoU__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
