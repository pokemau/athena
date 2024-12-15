using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace athena_server.Migrations
{
    /// <inheritdoc />
    public partial class AddNewComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "ArticleID", "CommentContent", "DateTimeSent", "SenderID" },
                values: new object[] { 1, 1, "Hello comment", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "6a064981-b6c5-468d-b5c3-312e537d3cf0" });
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
