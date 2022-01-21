using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace EF.Database
{
    public class AppContext : DbContext
    {
        //The connection string can be read from the some external file
        private string _connectionString;

        public AppContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .ReplaceService<IHistoryRepository, MyHistoryRepository>()
                .EnableSensitiveDataLogging();
        }
    }

    internal class MyHistoryRepository : SqlServerHistoryRepository
    {
        public MyHistoryRepository(HistoryRepositoryDependencies dependencies)
            : base(dependencies)
        {
        }

        protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
        {
            base.ConfigureTable(history);

            history.Property(h => h.MigrationId)
                .HasColumnName("Name")
                .HasMaxLength(200);

            history.Property(h => h.ProductVersion)
                .HasColumnName("VersionEF");

            history.Property<DateTime>("Applied")
                .IsRequired(true);

            history.Property<string>("User")
                .IsRequired(true)
                .HasMaxLength(200);

            history.Property<string>("Machine")
                .IsRequired(true)
                .HasMaxLength(200);
        }

        public override string GetInsertScript(HistoryRow row)
        {
            var stringTypeMapping = Dependencies.TypeMappingSource.GetMapping(typeof(string));
            return new StringBuilder().Append("INSERT INTO ")
                .Append(SqlGenerationHelper.DelimitIdentifier(TableName, TableSchema))
                .Append(" (")
                .Append(SqlGenerationHelper.DelimitIdentifier(MigrationIdColumnName))
                .Append(", ")
                .Append(SqlGenerationHelper.DelimitIdentifier(ProductVersionColumnName))
                .Append(", [Applied], [User], [Machine])")
                .Append("VALUES (")
                .Append(stringTypeMapping.GenerateSqlLiteral(row.MigrationId))
                .Append(", ")
                .Append(stringTypeMapping.GenerateSqlLiteral(row.ProductVersion))
                .Append($", GETDATE()")
                .Append($", '{Environment.UserName}'")
                .Append($", '{Environment.MachineName}'")
                .Append(")")
                .AppendLine(SqlGenerationHelper.StatementTerminator)
                .ToString();
        }
    }
}
