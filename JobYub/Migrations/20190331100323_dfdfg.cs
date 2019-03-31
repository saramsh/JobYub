using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Migrations
{
    public partial class dfdfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Advertisement_Major_MajorID",
            //    table: "Advertisement");
            migrationBuilder.AddColumn<int>(name: "MajorID", table: "Advertisement", type: "int");
            //migrationBuilder.AlterColumn<int>(
            //    name: "MajorID",
            //    table: "Advertisement",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Major_MajorID",
                table: "Advertisement",
                column: "MajorID",
                principalTable: "Major",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Major_MajorID",
                table: "Advertisement");

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
