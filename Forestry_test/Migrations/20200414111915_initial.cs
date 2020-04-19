using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Forestry_test.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    PointID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PointName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.PointID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Loc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocID);
                });

            migrationBuilder.CreateTable(
                name: "Mazists",
                columns: table => new
                {
                    CarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FIO = table.Column<string>(maxLength: 50, nullable: true),
                    CarNumber = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mazists", x => x.CarID);
                });

            migrationBuilder.CreateTable(
                name: "Sorts",
                columns: table => new
                {
                    SortID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SortD = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorts", x => x.SortID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProdID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SortID = table.Column<int>(nullable: true),
                    Lght = table.Column<int>(nullable: false),
                    Volume = table.Column<int>(nullable: false),
                    Quarters = table.Column<int>(nullable: false),
                    LocID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProdID);
                    table.ForeignKey(
                        name: "FK_Products_Locations_LocID",
                        column: x => x.LocID,
                        principalTable: "Locations",
                        principalColumn: "LocID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Sorts_SortID",
                        column: x => x.SortID,
                        principalTable: "Sorts",
                        principalColumn: "SortID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Forests",
                columns: table => new
                {
                    ForestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarID = table.Column<int>(nullable: true),
                    SortID = table.Column<int>(nullable: true),
                    Quarters = table.Column<int>(nullable: false),
                    PointID = table.Column<int>(nullable: true),
                    LocID = table.Column<int>(nullable: true),
                    LghtProdID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forests", x => x.ForestID);
                    table.ForeignKey(
                        name: "FK_Forests_Mazists_CarID",
                        column: x => x.CarID,
                        principalTable: "Mazists",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Forests_Products_LghtProdID",
                        column: x => x.LghtProdID,
                        principalTable: "Products",
                        principalColumn: "ProdID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Forests_Locations_LocID",
                        column: x => x.LocID,
                        principalTable: "Locations",
                        principalColumn: "LocID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Forests_Appointments_PointID",
                        column: x => x.PointID,
                        principalTable: "Appointments",
                        principalColumn: "PointID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Forests_Sorts_SortID",
                        column: x => x.SortID,
                        principalTable: "Sorts",
                        principalColumn: "SortID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forests_CarID",
                table: "Forests",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Forests_LghtProdID",
                table: "Forests",
                column: "LghtProdID");

            migrationBuilder.CreateIndex(
                name: "IX_Forests_LocID",
                table: "Forests",
                column: "LocID");

            migrationBuilder.CreateIndex(
                name: "IX_Forests_PointID",
                table: "Forests",
                column: "PointID");

            migrationBuilder.CreateIndex(
                name: "IX_Forests_SortID",
                table: "Forests",
                column: "SortID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LocID",
                table: "Products",
                column: "LocID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SortID",
                table: "Products",
                column: "SortID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forests");

            migrationBuilder.DropTable(
                name: "Mazists");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Sorts");
        }
    }
}
