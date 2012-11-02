using FluentMigrator;


namespace Skeletor.DatabaseMigrations
{
    [Migration(201210181601)]
    public class CreateAuditTable : EntityMigration
    {
        public CreateAuditTable() : base("Audit", "AuditId")
        {
        }

        public override void Up()
        {

            GetTable().WithColumn("Description").AsString(500).NotNullable()
                      .WithColumn("CreatedUtcDate").AsDateTime().NotNullable()
                      .WithColumn("CreatedBy").AsGuid().NotNullable();

        }

        public override void Down()
        {
            Delete.Table("[Audit]");
        }
    }
}
