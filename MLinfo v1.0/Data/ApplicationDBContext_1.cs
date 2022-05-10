using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MLinfo_v1._0.Models.DatabasedModels;

namespace MLinfo_v1._0.Data
{
    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> AuthorsInfos { get; set; } = null!;
        public virtual DbSet<Country> CountriesInfos { get; set; } = null!;
        public virtual DbSet<Keyword> KeywordsInfos { get; set; } = null!;
        public virtual DbSet<MLMethod> MethodMlinfos { get; set; } = null!;
        public virtual DbSet<Organization> OrganizationsInfos { get; set; } = null!;
        public virtual DbSet<Article> ReferencesInfos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.ToTable("AuthorsInfo");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasColumnName("AuthorID");

                entity.Property(e => e.NameE)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.NameR)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasMany(d => d.Organizations)
                    .WithMany(p => p.Authors)
                    .UsingEntity<Dictionary<string, object>>(
                        "AuthorsOrganization",
                        l => l.HasOne<Organization>().WithMany().HasForeignKey("OrganizationId").OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Authors_Organizations_OrganizationsInfo"),
                        r => r.HasOne<Author>().WithMany().HasForeignKey("AuthorId").OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Authors_Organizations_AuthorsInfo"),
                        j =>
                        {
                            j.HasKey("AuthorId", "OrganizationId");

                            j.ToTable("Authors_Organizations");

                            j.IndexerProperty<int>("AuthorId").HasColumnName("AuthorID");

                            j.IndexerProperty<int>("OrganizationId").HasColumnName("OrganizationID");
                        });
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.ToTable("CountriesInfo");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasColumnName("CountryID");

                entity.Property(e => e.NameE)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NameR)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.ToTable("KeywordsInfo");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasColumnName("KeywordID");

                entity.Property(e => e.KeywordE)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.KeywordR)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MLMethod>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.ToTable("MethodMLInfo");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasColumnName("MethodID");

                entity.Property(e => e.NameE)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NameR)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.ToTable("OrganizationsInfo");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasColumnName("OrganizationID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.NameE)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.NameR)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_OrganizationsInfo_CountriesInfo");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.ToTable("ReferencesInfo");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasColumnName("ReferenceID");

                entity.Property(e => e.TitleE)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.TitleR)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorsE)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorsR)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CommentE)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.CommentR)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.Doie)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DOIE");

                entity.Property(e => e.Doir)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DOIR");

                entity.Property(e => e.Issue)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PagesE)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PagesR)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PdfFile)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("PDF_File");

                entity.Property(e => e.SourceE)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.SourceR)
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.VolumeE)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.VolumeR)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasMany(d => d.Authors)
                    .WithMany(p => p.Articles)
                    .UsingEntity<Dictionary<string, object>>(
                        "ReferencesAuthor",
                        l => l.HasOne<Author>().WithMany().HasForeignKey("AuthorId").OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_References_Authors_AuthorsInfo"),
                        r => r.HasOne<Article>().WithMany().HasForeignKey("ReferenceId").OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_References_Authors_ReferencesInfo"),
                        j =>
                        {
                            j.HasKey("ReferenceId", "AuthorId");

                            j.ToTable("References_Authors");

                            j.IndexerProperty<int>("ReferenceId").HasColumnName("ReferenceID");

                            j.IndexerProperty<int>("AuthorId").HasColumnName("AuthorID");
                        });

                entity.HasMany(d => d.Keywords)
                    .WithMany(p => p.Articles)
                    .UsingEntity<Dictionary<string, object>>(
                        "ReferencesKeyword",
                        l => l.HasOne<Keyword>().WithMany().HasForeignKey("KeywordId").OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_References_Keywords_KeywordsInfo"),
                        r => r.HasOne<Article>().WithMany().HasForeignKey("ReferenceId").OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_References_Keywords_ReferencesInfo"),
                        j =>
                        {
                            j.HasKey("ReferenceId", "KeywordId").HasName("PK_References_Keywords_1");

                            j.ToTable("References_Keywords");

                            j.IndexerProperty<int>("ReferenceId").HasColumnName("ReferenceID");

                            j.IndexerProperty<int>("KeywordId").HasColumnName("KeywordID");
                        });

                entity.HasMany(d => d.Methods)
                    .WithMany(p => p.Articles)
                    .UsingEntity<Dictionary<string, object>>(
                        "ReferencesMethod",
                        l => l.HasOne<MLMethod>().WithMany().HasForeignKey("MethodId").OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_References_Method_MethodMLInfo"),
                        r => r.HasOne<Article>().WithMany().HasForeignKey("ReferenceId").OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_References_Method_ReferencesInfo"),
                        j =>
                        {
                            j.HasKey("ReferenceId", "MethodId");

                            j.ToTable("References_Method");

                            j.IndexerProperty<int>("ReferenceId").HasColumnName("ReferenceID");

                            j.IndexerProperty<int>("MethodId").HasColumnName("MethodID");
                        });
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
