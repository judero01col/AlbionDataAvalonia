using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbionDataAvalonia.Migrations
{
    /// <inheritdoc />
    public partial class MarketOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "UnitSilver",
                table: "Trades",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<double>(
                name: "UnitSilver",
                table: "AlbionMails",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "MarketOrders",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemTypeId = table.Column<string>(type: "TEXT", nullable: false),
                    ItemGroupTypeId = table.Column<string>(type: "TEXT", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    QualityLevel = table.Column<byte>(type: "INTEGER", nullable: false),
                    EnchantmentLevel = table.Column<byte>(type: "INTEGER", nullable: false),
                    UnitPriceSilver = table.Column<ulong>(type: "INTEGER", nullable: false),
                    Amount = table.Column<uint>(type: "INTEGER", nullable: false),
                    AuctionType = table.Column<int>(type: "INTEGER", nullable: false),
                    Expires = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketOrders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketOrders");

            migrationBuilder.AlterColumn<ulong>(
                name: "UnitSilver",
                table: "Trades",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<long>(
                name: "UnitSilver",
                table: "AlbionMails",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
