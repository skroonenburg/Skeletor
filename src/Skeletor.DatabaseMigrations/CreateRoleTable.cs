using FluentMigrator;

namespace Skeletor.DatabaseMigrations
{
    [Migration(201210041920)]
    public class CreateRoleTable : Migration
    {
        public override void Up()
        {
            Create.Table("[Role]")
                .WithColumn("RoleId").AsGuid().PrimaryKey()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("PasswordExpiry").AsDateTime().NotNullable()
                .WithColumn("CreatedByUserId").AsGuid().Nullable()
                .WithColumn("CreatedUtcDate").AsDateTime().Nullable()
                .WithColumn("ModifiedByUserId").AsGuid().Nullable()
                .WithColumn("ModifiedUtcDate").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("[Role]");
        }
    }
}