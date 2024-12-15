using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace athena_server.Migrations
{
    /// <inheritdoc />
    public partial class NewComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "ArticleID", "CommentContent", "DateTimeSent", "SenderID" },
                values: new object[] { 1, 1, "Hello comment", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "caa56dca-255e-49b8-8c89-d41d7ce99687" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
