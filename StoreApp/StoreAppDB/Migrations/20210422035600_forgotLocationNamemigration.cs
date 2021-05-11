using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreAppDB.Migrations
{
    public partial class forgotLocationNamemigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Locations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Locations");
        }
    }
}
