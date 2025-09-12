using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Phonebook.Migrations
{
    /// <inheritdoc />
    public partial class SeperateContactSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CategoryId", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 3, "", "John Smith", "0800 12 3456" },
                    { 2, 2, "", "Jane Doe", "07 1234 567890" },
                    { 3, 1, "", "Jane Smith", "555 123 4567" }
                });
        }
    }
}
