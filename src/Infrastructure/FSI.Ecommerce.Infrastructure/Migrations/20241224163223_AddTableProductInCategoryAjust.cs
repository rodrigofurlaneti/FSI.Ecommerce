using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSI.Ecommerce.Infrastructure.Migrations
{
    public partial class AddTableProductInCategoryAjust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity");

            migrationBuilder.RenameTable(
                name: "UserEntity",
                newName: "Ecommerce_Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ecommerce_Users",
                table: "Ecommerce_Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Ecommerce_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateInsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecommerce_Categories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ecommerce_Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ecommerce_Users",
                table: "Ecommerce_Users");

            migrationBuilder.RenameTable(
                name: "Ecommerce_Users",
                newName: "UserEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity",
                column: "Id");
        }
    }
}
