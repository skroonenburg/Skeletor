using FluentMigrator;

namespace Skeletor.DatabaseMigrations
{
    [Migration(201210041940)]
    public class CreatePermissionTable : AggregateMigration
    {

        public CreatePermissionTable() : base("[Permission]", "PermissionId") {}

        public override void Up()
        {
            GetTable()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable();
        }
        
        public override void Down()
        {
            Delete.Table("[Permission]");
        }
    }
}