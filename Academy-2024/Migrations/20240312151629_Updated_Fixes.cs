using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy_2024.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Users",
                newName: "DateOfBirth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Users",
                newName: "Age");
        }
    }
}
