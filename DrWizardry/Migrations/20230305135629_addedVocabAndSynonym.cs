using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrWizardry.Migrations
{
    public partial class addedVocabAndSynonym : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vocab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Example = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty_lvl = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vocab", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Synonym",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VocabId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "UserVocab",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    VocabsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVocab", x => new { x.UsersId, x.VocabsId });
                    table.ForeignKey(
                        name: "FK_UserVocab_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVocab_Vocab_VocabsId",
                        column: x => x.VocabsId,
                        principalTable: "Vocab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Synonym_VocabId",
                table: "Synonym",
                column: "VocabId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVocab_VocabsId",
                table: "UserVocab",
                column: "VocabsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Synonym");

            migrationBuilder.DropTable(
                name: "UserVocab");

            migrationBuilder.DropTable(
                name: "Vocab");
        }
    }
}
