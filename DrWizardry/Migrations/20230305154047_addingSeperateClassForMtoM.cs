using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrWizardry.Migrations
{
    public partial class addingSeperateClassForMtoM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVocab_User_UsersId",
                table: "UserVocab");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVocab_Vocab_VocabsId",
                table: "UserVocab");

            migrationBuilder.DropTable(
                name: "Synonym");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vocab",
                table: "Vocab");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "Vocab",
                newName: "Vocabs");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "VocabsId",
                table: "UserVocab",
                newName: "VocabId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "UserVocab",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVocab_VocabsId",
                table: "UserVocab",
                newName: "IX_UserVocab_VocabId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vocabs",
                newName: "VocabId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "UserVocab",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vocabs",
                table: "Vocabs",
                column: "VocabId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVocab_Users_UserId",
                table: "UserVocab",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVocab_Vocabs_VocabId",
                table: "UserVocab",
                column: "VocabId",
                principalTable: "Vocabs",
                principalColumn: "VocabId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVocab_Users_UserId",
                table: "UserVocab");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVocab_Vocabs_VocabId",
                table: "UserVocab");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vocabs",
                table: "Vocabs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "UserVocab");

            migrationBuilder.RenameTable(
                name: "Vocabs",
                newName: "Vocab");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "VocabId",
                table: "UserVocab",
                newName: "VocabsId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserVocab",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVocab_VocabId",
                table: "UserVocab",
                newName: "IX_UserVocab_VocabsId");

            migrationBuilder.RenameColumn(
                name: "VocabId",
                table: "Vocab",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vocab",
                table: "Vocab",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Synonym",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VocabId = table.Column<int>(type: "int", nullable: true),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Synonym", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Synonym_Vocab_VocabId",
                        column: x => x.VocabId,
                        principalTable: "Vocab",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Synonym_VocabId",
                table: "Synonym",
                column: "VocabId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVocab_User_UsersId",
                table: "UserVocab",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVocab_Vocab_VocabsId",
                table: "UserVocab",
                column: "VocabsId",
                principalTable: "Vocab",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
