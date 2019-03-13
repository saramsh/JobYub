using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobYub.Data.Migrations
{
    public partial class wefefwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentID = table.Column<int>(nullable: false),
                    ParentCategoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JobCategory_JobCategory_ParentCategoryID",
                        column: x => x.ParentCategoryID,
                        principalTable: "JobCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarrif",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Days = table.Column<int>(nullable: false),
                    Price = table.Column<string>(nullable: true),
                    PriorityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarrif", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Advertisement",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    TagIDs = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(nullable: true),
                    CollaborationType = table.Column<string>(nullable: true),
                    MinSalary = table.Column<int>(nullable: false),
                    MaxSalary = table.Column<int>(nullable: false),
                    EducationLevel = table.Column<string>(nullable: true),
                    Age = table.Column<short>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    ActivationStatus = table.Column<bool>(nullable: false),
                    JobCategoryID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    RegionID = table.Column<int>(nullable: false),
                    TarrifID = table.Column<int>(nullable: false),
                    Confirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Advertisement_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertisement_JobCategory_JobCategoryID",
                        column: x => x.JobCategoryID,
                        principalTable: "JobCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertisement_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Advertisement_Tarrif_TarrifID",
                        column: x => x.TarrifID,
                        principalTable: "Tarrif",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_CityID",
                table: "Advertisement",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_JobCategoryID",
                table: "Advertisement",
                column: "JobCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_RegionID",
                table: "Advertisement",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_TarrifID",
                table: "Advertisement",
                column: "TarrifID");

            migrationBuilder.CreateIndex(
                name: "IX_JobCategory_ParentCategoryID",
                table: "JobCategory",
                column: "ParentCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisement");

            migrationBuilder.DropTable(
                name: "JobCategory");

            migrationBuilder.DropTable(
                name: "Tarrif");
        }
    }
}
