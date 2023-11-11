using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddClientEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Deliveries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_ClientId",
                table: "Deliveries",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Clients_ClientId",
                table: "Deliveries",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Clients_ClientId",
                table: "Deliveries");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_ClientId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Deliveries");
        }
    }
}
