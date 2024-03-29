﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Template.Migrations
{
    [DbContext(typeof(IspitDbContext))]
    partial class IspitDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Models.Merac", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Boja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrojMerenja")
                        .HasColumnType("int");

                    b.Property<int>("GranicaDo")
                        .HasColumnType("int");

                    b.Property<int>("GranicaOd")
                        .HasColumnType("int");

                    b.Property<int>("MaxVrednost")
                        .HasColumnType("int");

                    b.Property<int>("MinVrednost")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Podeok")
                        .HasColumnType("int");

                    b.Property<int>("TrenutnaVrednost")
                        .HasColumnType("int");

                    b.Property<int>("ZbirIzmerenih")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Meraci");
                });
#pragma warning restore 612, 618
        }
    }
}
