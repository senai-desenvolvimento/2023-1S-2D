using System;
using System.Collections.Generic;

namespace webapi.inlock.dbFirst.manha.Domains;

public partial class Estudio
{
    public Guid IdEstudio { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Jogo> Jogos { get; set; } = new List<Jogo>();
}
