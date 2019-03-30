using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Migrations
{
    public partial class fgrt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MajorID1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MajorID1",
                table: "AspNetUsers",
                column: "MajorID1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Major_MajorID1",
                table: "AspNetUsers",
                column: "MajorID1",
                principalTable: "Major",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Major_MajorID1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MajorID1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MajorID1",
                table: "AspNetUsers");
        }
    }
}
