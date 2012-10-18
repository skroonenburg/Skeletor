using FluentMigrator;


namespace Skeletor.DatabaseMigrations
{
    [Migration(201210031600)]
    public class CreateUserTable : AggregateMigration
    {
        public CreateUserTable() : base("User", "UserId")
        {
        }

        public override void Up()
        {

            GetTable().WithColumn("UserName").AsString(200).NotNullable()
                      .WithColumn("FirstName").AsString(200).NotNullable()
                      .WithColumn("LastName").AsString(200).NotNullable()
                      .WithColumn("Email").AsString(255).NotNullable()
                      .WithColumn("IsSystem").AsBoolean().NotNullable().WithDefaultValue(false)
                      .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(false)
                      .WithColumn("IsLockedOut").AsBoolean().NotNullable().WithDefaultValue(false)
                      .WithColumn("LastLockoutUtcDate").AsDateTime().Nullable()
                      .WithColumn("PasswordHash").AsString(200).NotNullable()
                      .WithColumn("Salt").AsString(100).NotNullable()
                      .WithColumn("PasswordExpiry").AsDateTime().NotNullable();
        }

        public override void Down()
        {

        }
    }
}
