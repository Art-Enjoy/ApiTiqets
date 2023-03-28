using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "t_files",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "IdPhotoFile",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPhotoFile",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "t_files",
                newName: "Name");
        }
    }
}
