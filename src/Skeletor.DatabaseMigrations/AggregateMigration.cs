using FluentMigrator.Builders.Create.Table;

namespace Skeletor.DatabaseMigrations
{
    public class AggregateMigration : EntityMigration
    {
        public AggregateMigration(string tableName, string primaryKey) :base (tableName, primaryKey) {}

        public override ICreateTableColumnOptionOrWithColumnSyntax GetTable()
        {
            return base.GetTable()
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("RowVersion").AsInt32().NotNullable()
                .WithColumn("CreatedByUserId").AsGuid().Nullable()
                .WithColumn("CreatedUtcDate").AsDateTime().Nullable()
                .WithColumn("ModifiedByUserId").AsGuid().Nullable()
                .WithColumn("ModifiedUtcDate").AsDateTime().Nullable();
        }

    }
}