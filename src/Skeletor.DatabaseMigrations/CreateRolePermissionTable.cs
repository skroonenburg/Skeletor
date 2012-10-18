using FluentMigrator;

namespace Skeletor.DatabaseMigrations
{
    [Migration(201210181600)]
    public class CreateRolePermissionTable : Migration
    {
        public override void Up()
        {
            Create.Table("[RolePermission]")
                .WithColumn("RoleId").AsGuid().NotNullable()
                .WithColumn("PermissionId").AsGuid().NotNullable();
            
            Create.PrimaryKey("Pk_RolePermission_RoleIdUserId").OnTable("RolePermission").Columns(new[]{ "RoleId", "PermissionId"});
            Create.ForeignKey("Fk_RolePermission_UserId").FromTable("[RolePermission]").ForeignColumn("PermissionId").ToTable("[Permission]").PrimaryColumn("PermissionId");
            Create.ForeignKey("Fk_RolePermission_RoleId").FromTable("[RolePermission]").ForeignColumn("RoleId").ToTable("[Role]").PrimaryColumn("RoleId");
        }

        public override void Down()
        {
            Delete.Table("[RolePermission]");
        }
    }
}