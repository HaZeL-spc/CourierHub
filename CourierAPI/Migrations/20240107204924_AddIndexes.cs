using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Locations_Id",
                table: "Locations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_Id",
                table: "Inquiries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_Id",
                table: "Deliveries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_Id",
                table: "Couriers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Id",
                table: "Clients",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Locations_Id",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Inquiries_Id",
                table: "Inquiries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_Id",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Couriers_Id",
                table: "Couriers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_Id",
                table: "Clients");
        }
    }
}
