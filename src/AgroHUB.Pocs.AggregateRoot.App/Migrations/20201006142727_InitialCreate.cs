using Microsoft.EntityFrameworkCore.Migrations;

namespace AggregateRoot.App.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FarmArea",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmArea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FarmAreaCoordinate",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmAreaId = table.Column<long>(nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmAreaCoordinate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmAreaCoordinate_FarmArea_FarmAreaId",
                        column: x => x.FarmAreaId,
                        principalTable: "FarmArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FarmAreaCoordinate_FarmAreaId",
                table: "FarmAreaCoordinate",
                column: "FarmAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FarmAreaCoordinate");

            migrationBuilder.DropTable(
                name: "FarmArea");
        }
    }
}
