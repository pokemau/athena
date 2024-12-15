using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace athena_server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWiki : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "creatorName",
                table: "Wikis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleID = table.Column<int>(type: "int", nullable: false),
                    SenderID = table.Column<int>(type: "int", nullable: false),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeSent = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "ArticleID", "CommentContent", "DateTimeSent", "SenderID" },
                values: new object[] { 1, 1, "Hello comment", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Wikis",
                keyColumn: "id",
                keyValue: 1,
                column: "creatorName",
                value: "Mau");

            migrationBuilder.UpdateData(
                table: "Wikis",
                keyColumn: "id",
                keyValue: 2,
                column: "creatorName",
                value: "Mau");

            migrationBuilder.UpdateData(
                table: "Wikis",
                keyColumn: "id",
                keyValue: 3,
                column: "creatorName",
                value: "Mau");

            migrationBuilder.UpdateData(
                table: "Wikis",
                keyColumn: "id",
                keyValue: 4,
                column: "creatorName",
                value: "Jorosh");

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

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropColumn(
                name: "creatorName",
                table: "Wikis");

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
