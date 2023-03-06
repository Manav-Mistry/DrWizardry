using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrWizardry.Migrations
{
    public partial class addedVocabSynonym : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Synonym",
                columns: table => new
                {
                    SynonymId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Synonym", x => x.SynonymId);
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
                name: "IX_VocabSynonym_SynonymId",
                table: "VocabSynonym",
                column: "SynonymId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VocabSynonym");

            migrationBuilder.DropTable(
                name: "Synonym");
        }
    }
}
