using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Migrations
{
    public partial class sdafsdgg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Major_MajorID",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementEducationLevel_Advertisement_AdvertisementID",
                table: "AdvertisementEducationLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementEducationLevel_EducationLevel_EducationLevelID",
                table: "AdvertisementEducationLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementMajor_Advertisement_AdvertisementID",
                table: "AdvertisementMajor");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementMajor_Major_MajorID",
                table: "AdvertisementMajor");

            //migrationBuilder.DropIndex(
            //    name: "IX_Advertisement_MajorID",
            //    table: "Advertisement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertisementMajor",
                table: "AdvertisementMajor");

            migrationBuilder.DropIndex(
                name: "IX_AdvertisementMajor_AdvertisementID",
                table: "AdvertisementMajor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertisementEducationLevel",
                table: "AdvertisementEducationLevel");

            migrationBuilder.DropIndex(
                name: "IX_AdvertisementEducationLevel_AdvertisementID",
                table: "AdvertisementEducationLevel");

            migrationBuilder.DropColumn(
                name: "MajorID",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "AdvertisementMajor");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "AdvertisementEducationLevel");

            migrationBuilder.RenameTable(
                name: "AdvertisementMajor",
                newName: "AdvertisementMajors");

            migrationBuilder.RenameTable(
                name: "AdvertisementEducationLevel",
                newName: "AdvertisementEducationLevels");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertisementMajor_MajorID",
                table: "AdvertisementMajors",
                newName: "IX_AdvertisementMajors_MajorID");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertisementEducationLevel_EducationLevelID",
                table: "AdvertisementEducationLevels",
                newName: "IX_AdvertisementEducationLevels_EducationLevelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertisementMajors",
                table: "AdvertisementMajors",
                columns: new[] { "AdvertisementID", "MajorID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertisementEducationLevels",
                table: "AdvertisementEducationLevels",
                columns: new[] { "AdvertisementID", "EducationLevelID" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementEducationLevels_Advertisement_AdvertisementID",
                table: "AdvertisementEducationLevels",
                column: "AdvertisementID",
                principalTable: "Advertisement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementEducationLevels_EducationLevel_EducationLevelID",
                table: "AdvertisementEducationLevels",
                column: "EducationLevelID",
                principalTable: "EducationLevel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementMajors_Advertisement_AdvertisementID",
                table: "AdvertisementMajors",
                column: "AdvertisementID",
                principalTable: "Advertisement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementMajors_Major_MajorID",
                table: "AdvertisementMajors",
                column: "MajorID",
                principalTable: "Major",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementEducationLevels_Advertisement_AdvertisementID",
                table: "AdvertisementEducationLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementEducationLevels_EducationLevel_EducationLevelID",
                table: "AdvertisementEducationLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementMajors_Advertisement_AdvertisementID",
                table: "AdvertisementMajors");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertisementMajors_Major_MajorID",
                table: "AdvertisementMajors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertisementMajors",
                table: "AdvertisementMajors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertisementEducationLevels",
                table: "AdvertisementEducationLevels");

            migrationBuilder.RenameTable(
                name: "AdvertisementMajors",
                newName: "AdvertisementMajor");

            migrationBuilder.RenameTable(
                name: "AdvertisementEducationLevels",
                newName: "AdvertisementEducationLevel");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertisementMajors_MajorID",
                table: "AdvertisementMajor",
                newName: "IX_AdvertisementMajor_MajorID");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertisementEducationLevels_EducationLevelID",
                table: "AdvertisementEducationLevel",
                newName: "IX_AdvertisementEducationLevel_EducationLevelID");

            migrationBuilder.AddColumn<int>(
                name: "MajorID",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "AdvertisementMajor",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "AdvertisementEducationLevel",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertisementMajor",
                table: "AdvertisementMajor",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertisementEducationLevel",
                table: "AdvertisementEducationLevel",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_MajorID",
                table: "Advertisement",
                column: "MajorID");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementMajor_AdvertisementID",
                table: "AdvertisementMajor",
                column: "AdvertisementID");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementEducationLevel_AdvertisementID",
                table: "AdvertisementEducationLevel",
                column: "AdvertisementID");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Major_MajorID",
                table: "Advertisement",
                column: "MajorID",
                principalTable: "Major",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementEducationLevel_Advertisement_AdvertisementID",
                table: "AdvertisementEducationLevel",
                column: "AdvertisementID",
                principalTable: "Advertisement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementEducationLevel_EducationLevel_EducationLevelID",
                table: "AdvertisementEducationLevel",
                column: "EducationLevelID",
                principalTable: "EducationLevel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementMajor_Advertisement_AdvertisementID",
                table: "AdvertisementMajor",
                column: "AdvertisementID",
                principalTable: "Advertisement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertisementMajor_Major_MajorID",
                table: "AdvertisementMajor",
                column: "MajorID",
                principalTable: "Major",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
