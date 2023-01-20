using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Models;

public partial class BaltaContext : DbContext
{
    public BaltaContext()
    {
    }

    public BaltaContext(DbContextOptions<BaltaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.254.13.83;Database=balta; User ID=eptvbkend;Password=i9r2t0e1c9!;Connection Timeout=900;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId);

            entity.Property(e => e.ImagemUrl).HasMaxLength(80);
            entity.Property(e => e.Nome).HasMaxLength(80);
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.ToTable("Produto");

            entity.Property(e => e.DataCadastro).HasColumnType("datetime");
            entity.Property(e => e.Descricao).HasMaxLength(300);
            entity.Property(e => e.ImagemUrl).HasMaxLength(80);
            entity.Property(e => e.Nome).HasMaxLength(80);
            entity.Property(e => e.Preco).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Produto_Categoria");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
