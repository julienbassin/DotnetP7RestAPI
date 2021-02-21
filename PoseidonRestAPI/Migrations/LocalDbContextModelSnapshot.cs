﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoseidonRestAPI.Data;

namespace PoseidonRestAPI.Migrations
{
    [DbContext(typeof(LocalDbContext))]
    partial class LocalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PoseidonRestAPI.Configuration.JwtAccessToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("JWTToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AccessTokens");
                });

            modelBuilder.Entity("PoseidonRestAPI.Domain.BidList", b =>
                {
                    b.Property<int>("BidListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Ask")
                        .HasColumnType("float");

                    b.Property<double>("AskQuantity")
                        .HasColumnType("float");

                    b.Property<string>("BenchMark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Bid")
                        .HasColumnType("float");

                    b.Property<DateTime?>("BidListDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("BidQuantity")
                        .HasColumnType("float");

                    b.Property<string>("Book")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Commentary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DealName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RevisionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevisionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Security")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Side")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceListId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BidListId");

                    b.ToTable("BidList");
                });

            modelBuilder.Entity("PoseidonRestAPI.Domain.CurvePoint", b =>
                {
                    b.Property<int>("CurveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AsOfDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<double>("Term")
                        .HasColumnType("float");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("CurveId");

                    b.ToTable("CurvePoints");
                });

            modelBuilder.Entity("PoseidonRestAPI.Domain.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FitchRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoodysRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<string>("SandPRating")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("PoseidonRestAPI.Domain.Rule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Json")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SqlPart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SqlStr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Template")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("PoseidonRestAPI.Domain.Trade", b =>
                {
                    b.Property<int>("TradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Benchmark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Book")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("BuyPrice")
                        .HasColumnType("float");

                    b.Property<double>("BuyQuantity")
                        .HasColumnType("float");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DealName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DealType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RevisionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RevisionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Security")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SellPrice")
                        .HasColumnType("float");

                    b.Property<double>("SellQuantity")
                        .HasColumnType("float");

                    b.Property<string>("Side")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceListId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TradeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Trader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TradeId");

                    b.ToTable("Trades");
                });

            modelBuilder.Entity("PoseidonRestAPI.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
