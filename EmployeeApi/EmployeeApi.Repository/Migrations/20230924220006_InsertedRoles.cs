using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeApi.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InsertedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "328da7bc-b4e8-42f2-a4df-56a13ed1650e", "36ac48cc-ca68-4be1-9c31-a6f419fb8cc7", "Visitor", "VISITOR" },
                    { "6489b2a7-f36e-4234-9dc2-ee6104c17c1f", "29c4f2c5-b851-4807-adeb-64a75e83bd44", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "328da7bc-b4e8-42f2-a4df-56a13ed1650e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6489b2a7-f36e-4234-9dc2-ee6104c17c1f");
        }
    }
}
