using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrWizardry.Migrations
{
    public partial class addedUserIdFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocabs_Users_UserId",
                table: "Vocabs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Vocabs",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Vocabs_UserId",
                table: "Vocabs",
                newName: "IX_Vocabs_UserID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Vocabs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vocabs_Users_UserID",
                table: "Vocabs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocabs_Users_UserID",
                table: "Vocabs");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Vocabs",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Vocabs_UserID",
                table: "Vocabs",
                newName: "IX_Vocabs_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Vocabs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vocabs_Users_UserId",
                table: "Vocabs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
