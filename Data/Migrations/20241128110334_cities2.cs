using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class cities2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_HomePages_HomePageViewModelId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Locations_locationId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_HomePages_HomePageViewModelId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "HomePages");

            migrationBuilder.DropIndex(
                name: "IX_Cards_HomePageViewModelId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_locationId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "HomePageViewModelId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "locationId",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "Nmae",
                table: "Locations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "HomePageViewModelId",
                table: "Locations",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_HomePageViewModelId",
                table: "Locations",
                newName: "IX_Locations_CityId");

            migrationBuilder.AddColumn<string>(
                name: "Describtion",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Cities_CityId",
                table: "Locations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Cities_CityId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropColumn(
                name: "Describtion",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Locations",
                newName: "Nmae");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Locations",
                newName: "HomePageViewModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_CityId",
                table: "Locations",
                newName: "IX_Locations_HomePageViewModelId");

            migrationBuilder.AddColumn<int>(
                name: "HomePageViewModelId",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "locationId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HomePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_HomePageViewModelId",
                table: "Cards",
                column: "HomePageViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_locationId",
                table: "Cards",
                column: "locationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_HomePages_HomePageViewModelId",
                table: "Cards",
                column: "HomePageViewModelId",
                principalTable: "HomePages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Locations_locationId",
                table: "Cards",
                column: "locationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_HomePages_HomePageViewModelId",
                table: "Locations",
                column: "HomePageViewModelId",
                principalTable: "HomePages",
                principalColumn: "Id");
        }
    }
}
