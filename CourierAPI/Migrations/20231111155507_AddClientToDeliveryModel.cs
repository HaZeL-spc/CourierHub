using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddClientToDeliveryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Clients_ClientId",
                table: "Deliveries");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Deliveries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Clients_ClientId",
                table: "Deliveries",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Clients_ClientId",
                table: "Deliveries");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Deliveries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Clients_ClientId",
                table: "Deliveries",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
