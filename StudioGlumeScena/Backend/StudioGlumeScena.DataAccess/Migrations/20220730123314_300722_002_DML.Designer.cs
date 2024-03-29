﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudioGlumeScena.DataAccess.Models;

#nullable disable

namespace StudioGlumeScena.DataAccess.Migrations
{
    [DbContext(typeof(StudioGlumeScenaContext))]
    [Migration("20220730123314_300722_002_DML")]
    partial class _300722_002_DML
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.Administrator", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("KorisnikId")
                        .HasColumnType("bigint");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.Grupa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("AktivanZadatak")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DanOdrzavanjaCasa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("LokacijaId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProfesorId")
                        .HasColumnType("bigint");

                    b.Property<string>("VremeOdrzavanjaCasa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LokacijaId");

                    b.HasIndex("ProfesorId");

                    b.ToTable("Grupa");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.KorisnickaUloga", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Sifra")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("KorisnickaUloga");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.Korisnik", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("KorisnickaUlogaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickaUlogaId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.Lokacija", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KontaktTelefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lokacija");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.PrijavaZaUpis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GodinaRodjenja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PrijavaZaUpis");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.Profesor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("KorisnikId")
                        .HasColumnType("bigint");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.Ucenik", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GodinaRodjenja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("GrupaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("KorisnikId")
                        .HasColumnType("bigint");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GrupaId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Ucenik");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.Administrator", b =>
                {
                    b.HasOne("StudioGlumeScena.DataAccess.Models.Korisnik", "Korisnik")
                        .WithMany("Administrator")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.Grupa", b =>
                {
                    b.HasOne("StudioGlumeScena.DataAccess.Models.Lokacija", "Lokacija")
                        .WithMany()
                        .HasForeignKey("LokacijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudioGlumeScena.DataAccess.Models.Profesor", "Profesor")
                        .WithMany("Grupa")
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lokacija");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.Korisnik", b =>
                {
                    b.HasOne("StudioGlumeScena.DataAccess.Models.KorisnickaUloga", "KorisnickaUloga")
                        .WithMany("Korisnik")
                        .HasForeignKey("KorisnickaUlogaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KorisnickaUloga");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.Profesor", b =>
                {
                    b.HasOne("StudioGlumeScena.DataAccess.Models.Korisnik", "Korisnik")
                        .WithMany("Profesor")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.Ucenik", b =>
                {
                    b.HasOne("StudioGlumeScena.DataAccess.Models.Grupa", "Grupa")
                        .WithMany("Ucenik")
                        .HasForeignKey("GrupaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudioGlumeScena.DataAccess.Models.Korisnik", "Korisnik")
                        .WithMany("Ucenik")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupa");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.Grupa", b =>
                {
                    b.Navigation("Ucenik");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.KorisnickaUloga", b =>
                {
                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.Korisnik", b =>
                {
                    b.Navigation("Administrator");

                    b.Navigation("Profesor");

                    b.Navigation("Ucenik");
                });

            modelBuilder.Entity("StudioGlumeScena.DataAccess.Models.Profesor", b =>
                {
                    b.Navigation("Grupa");
                });
#pragma warning restore 612, 618
        }
    }
}
