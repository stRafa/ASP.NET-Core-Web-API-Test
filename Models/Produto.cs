using System;
using System.Collections.Generic;
using APICatalogo.Models;

namespace APICatalogo;

public partial class Produto
{
    public int ProdutoId { get; set; }

    public string? Nome { get; set; }

    public string? Descricao { get; set; }

    public decimal Preco { get; set; }

    public string? ImagemUrl { get; set; }

    public double Estoque { get; set; }

    public DateTime DataCadastro { get; set; }

    public int CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;
}
