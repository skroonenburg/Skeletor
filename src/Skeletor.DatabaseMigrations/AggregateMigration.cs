using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace Skeletor.DatabaseMigrations
{
    public class AggregateMigration : Migration
    {
        public AggregateMigration(string tableName, string primaryKey)
        {
            TableName = tableName;
            PrimaryKey = primaryKey;
        }

        public override void Up()
        {
            
        }

        public override void Down()
        {
            Delete.Table(TableName);
        }

        public ICreateTableColumnOptionOrWithColumnSyntax GetTable()
        {
            return Create.Table(TableName)
                .WithColumn(PrimaryKey).AsGuid().PrimaryKey()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("RowVersion").AsInt32().NotNullable()
                .WithColumn("CreatedByUserId").AsGuid().Nullable()
                .WithColumn("CreatedUtcDate").AsDateTime().Nullable()
                .WithColumn("ModifiedByUserId").AsGuid().Nullable()
                .WithColumn("ModifiedUtcDate").AsDateTime().Nullable();
        }

        public string TableName { get; protected set; }
        public string PrimaryKey { get; protected set; }
    }
}