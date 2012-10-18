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
            Create.ForeignKey("Fk_UserRole_UserId").FromTable("[UserRole]").ForeignColumn("UserId").ToTable("[User]").PrimaryColumn("UserId");
            Create.ForeignKey("Fk_UserRole_RoleId").FromTable("[UserRole]").ForeignColumn("RoleId").ToTable("[Role]").PrimaryColumn("RoleId");
        }

        public override void Down()
        {
            Delete.Table("[UserRole]");
        }
    }
}