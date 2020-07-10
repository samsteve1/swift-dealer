using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO makes (Name) VALUES ('Toyota')");
            migrationBuilder.Sql("INSERT INTO makes (Name) VALUES ('Honda')");
            migrationBuilder.Sql("INSERT INTO makes (Name) VALUES ('Jeep')");

            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES ('Venza 2020', (SELECT Id FROM makes WHERE Name = 'Toyota'))");
            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES ('Camry 2018', (SELECT Id FROM makes WHERE Name = 'Toyota'))");
            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES ('Corrola 2020', (SELECT Id FROM makes WHERE Name = 'Toyota'))");

            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES ('EOD 2020', (SELECT Id FROM makes WHERE Name = 'Honda'))");
            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES ('Evil Spirit', (SELECT Id FROM makes WHERE Name = 'Honda'))");
            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES ('Accord 2010', (SELECT Id FROM makes WHERE Name = 'Honda'))");

             migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES ('Wizzle 2012', (SELECT Id FROM makes WHERE Name = 'Jeep'))");
            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES ('Jeffy 2000', (SELECT Id FROM makes WHERE Name = 'Jeep'))");
            migrationBuilder.Sql("INSERT INTO models (Name, MakeId) VALUES ('Never Old 1999', (SELECT Id FROM makes WHERE Name = 'Jeep'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM makes WHERE Name in ('Toyota', 'Honda', 'Jeep')");
            migrationBuilder.Sql("DELETE FROM models"); 
        }   
    }
}
