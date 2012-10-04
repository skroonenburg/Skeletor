using FluentMigrator;

namespace Skeletor.DatabaseMigrations
{
    [Migration(201210041940)]
    public class CreatePermissionTable : Migration
    {
        public override void Up()
        {
            Create.Table("[Permission]")
                .WithColumn("PermissionId").AsGuid().PrimaryKey()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("PasswordExpiry").AsDateTime().NotNullable()
                .WithColumn("CreatedByUserId").AsGuid().Nullable()
                .WithColumn("CreatedUtcDate").AsDateTime().Nullable()
                .WithColumn("ModifiedByUserId").AsGuid().Nullable()
                .WithColumn("ModifiedUtcDate").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("[Permission]");
        }
    }
}