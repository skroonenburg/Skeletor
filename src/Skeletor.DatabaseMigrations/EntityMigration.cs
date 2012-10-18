using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace Skeletor.DatabaseMigrations
{
    public class EntityMigration : Migration
    {
        public EntityMigration(string tableName, string primaryKey)
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

        public virtual ICreateTableColumnOptionOrWithColumnSyntax GetTable()
        {
            return Create.Table(TableName)
                .WithColumn(PrimaryKey).AsGuid().PrimaryKey();
        }

        public string TableName { get; protected set; }
        public string PrimaryKey { get; protected set; }
    }
}