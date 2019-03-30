using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Migrations
{
    public partial class changeaspuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropForeignKey(
				name: "FK_AspNetUsers_Major_MajorID",
				table: "AspNetUsers");

			//migrationBuilder.RenameColumn(
			//	name: "ParentMajorID",
			//	table: "Major",
			//	newName: "ParentID");

			//migrationBuilder.RenameIndex(
			//	name: "IX_Major_ParentMajorID",
			//	table: "Major",
			//	newName: "IX_Major_ParentID");

			migrationBuilder.AddForeignKey(
				name: "FK_AspNetUsers_Major_MajorID",
				table: "AspNetUsers",
				column: "MajorID",
				principalTable: "Major",
				principalColumn: "ID",
				onDelete: ReferentialAction.NoAction);
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
