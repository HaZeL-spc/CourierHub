using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierAPI.Migrations
{
    /// <inheritdoc />
    public partial class changeStartEndCourier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Couriers_Locations_EndId",
                table: "Couriers");

            migrationBuilder.DropForeignKey(
                name: "FK_Couriers_Locations_StartId",
                table: "Couriers");

            migrationBuilder.DropIndex(
                name: "IX_Couriers_EndId",
                table: "Couriers");

            migrationBuilder.DropIndex(
                name: "IX_Couriers_StartId",
                table: "Couriers");

            migrationBuilder.DropColumn(
                name: "EndId",
                table: "Couriers");

            migrationBuilder.DropColumn(
                name: "StartId",
                table: "Couriers");

            migrationBuilder.AddColumn<string>(
                name: "End",
                table: "Couriers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Start",
                table: "Couriers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "Couriers");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Couriers");

            migrationBuilder.AddColumn<int>(
                name: "EndId",
                table: "Couriers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartId",
                table: "Couriers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_EndId",
                table: "Couriers",
                column: "EndId");

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_StartId",
                table: "Couriers",
                column: "StartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Couriers_Locations_EndId",
                table: "Couriers",
                column: "EndId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Couriers_Locations_StartId",
                table: "Couriers",
                column: "StartId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
