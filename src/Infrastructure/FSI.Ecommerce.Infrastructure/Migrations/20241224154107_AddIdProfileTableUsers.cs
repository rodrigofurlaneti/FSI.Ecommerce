using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSI.Ecommerce.Infrastructure.Migrations
{
    public partial class AddIdProfileTableUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProfile",
                table: "Ecommerce_Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProfile",
                table: "Ecommerce_Users");
        }
    }
}
