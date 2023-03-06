﻿// <auto-generated />
using System;
using DrWizardry.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrWizardry.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230305154047_addingSeperateClassForMtoM")]
    partial class addingSeperateClassForMtoM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

            modelBuilder.Entity("DrWizardry.Models.UserVocab", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VocabId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "VocabId");

                    b.HasIndex("VocabId");

                    b.ToTable("UserVocab");
                });

            modelBuilder.Entity("DrWizardry.Models.Vocab", b =>
                {
                    b.Property<int>("VocabId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VocabId"), 1L, 1);

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

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VocabId");

                    b.ToTable("Vocabs");
                });

            modelBuilder.Entity("DrWizardry.Models.UserVocab", b =>
                {
                    b.HasOne("DrWizardry.Models.User", "User")
                        .WithMany("UserVocabs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrWizardry.Models.Vocab", "Vocab")
                        .WithMany("UserVocabs")
                        .HasForeignKey("VocabId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Vocab");
                });

            modelBuilder.Entity("DrWizardry.Models.User", b =>
                {
                    b.Navigation("UserVocabs");
                });

            modelBuilder.Entity("DrWizardry.Models.Vocab", b =>
                {
                    b.Navigation("UserVocabs");
                });
#pragma warning restore 612, 618
        }
    }
}
