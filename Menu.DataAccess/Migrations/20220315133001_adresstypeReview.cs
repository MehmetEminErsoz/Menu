using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu.DataAccess.Migrations
{
    public partial class adresstypeReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adress_C_AdressType_IdAdress",
                table: "Adress_C");

            migrationBuilder.CreateIndex(
                name: "IX_Adress_C_IdAdressType",
                table: "Adress_C",
                column: "IdAdressType");

            migrationBuilder.AddForeignKey(
                name: "FK_Adress_C_AdressType_IdAdressType",
                table: "Adress_C",
                column: "IdAdressType",
                principalTable: "AdressType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adress_C_AdressType_IdAdressType",
                table: "Adress_C");

            migrationBuilder.DropIndex(
                name: "IX_Adress_C_IdAdressType",
                table: "Adress_C");

            migrationBuilder.AddForeignKey(
                name: "FK_Adress_C_AdressType_IdAdress",
                table: "Adress_C",
                column: "IdAdress",
                principalTable: "AdressType",
                principalColumn: "Id");
        }
    }
}
