using Microsoft.EntityFrameworkCore.Migrations;

namespace INV_MS.Migrations
{
    public partial class adddesriptioncolumnintblitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "tblItem",
                type: "nvarchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "tblItem");
        }
    }
}
