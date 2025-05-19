using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities;

public partial class SqliteContext : DbContext
{
    public SqliteContext()
    {
    }

    public SqliteContext(DbContextOptions<SqliteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Evenement> Evenements { get; set; }

    public virtual DbSet<Facture> Factures { get; set; }

    public virtual DbSet<FactureArticle> FactureArticles { get; set; }

    public virtual DbSet<Vendeur> Vendeurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\yvesc\\Documents\\GitHub\\Factures2025\\BaseDeDonnees\\facture2025.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.NumArticle);

            entity.ToTable("Article");

            entity.HasIndex(e => e.NumArticle, "IX_Article_NumArticle").IsUnique();

            entity.Property(e => e.CategorieId).HasDefaultValue(1);
            entity.Property(e => e.EstActif).HasColumnType("BOOLEAN");
            entity.Property(e => e.Prix).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Categorie).WithMany(p => p.Articles)
                .HasForeignKey(d => d.CategorieId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.ToTable("Categorie");

            entity.Property(e => e.Nom).HasDefaultValue("-");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.NumClient);

            entity.ToTable("Client");

            entity.HasIndex(e => e.NumClient, "IX_Client_NumClient").IsUnique();

            entity.Property(e => e.CodePostal).HasColumnType("varchar(10)");
            entity.Property(e => e.DateDeNaissance).HasColumnType("datetime");
        });

        modelBuilder.Entity<Evenement>(entity =>
        {
            entity.HasKey(e => e.NumEvenement);

            entity.ToTable("Evenement");

            entity.HasIndex(e => e.NumEvenement, "IX_Evenement_NumEvenement").IsUnique();

            entity.Property(e => e.DateEvenement).HasColumnType("datetime");

            entity.HasOne(d => d.NumVendeurNavigation).WithMany(p => p.Evenements)
                .HasForeignKey(d => d.NumVendeur)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Facture>(entity =>
        {
            entity.HasKey(e => e.NumFacture);

            entity.ToTable("Facture");

            entity.HasIndex(e => e.NumFacture, "IX_Facture_NumFacture").IsUnique();

            entity.Property(e => e.DateFacture).HasColumnType("datetime");

            entity.HasOne(d => d.NumClientNavigation).WithMany(p => p.Factures)
                .HasForeignKey(d => d.NumClient)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.NumVendeurNavigation).WithMany(p => p.Factures)
                .HasForeignKey(d => d.NumVendeur)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<FactureArticle>(entity =>
        {
            entity.HasKey(e => e.NumFactureArticle);

            entity.ToTable("FactureArticle");

            entity.HasIndex(e => e.NumFactureArticle, "IX_FactureArticle_NumFactureArticle").IsUnique();

            entity.HasOne(d => d.NumArticleNavigation).WithMany(p => p.FactureArticles)
                .HasForeignKey(d => d.NumArticle)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.NumFactureNavigation).WithMany(p => p.FactureArticles)
                .HasForeignKey(d => d.NumFacture)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Vendeur>(entity =>
        {
            entity.HasKey(e => e.NumVendeur);

            entity.ToTable("Vendeur");

            entity.HasIndex(e => e.NumVendeur, "IX_Vendeur_NumVendeur").IsUnique();

            entity.Property(e => e.Role).HasDefaultValue("user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
