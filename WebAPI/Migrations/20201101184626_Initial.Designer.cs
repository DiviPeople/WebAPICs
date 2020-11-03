﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

namespace WebAPI.Migrations
{
    [DbContext(typeof(WebAPIContext))]
    [Migration("20201101184626_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.Agreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataClose")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataOpen")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Agreement");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataClose = new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataOpen = new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Number = 1,
                            PersonId = 2,
                            StatusId = 1,
                            TypeId = 2
                        },
                        new
                        {
                            Id = 2,
                            DataClose = new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataOpen = new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Number = 2,
                            PersonId = 1,
                            StatusId = 2,
                            TypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            DataClose = new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataOpen = new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Number = 3,
                            PersonId = 5,
                            StatusId = 1,
                            TypeId = 3
                        },
                        new
                        {
                            Id = 4,
                            DataClose = new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataOpen = new DateTime(2020, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Number = 4,
                            PersonId = 3,
                            StatusId = 1,
                            TypeId = 2
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<long>("Inn")
                        .HasColumnType("bigint");

                    b.Property<string>("Shifer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Type")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Data = new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Inn = 122365456212L,
                            Shifer = "sdada",
                            Type = false
                        },
                        new
                        {
                            Id = 2,
                            Data = new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Inn = 122515456212L,
                            Shifer = "shfgha",
                            Type = false
                        },
                        new
                        {
                            Id = 3,
                            Data = new DateTime(2020, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Inn = 1225154562L,
                            Shifer = "ssdfgha",
                            Type = true
                        },
                        new
                        {
                            Id = 4,
                            Data = new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Inn = 1227545621L,
                            Shifer = "sjhk",
                            Type = true
                        },
                        new
                        {
                            Id = 5,
                            Data = new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Inn = 122516556212L,
                            Shifer = "rtya",
                            Type = false
                        },
                        new
                        {
                            Id = 6,
                            Data = new DateTime(2020, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Inn = 1287545621L,
                            Shifer = "ssyio",
                            Type = true
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusAggrement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusAggrement = "действует"
                        },
                        new
                        {
                            Id = 2,
                            StatusAggrement = "блокирован"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeAggrement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Type");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeAggrement = "дилерский"
                        },
                        new
                        {
                            Id = 2,
                            TypeAggrement = "брокерский"
                        },
                        new
                        {
                            Id = 3,
                            TypeAggrement = "управления"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}