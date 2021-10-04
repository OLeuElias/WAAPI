using Microsoft.EntityFrameworkCore.Migrations;

namespace WAAPI.Migrations
{
    public partial class ffffff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueIdentifier",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniqueIdentifier",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
