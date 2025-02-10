﻿// <auto-generated />
using System;
using Amem.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Amem.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250210233229_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Amem.Domain.Entities.LiturgiaDiaria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<string>("Evangelho")
                        .HasColumnType("text");

                    b.Property<string>("PrimeiraLeitura")
                        .HasColumnType("text");

                    b.Property<string>("SalmoResponsorial")
                        .HasColumnType("text");

                    b.Property<string>("SegundaLeitura")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LiturgiasDiarias");
                });
#pragma warning restore 612, 618
        }
    }
}
