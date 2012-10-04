using FluentMigrator;


namespace Skeletor.DatabaseMigrations
{

    [Migration(201210031600)]
    public class CreateUserTable : Migration
    {
        public override void Up()
        {
            Create.Table("User")
                  .WithColumn("UserId").AsCustom("uniqueidentifier").PrimaryKey().WithDefault(SystemMethods.NewSequentialId)
                  .WithColumn("UserName").AsString(200).NotNullable()
                  .WithColumn("FirstName").AsString(200).NotNullable()
                  .WithColumn("LastnNme").AsString(200).NotNullable()
                  .WithColumn("Email").AsString(255).NotNullable()
                  .WithColumn("IsSystem").AsBoolean().NotNullable().WithDefaultValue(false)
                  .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(false)
                  .WithColumn("IsDeleted").AsBoolean().NotNullable().WithDefaultValue(false)
                  .WithColumn("IsLockedOut").AsBoolean().NotNullable().WithDefaultValue(false)
                  .WithColumn("LockoutDateTime").AsDateTime().Nullable()
                  .WithColumn("Password").AsString(30).NotNullable()
                  .WithColumn("Salt").AsString(100).NotNullable()
                  .WithColumn("PasswordExpiry").AsDateTime().NotNullable()
                  .WithColumn("CreatedByUserId").AsGuid().Nullable()
                  .WithColumn("CreatedUtcDate").AsDateTime().Nullable()
                  .WithColumn("ModifiedByUserId").AsGuid().Nullable()
                  .WithColumn("ModifiedUtcDate").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("User");
        }
    }
}
