using Microsoft.EntityFrameworkCore.Migrations;

namespace PrimeNumberDomain.Migrations
{
    public partial class prime_number_history : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrimeNumberHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<int>(nullable: false),
                    PrimeNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimeNumberHistories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrimeNumberHistories_Index",
                table: "PrimeNumberHistories",
                column: "Index",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrimeNumberHistories");
        }
    }
}
