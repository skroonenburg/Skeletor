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
        }

        public override void Down()
        {
            Delete.Table("[AuditActionType]");
        }
    }
}
