﻿// <auto-generated />
using System;
using DrWizardry.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrWizardry.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DrWizardry.Models.Synonym", b =>
                {
                    b.Property<int>("SynonymId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SynonymId"), 1L, 1);

                    b.Property<int?>("VocabId")
                        .HasColumnType("int");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SynonymId");

                    b.HasIndex("VocabId");

                    b.ToTable("Synonym");
                });

            modelBuilder.Entity("DrWizardry.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DrWizardry.Models.Vocab", b =>
                {
                    b.Property<int>("VocabId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VocabId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Difficulty_lvl")
                        .HasColumnType("int");

                    b.Property<string>("Example")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VocabId");

                    b.HasIndex("UserID");

                    b.ToTable("Vocabs");
                });

            modelBuilder.Entity("DrWizardry.Models.Synonym", b =>
                {
                    b.HasOne("DrWizardry.Models.Vocab", null)
                        .WithMany("Synonyms")
                        .HasForeignKey("VocabId");
                });

            modelBuilder.Entity("DrWizardry.Models.Vocab", b =>
                {
                    b.HasOne("DrWizardry.Models.User", "User")
                        .WithMany("Vocabs")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DrWizardry.Models.User", b =>
                {
                    b.Navigation("Vocabs");
                });

            modelBuilder.Entity("DrWizardry.Models.Vocab", b =>
                {
                    b.Navigation("Synonyms");
                });
#pragma warning restore 612, 618
        }
    }
}