using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Migrations
{
    public partial class diuuuee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "MajorID",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MajorID",
                table: "AspNetUsers",
                column: "MajorID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Major_MajorID",
                table: "AspNetUsers",
                column: "MajorID",
                principalTable: "Major",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Major_MajorID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MajorID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "MajorID",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
