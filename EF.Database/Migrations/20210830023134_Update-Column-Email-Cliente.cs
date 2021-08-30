using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.Database.Migrations
{
    public partial class UpdateColumnEmailCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE Cliente SET Email = 'andre@empresa.com' WHERE Id = 1;
                UPDATE Cliente SET Email = 'rafa@uol.com' WHERE Id = 2;
                UPDATE Cliente SET Email = 'cicero@empresa.com' WHERE Id = 3;
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE Cliente SET Email = NULL WHERE Id = 1;
                UPDATE Cliente SET Email = NULL WHERE Id = 2;
                UPDATE Cliente SET Email = NULL WHERE Id = 3;
                ");
        }
    }
}
