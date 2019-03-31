using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Migrations
{
    public partial class asdasdss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "advertisementType1",
            //    table: "Advertisement");

            //migrationBuilder.AddColumn<int>(
            //    name: "advertisementType",
            //    table: "Advertisement",
            //    nullable: false,
            //    defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "advertisementType",
                table: "Advertisement");

            migrationBuilder.AddColumn<int>(
                name: "advertisementType1",
                table: "Advertisement",
                nullable: false,
                defaultValue: 0);
        }
    }
}
