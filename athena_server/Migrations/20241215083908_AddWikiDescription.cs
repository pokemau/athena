using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace athena_server.Migrations
{
    /// <inheritdoc />
    public partial class AddWikiDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Wikis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Wikis",
                keyColumn: "id",
                keyValue: 1,
                column: "description",
                value: "the original wiki");

            migrationBuilder.UpdateData(
                table: "Wikis",
                keyColumn: "id",
                keyValue: 2,
                column: "description",
                value: "for CS tryhards only");

            migrationBuilder.UpdateData(
                table: "Wikis",
                keyColumn: "id",
                keyValue: 3,
                column: "description",
                value: "for chill students only");

            migrationBuilder.UpdateData(
                table: "Wikis",
                keyColumn: "id",
                keyValue: 4,
                column: "description",
                value: "I am still learning");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Wikis");
        }
    }
}
