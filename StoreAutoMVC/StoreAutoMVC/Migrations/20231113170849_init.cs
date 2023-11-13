using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreAutoMVC.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducingCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guarantee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineCapacity = table.Column<float>(type: "real", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    PriceEquipment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "NameBrand", "ProducingCountry" },
                values: new object[] { 1, "Mercedes-Benz", "Germany" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "NameBrand", "ProducingCountry" },
                values: new object[] { 2, "Audi", "Germany" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BodyType", "BrandId", "Guarantee", "NameModel" },
                values: new object[] { 1, "Crossover", 1, "5 years", "GLS" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BodyType", "BrandId", "Guarantee", "NameModel" },
                values: new object[] { 2, "Universal", 2, "6 years", "A6" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BodyType", "BrandId", "Guarantee", "NameModel" },
                values: new object[] { 3, "Sedan", 1, "10 years", "E-class" });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "DriverType", "EngineCapacity", "FuelType", "ModelId", "ModelYear", "PriceEquipment" },
                values: new object[] { 1, "All-wheel drive", 3f, "Gasoline", 1, 2020, 250000m });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "DriverType", "EngineCapacity", "FuelType", "ModelId", "ModelYear", "PriceEquipment" },
                values: new object[] { 2, "All-wheel drive", 2f, "Gasoline", 2, 2021, 200000m });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "DriverType", "EngineCapacity", "FuelType", "ModelId", "ModelYear", "PriceEquipment" },
                values: new object[] { 3, "Rear wheel drive", 3f, "Diesel", 3, 2019, 210000m });

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_ModelId",
                table: "Equipments",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
