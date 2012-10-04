using FluentMigrator;

namespace Skeletor.DatabaseMigrations
{
    [Migration(201210041930)]
    public class CreateUserRoleTable : Migration
    {
        public override void Up()
        {
            Create.Table("[UserRole]")
                .WithColumn("RoleId").AsGuid().NotNullable()
                .WithColumn("UserId").AsGuid().NotNullable();

            Create.PrimaryKey("Pk_UserRole_RoleIdUserId").OnTable("UserRole").Columns(new[]{ "RoleId", "UserId"});
            Create.ForeignKey("Fk_UserRole_UserId").FromTable("[User]").ForeignColumn("UserId").ToTable("UserRole").PrimaryColumn("UserId");
            Create.ForeignKey("Fk_UserRole_RoleId").FromTable("[Role]").ForeignColumn("RoleId").ToTable("UserRole").PrimaryColumn("RoleId");
        }

        public override void Down()
        {
            Delete.Table("[UserRole]");
        }
    }
}