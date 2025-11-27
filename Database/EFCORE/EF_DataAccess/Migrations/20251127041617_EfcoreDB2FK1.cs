using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EfcoreDB2FK1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_Books_Book_Id",
                table: "BookDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookDetails_Book_Id",
                table: "BookDetails");

            migrationBuilder.DropColumn(
                name: "Book_Id",
                table: "BookDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetailId",
                table: "Books",
                column: "BookDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetails_BookDetailId",
                table: "Books",
                column: "BookDetailId",
                principalTable: "BookDetails",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetails_BookDetailId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetailId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "Book_Id",
                table: "BookDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookDetails_Book_Id",
                table: "BookDetails",
                column: "Book_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_Books_Book_Id",
                table: "BookDetails",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
