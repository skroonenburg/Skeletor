using System;
using FluentMigrator;

namespace Skeletor.DatabaseMigrations
{
    [Migration(201210041920)]
    public class CreateRoleTable : AggregateMigration
    {
        public CreateRoleTable() : base("Role", "RoleId") {}

        public override void Up()
        {
            GetTable()
                .WithColumn("Name").AsString(200).NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(false);
        }

        public override void Down()
        {
            Delete.Table("[Role]");
        }
    }
}