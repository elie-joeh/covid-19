﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using covid19.Data;

namespace covid19.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200705162411_Add Debt")]
    partial class AddDebt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("covid19.Data.CPI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Coordinate")
                        .HasColumnType("decimal(7,4)");

                    b.Property<string>("DGUID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeographyName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Ppdg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Reference_date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(7,4)");

                    b.Property<string>("Vector_Id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeographyName");

                    b.ToTable("CPI");
                });

            modelBuilder.Entity("covid19.Data.Debt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Central_gov_debt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DGUID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Geography_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Reference_date")
                        .HasColumnType("datetime2");

                    b.Property<long>("Value")
                        .HasColumnType("bigint");

                    b.Property<string>("Vector_id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Debt");
                });

            modelBuilder.Entity("covid19.Data.Employment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgeGroup")
                        .HasColumnType("int");

                    b.Property<string>("GeoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lfc")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReferenceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ScalarFactor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("UOM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("VectorId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employment");
                });

            modelBuilder.Entity("covid19.Data.Geography", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Dead")
                        .HasColumnType("int");

                    b.Property<int>("Infected")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Geography");
                });

            modelBuilder.Entity("covid19.Data.CPI", b =>
                {
                    b.HasOne("covid19.Data.Geography", "Geography")
                        .WithMany("CPIs")
                        .HasForeignKey("GeographyName");
                });
#pragma warning restore 612, 618
        }
    }
}
