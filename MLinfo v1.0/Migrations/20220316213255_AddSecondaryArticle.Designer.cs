﻿// <auto-generated />
using System;
using MLinfo_v1._0.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MLinfo_v1._0.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20220316213255_AddSecondaryArticle")]
    partial class AddSecondaryArticle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArticleAuthor", b =>
                {
                    b.Property<int>("ArticlesID")
                        .HasColumnType("int");

                    b.Property<int>("AuthorsID")
                        .HasColumnType("int");

                    b.HasKey("ArticlesID", "AuthorsID");

                    b.HasIndex("AuthorsID");

                    b.ToTable("ArticleAuthor");
                });

            modelBuilder.Entity("ArticleKeyword", b =>
                {
                    b.Property<int>("ArticlesID")
                        .HasColumnType("int");

                    b.Property<int>("KeywordsID")
                        .HasColumnType("int");

                    b.HasKey("ArticlesID", "KeywordsID");

                    b.HasIndex("KeywordsID");

                    b.ToTable("ArticleKeyword");
                });

            modelBuilder.Entity("ArticleMLMethod", b =>
                {
                    b.Property<int>("ArticlesID")
                        .HasColumnType("int");

                    b.Property<int>("MethodsID")
                        .HasColumnType("int");

                    b.HasKey("ArticlesID", "MethodsID");

                    b.HasIndex("MethodsID");

                    b.ToTable("ArticleMLMethod");
                });

            modelBuilder.Entity("AuthorOrganization", b =>
                {
                    b.Property<int>("AuthorsID")
                        .HasColumnType("int");

                    b.Property<int>("OrganizationsID")
                        .HasColumnType("int");

                    b.HasKey("AuthorsID", "OrganizationsID");

                    b.HasIndex("OrganizationsID");

                    b.ToTable("AuthorOrganization");
                });

            modelBuilder.Entity("MLinfo_v1._0.Models.Article", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DOI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Issue")
                        .HasColumnType("int");

                    b.Property<int>("LanguageID")
                        .HasColumnType("int");

                    b.Property<string>("PDFfile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SecondaryArticleID")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LanguageID");

                    b.HasIndex("SecondaryArticleID");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("MLinfo_v1._0.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NameE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("MLinfo_v1._0.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NameE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("MLinfo_v1._0.Models.Keyword", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("KeywordE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeywordR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("MLinfo_v1._0.Models.Language", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NameE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("MLinfo_v1._0.Models.MLMethod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NameE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MlMethods");
                });

            modelBuilder.Entity("MLinfo_v1._0.Models.Organization", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("NameE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("ArticleAuthor", b =>
                {
                    b.HasOne("MLinfo_v1._0.Models.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticlesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MLinfo_v1._0.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArticleKeyword", b =>
                {
                    b.HasOne("MLinfo_v1._0.Models.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticlesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MLinfo_v1._0.Models.Keyword", null)
                        .WithMany()
                        .HasForeignKey("KeywordsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArticleMLMethod", b =>
                {
                    b.HasOne("MLinfo_v1._0.Models.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticlesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MLinfo_v1._0.Models.MLMethod", null)
                        .WithMany()
                        .HasForeignKey("MethodsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuthorOrganization", b =>
                {
                    b.HasOne("MLinfo_v1._0.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MLinfo_v1._0.Models.Organization", null)
                        .WithMany()
                        .HasForeignKey("OrganizationsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MLinfo_v1._0.Models.Article", b =>
                {
                    b.HasOne("MLinfo_v1._0.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MLinfo_v1._0.Models.Article", "SecondaryArticle")
                        .WithMany()
                        .HasForeignKey("SecondaryArticleID");

                    b.Navigation("Language");

                    b.Navigation("SecondaryArticle");
                });

            modelBuilder.Entity("MLinfo_v1._0.Models.Organization", b =>
                {
                    b.HasOne("MLinfo_v1._0.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
