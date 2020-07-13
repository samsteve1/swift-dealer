using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class SeedFeaturesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO features (Name) VALUES ('Auto Pilot')");
            migrationBuilder.Sql("INSERT INTO features (Name) VALUES ('Heater')");
            migrationBuilder.Sql("INSERT INTO features (Name) VALUES ('Wifi')");
            migrationBuilder.Sql("INSERT INTO features (Name) VALUES ('Navigation Assistant')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM features");
        }
    }
}
