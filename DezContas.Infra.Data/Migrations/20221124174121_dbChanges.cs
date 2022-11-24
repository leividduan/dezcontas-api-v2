using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DezContas.Infra.Data.Migrations
{
    public partial class dbChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_User_Id_User",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_User_Id_User",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "Id_User",
                table: "Category",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_Id_User",
                table: "Category",
                newName: "IX_Category_UserId");

            migrationBuilder.RenameColumn(
                name: "Id_User",
                table: "Account",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Account_Id_User",
                table: "Account",
                newName: "IX_Account_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_User_UserId",
                table: "Account",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_User_UserId",
                table: "Category",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_User_UserId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_User_UserId",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Category",
                newName: "Id_User");

            migrationBuilder.RenameIndex(
                name: "IX_Category_UserId",
                table: "Category",
                newName: "IX_Category_Id_User");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Account",
                newName: "Id_User");

            migrationBuilder.RenameIndex(
                name: "IX_Account_UserId",
                table: "Account",
                newName: "IX_Account_Id_User");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_User_Id_User",
                table: "Account",
                column: "Id_User",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_User_Id_User",
                table: "Category",
                column: "Id_User",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
