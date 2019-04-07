using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Migrations
{
    public partial class educatelevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationLevel_Advertisement_AdvertisementID",
                table: "EducationLevel");

            migrationBuilder.DropIndex(
                name: "IX_EducationLevel_AdvertisementID",
                table: "EducationLevel");

            migrationBuilder.DropColumn(
                name: "AdvertisementID",
                table: "EducationLevel");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Advertisement");

            migrationBuilder.CreateTable(
                name: "AdvertisementEducationLevel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdvertisementID = table.Column<int>(nullable: false),
                    EducationLevelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementEducationLevel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdvertisementEducationLevel_Advertisement_AdvertisementID",
                        column: x => x.AdvertisementID,
                        principalTable: "Advertisement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertisementEducationLevel_EducationLevel_EducationLevelID",
                        column: x => x.EducationLevelID,
                        principalTable: "EducationLevel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementEducationLevel_AdvertisementID",
                table: "AdvertisementEducationLevel",
                column: "AdvertisementID");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementEducationLevel_EducationLevelID",
                table: "AdvertisementEducationLevel",
                column: "EducationLevelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementEducationLevel");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementID",
                table: "EducationLevel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EducationLevel_AdvertisementID",
                table: "EducationLevel",
                column: "AdvertisementID");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationLevel_Advertisement_AdvertisementID",
                table: "EducationLevel",
                column: "AdvertisementID",
                principalTable: "Advertisement",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
