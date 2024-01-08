using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierCastingApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SessionHistory_Id",
                table: "SessionHistory",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SessionHistory_Id",
                table: "SessionHistory");
        }
    }
}
