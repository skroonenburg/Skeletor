using System;
using FluentMigrator;

namespace Skeletor.DatabaseMigrations
{
    [Migration(201210311611)]
    public class CreateDefaultData : Migration
    {
        public CreateDefaultData() {}

        public override void Up()
        {
            // default roles
            Insert.IntoTable("[Role]").Row(new { RoleId = Guid.Parse("A781A9D2-3105-4F9A-A1F2-CF8F9B6E2789"), Name = "Administrator", IsActive = true, RowVersion = 1, CreatedByUserId = Guid.Empty, CreatedUtcDate = DateTime.UtcNow});

            // default audit action types
            Insert.IntoTable("AuditActionType").Row(new { AuditActionTypeId = Guid.Parse("750E895C-F0A6-45AB-85E4-ABCF98CAF470"), Name = "Create" });
            Insert.IntoTable("AuditActionType").Row(new { AuditActionTypeId = Guid.Parse("750E895C-F0A6-45AB-85E4-ABCF98CAF471"), Name = "Update" });
            Insert.IntoTable("AuditActionType").Row(new { AuditActionTypeId = Guid.Parse("750E895C-F0A6-45AB-85E4-ABCF98CAF472"), Name = "Delete" });
            Insert.IntoTable("AuditActionType").Row(new { AuditActionTypeId = Guid.Parse("750E895C-F0A6-45AB-85E4-ABCF98CAF473"), Name = "Soft Delete" });
        }

        public override void Down()
        {
            Delete.FromTable("[Role]").AllRows();
            Delete.FromTable("AuditActionType").AllRows();
        }
    }
}