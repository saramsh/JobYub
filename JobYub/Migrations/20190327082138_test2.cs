using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropColumn(
			 name: "Major",
			 table: "AspNetUsers");
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
