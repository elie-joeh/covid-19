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
    [Migration("20201001020439_updating new Debt column names")]
    partial class updatingnewDebtcolumnnames
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

            modelBuilder.Entity("covid19.Data.DebtNew", b =>
                {
                    b.Property<long>("Vector_id")
                        .HasColumnName("Vector_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Reference_date")
                        .HasColumnName("Reference_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Decimals")
                        .HasColumnType("int");

                    b.Property<string>("ReleaseTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScalarFactorCode")
                        .HasColumnType("int");

                    b.Property<decimal?>("Value")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Vector_id", "Reference_date");

                    b.ToTable("Canada_Debt");
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

            modelBuilder.Entity("covid19.Data.GDP", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("geography_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("industry_classification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prices")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("reference_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("seasonal_adj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("value")
                        .HasColumnType("bigint");

                    b.Property<string>("vector_id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("GDP");
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

            modelBuilder.Entity("covid19.Data.Manufacturing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Geography_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry_classification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Principal_statistics")
                        .HasColumnType("int");

                    b.Property<DateTime>("Reference_date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Vector_id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturing");
                });

            modelBuilder.Entity("covid19.Data.Retail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("adjustments")
                        .HasColumnType("int");

                    b.Property<string>("geography_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("industry_class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("reference_date")
                        .HasColumnType("datetime2");

                    b.Property<long>("value")
                        .HasColumnType("bigint");

                    b.Property<string>("vector_id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Retail");
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
