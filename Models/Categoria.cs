using System;
using System.Collections.Generic;

namespace APICatalogo;

public partial class Categoria
{
    public int CategoriaId { get; set; }

    public string? Nome { get; set; }

    public string? ImagemUrl { get; set; }

    public virtual ICollection<Produto> Produtos { get; } = new List<Produto>();
}
