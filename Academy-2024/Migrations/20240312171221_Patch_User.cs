using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy_2024.Migrations
{
    /// <inheritdoc />
    public partial class Patch_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn
            (
                name: "FirstName",
                table: "Users"
            );

            migrationBuilder.DropColumn
            (
                name: "LastName",
                table: "Users"
            );

            migrationBuilder.AddColumn<string>
            (
                name: "Name",
                table: "Users",
                type: "TEXT",
                nullable: true
            );
            migrationBuilder.AddColumn<string>
            (
                name: "Role",
                table: "Users",
                type: "TEXT",
                nullable: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn
            (
                name: "Name",
                table: "Users"
            );

            migrationBuilder.DropColumn
            (
                name: "Role",
                table: "Users"
            );
        }
    }
}
