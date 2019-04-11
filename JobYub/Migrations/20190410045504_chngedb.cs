using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Migrations
{
    public partial class chngedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_EducationLevel_EducationLevelID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "EducationLevelID",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_EducationLevel_EducationLevelID",
                table: "AspNetUsers",
                column: "EducationLevelID",
                principalTable: "EducationLevel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_EducationLevel_EducationLevelID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "EducationLevelID",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_EducationLevel_EducationLevelID",
                table: "AspNetUsers",
                column: "EducationLevelID",
                principalTable: "EducationLevel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
