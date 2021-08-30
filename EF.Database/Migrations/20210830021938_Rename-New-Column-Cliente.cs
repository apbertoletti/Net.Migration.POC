using Microsoft.EntityFrameworkCore.Migrations;

namespace EF.Database.Migrations
{
    public partial class RenameNewColumnCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                EXEC sp_rename 'dbo.Cliente.NovaColunaTeste', 'Email', 'COLUMN';  
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                EXEC sp_rename 'dbo.Cliente.Email', 'NovaColunaTeste', 'COLUMN';  
                ");
        }
    }
}
