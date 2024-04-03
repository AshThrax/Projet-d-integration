﻿// <auto-generated />
using dataInfraTheather.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjecIntegration.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240131233357_pieceUpdate")]
    partial class pieceUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjecIntegration.Api.Models.Entity.Piece", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duree")
                        .HasColumnType("int");

                    b.Property<int>("IdSalle")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdSalle");

                    b.ToTable("Pieces");
                });

            modelBuilder.Entity("ProjecIntegration.Command", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AuthId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdRepresentation")
                        .HasColumnType("int");

                    b.Property<int>("NombreDePlace")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdRepresentation");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("ProjecIntegration.Complexe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Complexe");
                });

            modelBuilder.Entity("ProjecIntegration.Representation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPiece")
                        .HasColumnType("int");

                    b.Property<int>("IdSalledeTheatre")
                        .HasColumnType("int");

                    b.Property<int>("Prix")
                        .HasColumnType("int");

                    b.Property<DateTime>("Seance")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdPiece");

                    b.HasIndex("IdSalledeTheatre");

                    b.ToTable("Representations");
                });

            modelBuilder.Entity("ProjecIntegration.SalleDeTheatre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaceCurrent")
                        .HasColumnType("int");

                    b.Property<int>("PlaceMax")
                        .HasColumnType("int");

                    b.Property<int>("complexeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("complexeId");

                    b.ToTable("SalleDeTheatres");
                });

            modelBuilder.Entity("ProjecIntegration.Api.Models.Entity.Piece", b =>
                {
                    b.HasOne("ProjecIntegration.SalleDeTheatre", "SalleDeTheatre")
                        .WithMany("Pieces")
                        .HasForeignKey("IdSalle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SalleDeTheatre");
                });

            modelBuilder.Entity("ProjecIntegration.Command", b =>
                {
                    b.HasOne("ProjecIntegration.Representation", "Representation")
                        .WithMany("Commands")
                        .HasForeignKey("IdRepresentation")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Representation");
                });

            modelBuilder.Entity("ProjecIntegration.Representation", b =>
                {
                    b.HasOne("ProjecIntegration.Api.Models.Entity.Piece", "Piece")
                        .WithMany("Representations")
                        .HasForeignKey("IdPiece")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjecIntegration.SalleDeTheatre", "SalleDeTheatre")
                        .WithMany("Representations")
                        .HasForeignKey("IdSalledeTheatre")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Piece");

                    b.Navigation("SalleDeTheatre");
                });

            modelBuilder.Entity("ProjecIntegration.SalleDeTheatre", b =>
                {
                    b.HasOne("ProjecIntegration.Complexe", "Complexe")
                        .WithMany("SalleDeTheatres")
                        .HasForeignKey("complexeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Complexe");
                });

            modelBuilder.Entity("ProjecIntegration.Api.Models.Entity.Piece", b =>
                {
                    b.Navigation("Representations");
                });

            modelBuilder.Entity("ProjecIntegration.Complexe", b =>
                {
                    b.Navigation("SalleDeTheatres");
                });

            modelBuilder.Entity("ProjecIntegration.Representation", b =>
                {
                    b.Navigation("Commands");
                });

            modelBuilder.Entity("ProjecIntegration.SalleDeTheatre", b =>
                {
                    b.Navigation("Pieces");

                    b.Navigation("Representations");
                });
#pragma warning restore 612, 618
        }
    }
}
