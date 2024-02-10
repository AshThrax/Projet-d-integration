﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data.infrastructure.Persistence;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240208104711_DemoTicketsMigration")]
    partial class DemoTicketsMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("data.Models.Command", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AddedTime")
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

            modelBuilder.Entity("data.Models.Complexe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AddedTime")
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

            modelBuilder.Entity("data.Models.Entity.Tickets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CommandId")
                        .HasColumnType("int");

                    b.Property<string>("Piecetitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Representation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommandId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("data.Models.Piece", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AddedTime")
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

            modelBuilder.Entity("data.Models.Representation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPiece")
                        .HasColumnType("int");

                    b.Property<int>("IdSalledeTheatre")
                        .HasColumnType("int");

                    b.Property<int>("PlaceMaximum")
                        .HasColumnType("int");

                    b.Property<int>("Prix")
                        .HasColumnType("int");

                    b.Property<DateTime>("Seance")
                        .HasColumnType("datetime2");

                    b.Property<int>("placeCurrent")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPiece");

                    b.HasIndex("IdSalledeTheatre");

                    b.ToTable("Representations");
                });

            modelBuilder.Entity("data.Models.SalleDeTheatre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaceMax")
                        .HasColumnType("int");

                    b.Property<int>("complexeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("complexeId");

                    b.ToTable("SalleDeTheatres");
                });

            modelBuilder.Entity("data.Models.Command", b =>
                {
                    b.HasOne("data.Models.Representation", "Representation")
                        .WithMany("Commands")
                        .HasForeignKey("IdRepresentation")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Representation");
                });

            modelBuilder.Entity("data.Models.Entity.Tickets", b =>
                {
                    b.HasOne("data.Models.Command", "Command")
                        .WithMany("Tickets")
                        .HasForeignKey("CommandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Command");
                });

            modelBuilder.Entity("data.Models.Piece", b =>
                {
                    b.HasOne("data.Models.SalleDeTheatre", "SalleDeTheatre")
                        .WithMany("Pieces")
                        .HasForeignKey("IdSalle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SalleDeTheatre");
                });

            modelBuilder.Entity("data.Models.Representation", b =>
                {
                    b.HasOne("data.Models.Piece", "Piece")
                        .WithMany("Representations")
                        .HasForeignKey("IdPiece")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("data.Models.SalleDeTheatre", "SalleDeTheatre")
                        .WithMany("Representations")
                        .HasForeignKey("IdSalledeTheatre")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Piece");

                    b.Navigation("SalleDeTheatre");
                });

            modelBuilder.Entity("data.Models.SalleDeTheatre", b =>
                {
                    b.HasOne("data.Models.Complexe", "Complexe")
                        .WithMany("SalleDeTheatres")
                        .HasForeignKey("complexeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Complexe");
                });

            modelBuilder.Entity("data.Models.Command", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("data.Models.Complexe", b =>
                {
                    b.Navigation("SalleDeTheatres");
                });

            modelBuilder.Entity("data.Models.Piece", b =>
                {
                    b.Navigation("Representations");
                });

            modelBuilder.Entity("data.Models.Representation", b =>
                {
                    b.Navigation("Commands");
                });

            modelBuilder.Entity("data.Models.SalleDeTheatre", b =>
                {
                    b.Navigation("Pieces");

                    b.Navigation("Representations");
                });
#pragma warning restore 612, 618
        }
    }
}
