using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.DataAccess.Migrations
{
    public partial class PersonTableRenew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Person",
                newName: "IsEmailConfirmed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsEmailConfirmed",
                table: "Person",
                newName: "Active");
        }
    }
}
