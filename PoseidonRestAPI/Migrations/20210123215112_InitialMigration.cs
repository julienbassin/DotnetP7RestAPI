using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoseidonRestAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BidList",
                columns: table => new
                {
                    BidListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    BidQuantity = table.Column<double>(nullable: false),
                    AskQuantity = table.Column<double>(nullable: false),
                    Bid = table.Column<double>(nullable: false),
                    Ask = table.Column<double>(nullable: false),
                    BenchMark = table.Column<string>(nullable: true),
                    BidListDate = table.Column<DateTime>(nullable: true),
                    Commentary = table.Column<string>(nullable: true),
                    Security = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Trader = table.Column<string>(nullable: true),
                    Book = table.Column<string>(nullable: true),
                    CreationName = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    RevisionName = table.Column<string>(nullable: true),
                    RevisionDate = table.Column<DateTime>(nullable: true),
                    DealName = table.Column<string>(nullable: true),
                    SourceListId = table.Column<string>(nullable: true),
                    Side = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidList", x => x.BidListId);
                });

            migrationBuilder.CreateTable(
                name: "CurvePoints",
                columns: table => new
                {
                    CurveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    AsOfDate = table.Column<DateTime>(nullable: true),
                    Term = table.Column<double>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurvePoints", x => x.CurveId);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoodysRating = table.Column<string>(nullable: true),
                    SandPRating = table.Column<string>(nullable: true),
                    FitchRating = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Json = table.Column<string>(nullable: true),
                    Template = table.Column<string>(nullable: true),
                    SqlStr = table.Column<string>(nullable: true),
                    SqlPart = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    TradeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    BuyQuantity = table.Column<double>(nullable: false),
                    SellQuantity = table.Column<double>(nullable: false),
                    BuyPrice = table.Column<double>(nullable: false),
                    SellPrice = table.Column<double>(nullable: false),
                    Benchmark = table.Column<string>(nullable: true),
                    TradeDate = table.Column<DateTime>(nullable: true),
                    Security = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Trader = table.Column<string>(nullable: true),
                    Book = table.Column<string>(nullable: true),
                    CreationName = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    RevisionName = table.Column<string>(nullable: true),
                    RevisionDate = table.Column<DateTime>(nullable: true),
                    DealName = table.Column<string>(nullable: true),
                    DealType = table.Column<string>(nullable: true),
                    SourceListId = table.Column<string>(nullable: true),
                    Side = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.TradeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidList");

            migrationBuilder.DropTable(
                name: "CurvePoints");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
