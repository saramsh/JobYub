using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Migrations
{
    public partial class changeads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Major_MajorId",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "EducationLevel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "Advertisement");

            //migrationBuilder.RenameColumn(
            //    name: "MajorId",
            //    table: "Advertisement",
            //    newName: "MajorID");

            migrationBuilder.RenameColumn(
                name: "EducationLevel",
                table: "Advertisement",
                newName: "SalaryType");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Advertisement_MajorId",
            //    table: "Advertisement",
            //    newName: "IX_Advertisement_MajorID");

            migrationBuilder.DropColumn("Photo", "AspNetUsers");

            //migrationBuilder.AddColumn<byte[]>("Photo", "AspNetUsers");
            //migrationBuilder.AlterColumn<byte[]>(
            //    name: "Photo",
            //    table: "AspNetUsers",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldNullable: true);
          

            migrationBuilder.AlterColumn<int>(
                name: "MilitaryStatus",
                table: "AspNetUsers",
                nullable:true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longtitude",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EducationLevelID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MajorID",
                table: "Advertisement",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "Graduated",
                table: "Advertisement",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxAge",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinAge",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EducationLevel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AdvertisementID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EducationLevel_Advertisement_AdvertisementID",
                        column: x => x.AdvertisementID,
                        principalTable: "Advertisement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EducationLevelID",
                table: "AspNetUsers",
                column: "EducationLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_EducationLevel_AdvertisementID",
                table: "EducationLevel",
                column: "AdvertisementID");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Major_MajorID",
                table: "Advertisement",
                column: "MajorID",
                principalTable: "Major",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_EducationLevel_EducationLevelID",
                table: "AspNetUsers",
                column: "EducationLevelID",
                principalTable: "EducationLevel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Major_MajorID",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_EducationLevel_EducationLevelID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EducationLevel");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EducationLevelID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EducationLevelID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaxAge",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "MinAge",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Advertisement");

            migrationBuilder.RenameColumn(
                name: "MajorID",
                table: "Advertisement",
                newName: "MajorId");

            migrationBuilder.RenameColumn(
                name: "SalaryType",
                table: "Advertisement",
                newName: "EducationLevel");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisement_MajorID",
                table: "Advertisement",
                newName: "IX_Advertisement_MajorId");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MilitaryStatus",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Longtitude",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "EducationLevel",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MajorId",
                table: "Advertisement",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Graduated",
                table: "Advertisement",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "Advertisement",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Major_MajorId",
                table: "Advertisement",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
