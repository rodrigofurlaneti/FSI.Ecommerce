using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSI.Ecommerce.Infrastructure.Migrations
{
    public partial class UpdateUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Ecommerce_Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Ecommerce_Users");
        }
    }
}
