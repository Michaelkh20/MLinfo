using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MLinfo_v1._0.Migrations
{
    public partial class AddSecondaryArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SecondaryArticleID",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SecondaryArticleID",
                table: "Articles",
                column: "SecondaryArticleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Articles_SecondaryArticleID",
                table: "Articles",
                column: "SecondaryArticleID",
                principalTable: "Articles",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Articles_SecondaryArticleID",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_SecondaryArticleID",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "SecondaryArticleID",
                table: "Articles");
        }
    }
}
