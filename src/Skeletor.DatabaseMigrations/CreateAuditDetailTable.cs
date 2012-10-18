using FluentMigrator;


namespace Skeletor.DatabaseMigrations
{
    [Migration(201210181610)]
    public class CreateAuditDetailTable : EntityMigration
    {
        public CreateAuditDetailTable() : base("AuditDetail", "AuditDetailId")
        {
        }

        public override void Up()
        {

            GetTable()
                .WithColumn("AuditId").AsGuid().NotNullable()
                .WithColumn("EntityType").AsString(50).NotNullable()
                .WithColumn("EntityKey").AsString(50).NotNullable()
                .WithColumn("AuditActionTypeId").AsGuid().NotNullable()
                .WithColumn("PropertyName").AsString(100).NotNullable()
                .WithColumn("OriginalValue").AsCustom("NVARCHAR(MAX)").Nullable()
                .WithColumn("CurrentValue").AsCustom("NVARCHAR(MAX)").Nullable();

            Create.ForeignKey("Fk_AuditActionDetail_AuditActionTypeId").FromTable("[AuditDetail]").ForeignColumn("AuditActionTypeId").ToTable("[AuditActionType]").PrimaryColumn("AuditActionTypeId");
            Create.ForeignKey("Fk_AuditDetail_AuditId").FromTable("[AuditDetail]").ForeignColumn("AuditId").ToTable("[Audit]").PrimaryColumn("AuditId");

        }

        public override void Down()
        {

        }
    }
}
