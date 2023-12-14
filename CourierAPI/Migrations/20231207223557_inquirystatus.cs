using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourierAPI.Migrations
{
    /// <inheritdoc />
    public partial class inquirystatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InquiryStatus",
                table: "Inquiries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InquiryStatus",
                table: "Inquiries");
        }
    }
}
