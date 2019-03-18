using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Data.Migrations
{
    public partial class sfolj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Advertisement",
                nullable: false,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                table: "Advertisement",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
