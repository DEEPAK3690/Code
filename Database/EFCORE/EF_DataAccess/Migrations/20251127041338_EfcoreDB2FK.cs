using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EfcoreDB2FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookDetailId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookDetailId",
                table: "Books");
        }
    }
}
