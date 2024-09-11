﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

#nullable disable

namespace WebTemplate.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AktivnostPutovanje", b =>
                {
                    b.Property<int>("AktivnostiId")
                        .HasColumnType("int");

                    b.Property<int>("PutovanjeId")
                        .HasColumnType("int");

                    b.HasKey("AktivnostiId", "PutovanjeId");

                    b.HasIndex("PutovanjeId");

                    b.ToTable("AktivnostPutovanje");
                });

            modelBuilder.Entity("Models.Agencija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Agencije");
                });

            modelBuilder.Entity("Models.Aktivnost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aktivnosti");
                });

            modelBuilder.Entity("Models.Putovanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgencijaId")
                        .HasColumnType("int");

                    b.Property<int>("BrojNocenja")
                        .HasColumnType("int");

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<string>("Mesto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prevoz")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgencijaId");

                    b.ToTable("Putovanja");
                });

            modelBuilder.Entity("Models.Recenzija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Komentar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Korisnik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocena")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Recenzije");
                });

            modelBuilder.Entity("Models.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrojOsoba")
                        .HasColumnType("int");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Grad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PutovanjeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PutovanjeId");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("PutovanjeRecenzija", b =>
                {
                    b.Property<int>("PutovanjeId")
                        .HasColumnType("int");

                    b.Property<int>("RecenzijeId")
                        .HasColumnType("int");

                    b.HasKey("PutovanjeId", "RecenzijeId");

                    b.HasIndex("RecenzijeId");

                    b.ToTable("PutovanjeRecenzija");
                });

            modelBuilder.Entity("AktivnostPutovanje", b =>
                {
                    b.HasOne("Models.Aktivnost", null)
                        .WithMany()
                        .HasForeignKey("AktivnostiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Putovanje", null)
                        .WithMany()
                        .HasForeignKey("PutovanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Putovanje", b =>
                {
                    b.HasOne("Models.Agencija", "Agencija")
                        .WithMany("Putovanje")
                        .HasForeignKey("AgencijaId");

                    b.Navigation("Agencija");
                });

            modelBuilder.Entity("Models.Rezervacija", b =>
                {
                    b.HasOne("Models.Putovanje", "Putovanje")
                        .WithMany("Rezervacije")
                        .HasForeignKey("PutovanjeId");

                    b.Navigation("Putovanje");
                });

            modelBuilder.Entity("PutovanjeRecenzija", b =>
                {
                    b.HasOne("Models.Putovanje", null)
                        .WithMany()
                        .HasForeignKey("PutovanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Recenzija", null)
                        .WithMany()
                        .HasForeignKey("RecenzijeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Agencija", b =>
                {
                    b.Navigation("Putovanje");
                });

            modelBuilder.Entity("Models.Putovanje", b =>
                {
                    b.Navigation("Rezervacije");
                });
#pragma warning restore 612, 618
        }
    }
}
