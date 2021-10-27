using Microsoft.EntityFrameworkCore.Migrations;

namespace bikeShopWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BikeDetails",
                columns: table => new
                {
                    BikeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BikeType = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BikePrice = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    BikeRented = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeDetails", x => x.BikeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BikeDetails");
        }
    }
}
