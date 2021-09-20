﻿// <auto-generated />
using System;
using BlazorServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorServer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210918235421_createmigration")]
    partial class createmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlazorServer.Data.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeCargo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("BlazorServer.Data.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CargoId")
                        .HasColumnType("int");

                    b.Property<int>("CodPonto")
                        .HasColumnType("int");

                    b.Property<DateTime>("Contratacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Demissao")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("HoraAula")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.ToTable("Colaboradors");
                });

            modelBuilder.Entity("BlazorServer.Data.RegistroPonto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("AM_ENT")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("AM_SAI")
                        .HasColumnType("time");

                    b.Property<int?>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiaSemana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("NOI_ENT")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("NOI_SAI")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("PM_ENT")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("PM_SAI")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TOTALHORAS")
                        .HasColumnType("time");

                    b.Property<decimal>("VALORHORA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VALORTOTAL")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("RegistroPontos");
                });

            modelBuilder.Entity("BlazorServer.Data.Colaborador", b =>
                {
                    b.HasOne("BlazorServer.Data.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId");

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("BlazorServer.Data.RegistroPonto", b =>
                {
                    b.HasOne("BlazorServer.Data.Colaborador", "Colaborador")
                        .WithMany()
                        .HasForeignKey("ColaboradorId");

                    b.Navigation("Colaborador");
                });
#pragma warning restore 612, 618
        }
    }
}
