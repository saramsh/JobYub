using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Migrations
{
    public partial class mjhg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Advertisement_Major_MajorID",
            //    table: "Advertisement");

            //migrationBuilder.RenameColumn(
            //    name: "MajorID",
            //    table: "Advertisement",
            //    newName: "MajorId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Advertisement_MajorID",
            //    table: "Advertisement",
            //    newName: "IX_Advertisement_MajorId");

            //migrationBuilder.AlterColumn<int>(
            //    name: "MajorId",
            //    table: "Advertisement",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldNullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Advertisement_Major_MajorId",
            //    table: "Advertisement",
            //    column: "MajorId",
            //    principalTable: "Major",
            //    principalColumn: "ID",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Major_MajorId",
                table: "Advertisement");

            migrationBuilder.RenameColumn(
                name: "MajorId",
                table: "Advertisement",
                newName: "MajorID");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisement_MajorId",
                table: "Advertisement",
                newName: "IX_Advertisement_MajorID");

            migrationBuilder.AlterColumn<int>(
                name: "MajorID",
                table: "Advertisement",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Major_MajorID",
                table: "Advertisement",
                column: "MajorID",
                principalTable: "Major",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
