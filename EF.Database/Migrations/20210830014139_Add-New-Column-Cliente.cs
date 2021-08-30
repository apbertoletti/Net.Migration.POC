using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.Database.Migrations
{
    public partial class AddNewColumnCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                migrationBuilder.Sql(@"
                    ALTER TABLE Cliente ADD NovaColunaTeste VARCHAR(MAX);
                    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE Cliente DROP COLUMN NovaColunaTeste;
                ");
        }
    }
}
