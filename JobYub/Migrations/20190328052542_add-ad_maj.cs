using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Migrations
{
    public partial class addad_maj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Advertisement_Major_MajorID",
            //    table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_Major_Major_ParentMajorID",
                table: "Major");

            //migrationBuilder.DropIndex(
            //    name: "IX_Advertisement_MajorID",
            //    table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "Major");

            //migrationBuilder.DropColumn(
            //    name: "MajorID",
            //    table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "MajorIDs",
                table: "Advertisement");

            migrationBuilder.AlterColumn<int>(
                name: "ParentMajorID",
                table: "Major",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Major_Major_ParentMajorID",
                table: "Major",
                column: "ParentMajorID",
                principalTable: "Major",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Major_Major_ParentMajorID",
                table: "Major");

            migrationBuilder.DropTable(
                name: "AdvertisementMajor");

            migrationBuilder.AlterColumn<int>(
                name: "ParentMajorID",
                table: "Major",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "Major",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MajorID",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MajorIDs",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_MajorID",
                table: "Advertisement",
                column: "MajorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Major_MajorID",
                table: "Advertisement",
                column: "MajorID",
                principalTable: "Major",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Major_Major_ParentMajorID",
                table: "Major",
                column: "ParentMajorID",
                principalTable: "Major",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
