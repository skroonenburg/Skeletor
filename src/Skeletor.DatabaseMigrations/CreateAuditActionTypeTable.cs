using System;
using FluentMigrator;


namespace Skeletor.DatabaseMigrations
{
    [Migration(201210181605)]
    public class CreateAuditActionTypeTable : EntityMigration
    {
        public CreateAuditActionTypeTable() : base("AuditActionType", "AuditActionTypeId") {}

        public override void Up()
        {
            GetTable()
                .WithColumn("Name").AsString(50).NotNullable();

            Insert.IntoTable("AuditActionType").Row(new {AuditActionTypeId = Guid.Parse("750E895C-F0A6-45AB-85E4-ABCF98CAF470"), Name = "Create"});
            Insert.IntoTable("AuditActionType").Row(new { AuditActionTypeId = Guid.Parse("750E895C-F0A6-45AB-85E4-ABCF98CAF471"), Name = "Update" });
            Insert.IntoTable("AuditActionType").Row(new { AuditActionTypeId = Guid.Parse("750E895C-F0A6-45AB-85E4-ABCF98CAF472"), Name = "Delete" });
            Insert.IntoTable("AuditActionType").Row(new { AuditActionTypeId = Guid.Parse("750E895C-F0A6-45AB-85E4-ABCF98CAF473"), Name = "Soft Delete" });
        }

        public override void Down()
        {

        }
    }
}
