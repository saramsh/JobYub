using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Migrations
{
    public partial class changeadddstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MajorIDs",
                table: "Advertisement");

            migrationBuilder.AlterColumn<int>(
                name: "CollaborationType",
                table: "Advertisement",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "advertisementType",
                table: "Advertisement",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AdvertisementMajor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdvertisementID = table.Column<int>(nullable: false),
                    MajorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementMajor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdvertisementMajor_Advertisement_AdvertisementID",
                        column: x => x.AdvertisementID,
                        principalTable: "Advertisement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertisementMajor_Major_MajorID",
                        column: x => x.MajorID,
                        principalTable: "Major",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementMajor_AdvertisementID",
                table: "AdvertisementMajor",
                column: "AdvertisementID");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementMajor_MajorID",
                table: "AdvertisementMajor",
                column: "MajorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementMajor");

            migrationBuilder.DropColumn(
                name: "advertisementType",
                table: "Advertisement");

            migrationBuilder.AlterColumn<string>(
                name: "CollaborationType",
                table: "Advertisement",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "MajorIDs",
                table: "Advertisement",
                nullable: true);
        }
    }
}
