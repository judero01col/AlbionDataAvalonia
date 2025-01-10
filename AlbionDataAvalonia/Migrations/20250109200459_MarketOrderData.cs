using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbionDataAvalonia.Migrations
{
    /// <inheritdoc />
    public partial class MarketOrderData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlbionServerId",
                table: "MarketOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "MarketOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlbionServerId",
                table: "MarketOrders");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "MarketOrders");
        }
    }
}
