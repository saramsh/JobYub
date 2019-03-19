using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Data.Migrations
{
    public partial class gfergergsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Advertisement_AspNetUsers_ApplicationUserId",
            //    table: "Advertisement");

            //migrationBuilder.DropIndex(
            //    name: "IX_Advertisement_ApplicationUserId",
            //    table: "Advertisement");

            //migrationBuilder.DropColumn(
            //    name: "ApplicationUserID",
            //    table: "Advertisement");

            //migrationBuilder.DropColumn(
            //    name: "ApplicationUserId",
            //    table: "Advertisement");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserID",
                table: "Advertisement",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_ApplicationUserId",
                table: "Advertisement",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_AspNetUsers_ApplicationUserId",
                table: "Advertisement",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
