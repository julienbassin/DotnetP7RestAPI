using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoseidonRestAPI.Migrations
{
    public partial class AdditionnalRowInserted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BidList",
                columns: new[] { "Account", "Ask", "AskQuantity", "BenchMark", "Bid", "BidListDate", "BidQuantity", "Book", "Commentary", "CreationDate", "CreationName", "DealName", "RevisionName", "Security", "Side", "SourceListId", "Status", "Trader", "Type" },
                values: new object[] {  "Julien", 0.0, 0.0, null, 0.0, new DateTime(2021, 1, 30, 15, 59, 5, 781, DateTimeKind.Local).AddTicks(2750), 10.0, null, null, new DateTime(2021, 1, 30, 15, 59, 5, 784, DateTimeKind.Local).AddTicks(5081), null, null, null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                table: "BidList",
                columns: new[] {  "Account", "Ask", "AskQuantity", "BenchMark", "Bid", "BidListDate", "BidQuantity", "Book", "Commentary", "CreationDate", "CreationName", "DealName", "RevisionName", "Security", "Side", "SourceListId", "Status", "Trader", "Type" },
                values: new object[] { "test", 0.0, 0.0, null, 0.0, new DateTime(2021, 1, 30, 15, 59, 5, 784, DateTimeKind.Local).AddTicks(7582), 20.0, null, null, new DateTime(2021, 1, 30, 15, 59, 5, 784, DateTimeKind.Local).AddTicks(7604), null, null, null, null, null, null, null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
