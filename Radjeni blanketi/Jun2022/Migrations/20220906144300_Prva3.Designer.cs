﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Template.Migrations
{
    [DbContext(typeof(IspitDbContext))]
    [Migration("20220906144300_Prva3")]
    partial class Prva3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Models.Automobil", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Boja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<string>("DatumPoslednjeProdaje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("Marka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProdavnicaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProdavnicaID");

                    b.ToTable("Automobili");
                });

            modelBuilder.Entity("Models.Prodavnica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Prodavnice");
                });

            modelBuilder.Entity("Models.Automobil", b =>
                {
                    b.HasOne("Models.Prodavnica", "Prodavnica")
                        .WithMany("Automobili")
                        .HasForeignKey("ProdavnicaID");

                    b.Navigation("Prodavnica");
                });

            modelBuilder.Entity("Models.Prodavnica", b =>
                {
                    b.Navigation("Automobili");
                });
#pragma warning restore 612, 618
        }
    }
}
