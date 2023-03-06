using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrWizardry.Migrations
{
    public partial class oneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserVocab");

            migrationBuilder.DropTable(
                name: "VocabSynonym");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Vocabs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VocabId",
                table: "Synonym",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vocabs_UserId",
                table: "Vocabs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Synonym_VocabId",
                table: "Synonym",
                column: "VocabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Synonym_Vocabs_VocabId",
                table: "Synonym",
                column: "VocabId",
                principalTable: "Vocabs",
                principalColumn: "VocabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vocabs_Users_UserId",
                table: "Vocabs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Synonym_Vocabs_VocabId",
                table: "Synonym");

            migrationBuilder.DropForeignKey(
                name: "FK_Vocabs_Users_UserId",
                table: "Vocabs");

            migrationBuilder.DropIndex(
                name: "IX_Vocabs_UserId",
                table: "Vocabs");

            migrationBuilder.DropIndex(
                name: "IX_Synonym_VocabId",
                table: "Synonym");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vocabs");

            migrationBuilder.DropColumn(
                name: "VocabId",
                table: "Synonym");

            migrationBuilder.CreateTable(
                name: "UserVocab",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VocabId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVocab", x => new { x.UserId, x.VocabId });
                    table.ForeignKey(
                        name: "FK_UserVocab_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVocab_Vocabs_VocabId",
                        column: x => x.VocabId,
                        principalTable: "Vocabs",
                        principalColumn: "VocabId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VocabSynonym",
                columns: table => new
                {
                    VocabId = table.Column<int>(type: "int", nullable: false),
                    SynonymId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabSynonym", x => new { x.VocabId, x.SynonymId });
                    table.ForeignKey(
                        name: "FK_VocabSynonym_Synonym_SynonymId",
                        column: x => x.SynonymId,
                        principalTable: "Synonym",
                        principalColumn: "SynonymId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VocabSynonym_Vocabs_VocabId",
                        column: x => x.VocabId,
                        principalTable: "Vocabs",
                        principalColumn: "VocabId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserVocab_VocabId",
                table: "UserVocab",
                column: "VocabId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabSynonym_SynonymId",
                table: "VocabSynonym",
                column: "SynonymId");
        }
    }
}
