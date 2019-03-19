using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Data.Migrations
{
    public partial class makepaymentoptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_AspNetUsers_ApplicationUserId",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Payment_PaymentID",
                table: "Advertisement");

            //migrationBuilder.DropColumn(
            //    name: "ApplicationUserID",
            //    table: "Advertisement");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Advertisement",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisement_ApplicationUserId",
                table: "Advertisement",
                newName: "IX_Advertisement_ApplicationUserID");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentID",
                table: "Advertisement",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_AspNetUsers_ApplicationUserID",
                table: "Advertisement",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Payment_PaymentID",
                table: "Advertisement",
                column: "PaymentID",
                principalTable: "Payment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_AspNetUsers_ApplicationUserID",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Payment_PaymentID",
                table: "Advertisement");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Advertisement",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisement_ApplicationUserID",
                table: "Advertisement",
                newName: "IX_Advertisement_ApplicationUserId");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentID",
                table: "Advertisement",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserID",
                table: "Advertisement",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_AspNetUsers_ApplicationUserId",
                table: "Advertisement",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Payment_PaymentID",
                table: "Advertisement",
                column: "PaymentID",
                principalTable: "Payment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
