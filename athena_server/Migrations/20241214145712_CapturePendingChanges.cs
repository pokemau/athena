using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace athena_server.Migrations
{
    /// <inheritdoc />
    public partial class CapturePendingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Wikis_WikiID",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "WikiName",
                table: "Wikis",
                newName: "wikiName");

            migrationBuilder.RenameColumn(
                name: "CreatorID",
                table: "Wikis",
                newName: "creatorID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Wikis",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WikiID",
                table: "Articles",
                newName: "wikiID");

            migrationBuilder.RenameColumn(
                name: "CreatorID",
                table: "Articles",
                newName: "creatorID");

            migrationBuilder.RenameColumn(
                name: "ArticleTitle",
                table: "Articles",
                newName: "articleTitle");

            migrationBuilder.RenameColumn(
                name: "ArticleContent",
                table: "Articles",
                newName: "articleContent");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Articles",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_WikiID",
                table: "Articles",
                newName: "IX_Articles_wikiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Wikis_wikiID",
                table: "Articles",
                column: "wikiID",
                principalTable: "Wikis",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Wikis_wikiID",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "wikiName",
                table: "Wikis",
                newName: "WikiName");

            migrationBuilder.RenameColumn(
                name: "creatorID",
                table: "Wikis",
                newName: "CreatorID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Wikis",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "wikiID",
                table: "Articles",
                newName: "WikiID");

            migrationBuilder.RenameColumn(
                name: "creatorID",
                table: "Articles",
                newName: "CreatorID");

            migrationBuilder.RenameColumn(
                name: "articleTitle",
                table: "Articles",
                newName: "ArticleTitle");

            migrationBuilder.RenameColumn(
                name: "articleContent",
                table: "Articles",
                newName: "ArticleContent");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Articles",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_wikiID",
                table: "Articles",
                newName: "IX_Articles_WikiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Wikis_WikiID",
                table: "Articles",
                column: "WikiID",
                principalTable: "Wikis",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
